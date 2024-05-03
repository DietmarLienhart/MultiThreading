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
        private static Boolean isAcquisitionActive = false;
        private static readonly object _locker = new object();

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
        

        // stop watch for time tracking overall processing time (start and stop buttons pressed)
        Stopwatch stopWatch = new Stopwatch();

        public MainForm()
        {
            // create form components
            InitializeComponent();
        }

        /*
         * Create a GUI where you can start and stop a “Camera Acquisition” task/thread. 
         * This task/thread should send every exact time (e.g. 5ms) a byte array (=image data). 
         * There should be a check box, to pause the camera acquisition. When paused, no data is sent,
         * and the overall process CPU time should be idle. */
        private void btnStartAcquisition_Click_1(object sender, EventArgs e)
        {
            // reset data at first
            resetReportData();

            // clear GUI fields when starting new threads
            clearGUIFields();

            // start threads with a beginning sleep
            if (!isAcquisitionActive)
            {
                // start stop watch for time tracking
                stopWatch.Start();

                // activate at first acquisition mode
                isAcquisitionActive = true;

                // execute both tasks in parallel
                Task.Run(() => DoSomeImageWork());
                Task.Run(() => DoSomeImageProcessing());

                Console.WriteLine("Acquisitioning and Processing: Both Tasks started.");
            } else
            {
                MessageBox.Show("Acquisitioning and Processing already in progress!");
            }
        }

        public async Task DoSomeImageWork()
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
                            calcAcquisitionTimeMax(ca.AcquisitionTime);
                            ca = null;
                        }
                    } else
                    {
                        // loop in idle to keep cpu load down
                        Thread.Sleep(500);
                    }
                }
            }
        }


        public async Task DoSomeImageProcessing()
        {
            while (true)
            {
                // get latest image from stack to start processing it
                CameraAcquisition latestCameraAcquisition = null;
                ImageProcessing ip = null;

                // get latest locked sequence number to process
                    if(_images.Count > 0)
                    {
                        latestCameraAcquisition = _images.Last().Value;
                        ip = new ImageProcessing(latestCameraAcquisition.SequenceNumber);

                        // dummy task doing nothing but o wait (longer than the image acquisition is taking)
                        ip.runProcessing();
                    
                        lock (_locker)
                        {
                            _images.TryRemove(ip.SequenceNumber, out _);
                            processingCount++;
                            calcProcessingTimeMax(ip.ProcessingTime);
                            calcProcessingTimeAvg(ip.ProcessingTime);
                    }
                    } else
                    {
                        // MessageBox.Show("QUEUE IS CURRENTLY EMPTY - NO PROCESSING!");
                        Thread.Sleep(50);
                    }

                // destroy object wether processed or not
                ip = null;
            }
        }

         private void btnStopAcquisition_Click_1(object sender, EventArgs e) 
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

        private void clearGUIFields()
        {
 
            txtAcquisitionsCnt.Text = "";
            txtProcessingsCnt.Text = "";
            txtProcessingSkippedCnt.Text = "";

            txtAcqTimeMax.Text = "";
            txtAcqTimeAvg.Text = "";
            txtProcessingTimeMax.Text = "";
            txtProcessingTimeAvg.Text = "";

            txtGarbageCollectionDelta.Text = "";
            txtTotalDurationStartEnd.Text = "";

            grpBoxDataStorage.Refresh();
        }

        private void generateGeneralReport()
        {

            txtTotalDurationStartEnd.Text = overallDurationTime.ToString();
            txtAcqTimeMax.Text = acqTimeMax.ToString();
            txtAcqTimeAvg.Text = acqTimeAvg.ToString();
            txtProcessingTimeMax.Text = processTimeMax.ToString();
            txtProcessingTimeAvg.Text = processTimeAvg.ToString();

            txtAcquisitionsCnt.Text = acquisitionCount.ToString();
            txtProcessingsCnt.Text = processingCount.ToString();
            txtProcessingSkippedCnt.Text = processingSkippedCount.ToString();

            grpBoxDataStorage.Refresh();
        }

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

        private void calcAcquisitionTimeAvg(long currentAcqTime)
        {
            lock (_locker)
            {
                acqTimeAvg = (acqTimeAvg + currentAcqTime) / 2;
            }
        }

        private void calcProcessingTimeMax(long currentProcessTime)
        {
            lock (_locker)
            {
                if (currentProcessTime > processTimeMax)
                    processTimeMax = currentProcessTime;
            }
        }

        private void calcProcessingTimeAvg(long currentProcessTime)
        {
            lock (_locker)
            {
                processTimeAvg = (processTimeAvg + currentProcessTime) / 2;
            }
        }

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

    }
}
