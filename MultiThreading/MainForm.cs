using System.CodeDom;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace MultiThreading
{
    public partial class MainForm : Form
    {
        private static Boolean isAcquisitionActive = false;

        // last sequence variables
        private static int latestSequence = 1;
        private static readonly object _locker = new object();

        // set of variables for summary reporting
        private static int currentSeqNr = 0;
        private static int AcqTimeMax = 0;
        private static int AcqTimeAvg = 0;
        private static int processTimeMax = 0;
        private static int processTimeAvg = 0;

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
        private void btnStartAcquisition_Click(object sender, EventArgs e)
        {
            // start threads with a beginning sleep
            if (!isAcquisitionActive)
            {
                // activate at first acquisition mode
                isAcquisitionActive = true;

                // executes both tasks in parallel
                runAcquisition();

                Console.WriteLine("TRIGGERED ACQUISITION!");
            }
        }

        public async Task runAcquisition()
        {
            await Task.Run(() =>
            {
                while (isAcquisitionActive)
                {
                    // scheduled every e.g. 5 milliseconds (if we do something or not we keep the cycle here alive!
                    Thread.Sleep(int.Parse(txtAcquisitionCycleTime.Text));

                    // we skip in case of "pause" any execution, but keep going!
                    if (!chkPause.Checked)
                    {
                        lock (_locker) ; // lock because of thread shared variable usage (sequence number)

                        // sending byte array / dummy data for acquisition 
                        byte[] dummyData = generateEmptyByteArray(latestSequence);
                        updateCurrentSequenceNumber();
                    } else
                    {
                        Thread.Sleep(20);
                    }
                }
            });
        }

        private void btnStopAcquisition_Click(object sender, EventArgs e)
        {
            isAcquisitionActive = false;
            grpBoxDataStorage.Visible = true; // TODO reverse visibility logic

            // reset variables
            latestSequence = 1;
            txtCurrentSeqNr.Text = "000" + latestSequence.ToString();

            Console.WriteLine("STOPPED ACQUISITION - RESET ALL AND START FROM BEGINNING!");
        }

        private void txtAcquisitionCycleTime_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblTimingInMs_Click(object sender, EventArgs e)
        {
        }

        private void chkPause_CheckedChanged(object sender, EventArgs e)
        {
        }

        /* generate empty byte array and prefix with given sequence number */
        private byte[] generateEmptyByteArray(int currentSequenceNumber)
        {
            // first 4 bytes + 1 MB additional dummy data (1.000.000 bytes)
            byte[] emptyByteArray = new byte[4 + (1024 * 1024)];

            // prefix first 4 bytes with integer values
            char[] prefixedInteger = currentSequenceNumber.ToString().PadLeft(4, '0').ToCharArray();
            emptyByteArray[0] = (byte) Char.GetNumericValue(prefixedInteger[0]);
            emptyByteArray[1] = (byte)Char.GetNumericValue(prefixedInteger[1]);
            emptyByteArray[2] = (byte)Char.GetNumericValue(prefixedInteger[2]);
            emptyByteArray[3] = (byte)Char.GetNumericValue(prefixedInteger[3]);

            Console.WriteLine("generateEmptyByteArray: " + currentSequenceNumber.ToString());

            return emptyByteArray;
        }

        public void runProcessingAndAnalysing(string currentSequenceNumber)
        {
            // sleeping "block" -> to simulate processing time fluctuations
            double randomSleep = new Random().Next(1, 15) / 10; // between 0,1 and 1,5
            Thread.Sleep(Convert.ToInt32(randomSleep));

            // Start the "complex" processing here
            // TODO analyse if sequence number is as expected (include counting variables)
        }

        private void updateCurrentSequenceNumber()
        {
            try
            {
                lock (_locker);

                // increment sequence, fill with zeros and update field value for presentation
                latestSequence++;
                
                // slow down
                Thread.Sleep(100);

                // update field
                // txtCurrentSeqNr.Text = latestSequence.ToString().PadLeft(4, '0');
                // txtCurrentSeqNr.Refresh();
            } catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
           
           
        }

    }
}
