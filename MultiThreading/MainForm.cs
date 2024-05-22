using System.CodeDom;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MultiThreading
{
    public partial class MainForm : Form
    {
        // Flag to track acquisition state
        private static Boolean isAcquisitionActive = false;

        // thread helpersmanualResetEvent
        private ManualResetEvent manualResetEvent = new ManualResetEvent(false); 

        // thread-safe variable access
        private static readonly object _locker = new object();
        
        // for time tracking overall processing time (start and stop buttons pressed)
        Stopwatch stopWatch = new Stopwatch(); 

        // set of variables for summary reporting
        protected static ConcurrentDictionary<int, CameraAcquisition> _images = new ConcurrentDictionary<int, CameraAcquisition>();
        protected static int currentSequenceNr = 0;
        protected static int acquisitionCount = 0;
        protected static int processingCount = 0;
        protected static int processingSkippedCount = 0;
        protected static string overallDurationTime = "";
        protected static long acqTimeMax = 0;
        protected static long acqTimeAvg = 0;
        protected static long processTimeMax = 0;
        protected static long processTimeAvg = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        /*
         * Starts a “Camera Acquisition” task/thread, as well as a processing thread in parallel.
         * *) First task should "send" every exact time (e.g. 5ms) a byte array. Empty byte arrays are getting created with a dummy delay. 
         * *) Second task starts to process in parallel any byte array which is getting put into a buffer.
         */
        private void btnStartAcquisition_Click(object sender, EventArgs e)
        {

            // start threads with a beginning sleep
            if (!isAcquisitionActive)
            {
                // reset data at first
                resetReportData();

                // clear GUI fields when starting new threads
                clearGUIFields();

                // start stop watch for overall time tracking
                stopWatch.Start();

                // activate at first acquisition mode
                isAcquisitionActive = true;

                // execute both tasks in parallel
                Task.Run(() => DoSomeImageAcquisitionWorkCallback());
                Task.Run(() => DoSomeImageProcessingCallback());

                Console.WriteLine("Acquisitioning and Processing: Both Tasks started.");

            } else {
                MessageBox.Show("Acquisitioning and Processing already in progress!");
            }
        }

        public async Task DoSomeImageAcquisitionWorkCallback()
        {
            while (isAcquisitionActive)
            {
                {
                    // schedule acquisition within this task -> every e.g. 5 milliseconds (wether we are on pause checkbox or not, we keep the execution cycle here alive!)
                    Thread.Sleep(int.Parse(txtAcquisitionCycleTime.Text));

                    // we skip in case of "pause" any execution, but keep going!
                    if (!chkPause.Checked)
                    {
                        // lock because of thread shared variable usage (e.g. sequence number)
                        lock (_locker)
                        {
                            // only image Acquisition increases the current sequence number
                            currentSequenceNr++;

                            // creates an empty byte array prefixed with first 4 bytes for the seq nr
                            CameraAcquisition ca = new CameraAcquisition(currentSequenceNr);
                            ca.runAcquisition();
                            _images.TryAdd(currentSequenceNr, ca);
                            acquisitionCount++;
                            calcAcquisitionTimeMax(ca.AcquisitionTime);
                            calcAcquisitionTimeAvg(ca.AcquisitionTime);
                            ca = null;
                        }
                    } else {
                        // loop in idle to keep cpu load down
                        Thread.Sleep(500);
                    }
                }
            }
        }

        /// <summary>
        /// Processes each image dummy image
        /// </summary>
        /// <returns></returns>
        public async Task DoSomeImageProcessingCallback()
        {
            while (true)
            {
                // get latest image from stack to start processing it
                CameraAcquisition latestCameraAcquisition = null;
                ImageProcessing ip = null;

                // get latest locked sequence number to process
                if(_images.Count > 0 && !chkPause.Checked)
                {
                    latestCameraAcquisition = _images.Last().Value;
                    ip = new ImageProcessing(latestCameraAcquisition.SequenceNumber);

                    // dummy task doing nothing but o wait (longer than the image acquisition is taking)
                    ip.runProcessing();
                    
                    // thread-safe access to the images buffer
                    lock (_locker)
                    {
                        _images.TryRemove(ip.SequenceNumber, out _);
                        processingCount++;
                        calcProcessingTimeMax(ip.ProcessingTime);
                        calcProcessingTimeAvg(ip.ProcessingTime);
                    }
                } else {
                    // MessageBox.Show("QUEUE IS CURRENTLY EMPTY - NO PROCESSING!");
                    Thread.Sleep(50);
                }

                // destroy object wether processed or not
                ip = null;
            }
        }

        /// <summary>
        /// stop camera acquisition and generate a summary report
        /// </summary>
         private void btnStopAcquisition_Click(object sender, EventArgs e) 
         {

            // reset process handling variables
            isAcquisitionActive = false;

            // wait for all images in buffer to be processed completely
            if(_images.Count > 0)
            {
                MessageBox.Show("Please wait till report is generated, processing images from buffer ...");
            }
            while (_images.Count > 0)
            {
                Thread.Sleep(50);
            }

            // calculate final execution time after everything was processed
            calcOverallDuration();

            // finally generate report
            generateGeneralReport();

            Console.WriteLine("STOPPED IMAGE ACQUISITION -> ALL VALUES RESET!");
         }

        /// <summary>
        /// Reset all reporting variables
        /// </summary>
        private void resetReportData()
        {
            // reporting data
            currentSequenceNr = 0;
            acquisitionCount = 0;
            processingCount = 0;
            processingSkippedCount = 0;
            overallDurationTime = "";
            acqTimeMax = 0;
            acqTimeAvg = 0;
            processTimeMax = 0;
            processTimeAvg = 0;
        }

        /// <summary>
        /// Clear all UI fields
        /// </summary>
        private void clearGUIFields()
        {
            txtAcquisitionsCnt.Text = "";
            txtProcessingsCnt.Text = "";
            txtAcqTimeMax.Text = "";
            txtAcqTimeAvg.Text = "";
            txtProcessingTimeMax.Text = "";
            txtProcessingTimeAvg.Text = "";
            txtTotalDurationStartEnd.Text = "";
            grpBoxDataStorage.Refresh();
        }
        
        /// <summary>
        /// Generate an end report within UI
        /// </summary>
        private void generateGeneralReport()
        {

            txtTotalDurationStartEnd.Text = overallDurationTime.ToString();
            txtAcqTimeMax.Text = acqTimeMax.ToString();
            txtAcqTimeAvg.Text = acqTimeAvg.ToString();
            txtProcessingTimeMax.Text = processTimeMax.ToString();
            txtProcessingTimeAvg.Text = processTimeAvg.ToString();
            txtAcquisitionsCnt.Text = acquisitionCount.ToString();
            txtProcessingsCnt.Text = processingCount.ToString();
            grpBoxDataStorage.Refresh();
        }

        /// <summary>
        /// Calculate the maximum time taken for acquisition
        /// </summary>
        private void calcAcquisitionTimeMax(long currentAcqTime)
        {
            lock(_locker)
            {
                if (currentAcqTime > acqTimeMax)
                {
                    acqTimeMax = currentAcqTime;
                }
            }
        }

        /// <summary>
        /// Calculate the average acquisition time
        /// </summary>
        private void calcAcquisitionTimeAvg(long currentAcqTime)
        {
            lock (_locker)
            {
                acqTimeAvg = (acqTimeAvg + currentAcqTime) / 2;
            }
        }

        /// <summary>
        /// Calculate the maximum time taken for image processing
        /// </summary>
        private void calcProcessingTimeMax(long currentProcessTime)
        {
            lock (_locker)
            {
                if (currentProcessTime > processTimeMax)
                    processTimeMax = currentProcessTime;
            }
        }

        /// <summary>
        /// Calculate the average image processing time
        /// </summary>
        private void calcProcessingTimeAvg(long currentProcessTime)
        {
            lock (_locker)
            {
                processTimeAvg = (processTimeAvg + currentProcessTime) / 2;
            }
        }

        /// <summary>
        /// Calculate whole execution time from start till end buttons are pressed
        /// </summary>
        private void calcOverallDuration()
        {
            // stop overall processing time and update field
            stopWatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value. 
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            overallDurationTime = elapsedTime;

        }

        /// <summary>
        /// pause a thread via ManualResetEvent
        /// </summary>
        private void chkPause_CheckedChanged(object sender, EventArgs e)
        {
            if(chkPause.Checked)
            {
                manualResetEvent.Reset(); // resume tasks
            } else
            {
                manualResetEvent.Set(); // pause tasks
            } 
        }

    }
}
