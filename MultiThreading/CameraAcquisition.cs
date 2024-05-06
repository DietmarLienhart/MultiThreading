using System;
using System.Collections;
using System.Diagnostics;

namespace MultiThreading
{
    public class CameraAcquisition
    {
        // private variables
        private readonly Stopwatch watchAcquisition = new Stopwatch();

        // public variables
        public long AcquisitionTime;
        public byte[] DummyByteArray;

        public CameraAcquisition(int seqNr) {
            SequenceNumber = seqNr;
        }

        public int SequenceNumber
        { get; set; }

        public void runAcquisition()
        {
            watchAcquisition.Start();

            // First "manual" approach
            // DummyByteArray = runImageAcquisition_WithEmptyDummyData();
            
            // Secondly: Bit Shifting Approach
            DummyByteArray = runImageAcquisition_WithEmptyDummyData_Using_BitShifting();

            watchAcquisition.Stop();
            AcquisitionTime = watchAcquisition.ElapsedMilliseconds;
        }

        /// <summary>
        /// image acquisition -> generates emtpy dummy byte arrays with prefixed incremented integer (sequence) number
        /// NOT done via bit shifting, I know ...! :-P
        /// </summary>
        /// <returns></returns>
        private byte[] runImageAcquisition_WithEmptyDummyData()
        {
            // first 4 bytes + 1 MB additional dummy data (1.000.000 bytes)
            byte[] emptyByteArray = new byte[4 + (1024 * 1024)];

            // prefix first 4 bytes with integer values
            char[] prefixedInteger = SequenceNumber.ToString().PadLeft(4, '0').ToCharArray();
            emptyByteArray[0] = (byte)Char.GetNumericValue(prefixedInteger[0]);
            emptyByteArray[1] = (byte)Char.GetNumericValue(prefixedInteger[1]);
            emptyByteArray[2] = (byte)Char.GetNumericValue(prefixedInteger[2]);
            emptyByteArray[3] = (byte)Char.GetNumericValue(prefixedInteger[3]);

            // adding extra delay as well, as just an empty byte array is created (faster than processing tasks)
            double randomSleep = (double) new Random().Next(10, 20) / 10; // between 1 and 2

            // TODO remove 100 ms sleep -> just slowing down here for debugging console window and demo purpose only!
            Thread.Sleep(Convert.ToInt32(randomSleep) * 100);

            Console.WriteLine("ACQUISITION PERFORMED: " + SequenceNumber + " with a delay of: " + randomSleep.ToString());

            return emptyByteArray;
        }

        /// <summary>
        /// Create a 1 MB dummy byte array with incremented integers via bit shifting
        /// </summary>
        /// <returns>a dummy 1mb byte array</returns>

        private byte[] runImageAcquisition_WithEmptyDummyData_Using_BitShifting()
        {
            int arraySizeInBytes = 1024 * 1024; // 1 MB
            
            byte[] emptyByteArray = new byte[4 + (1024 * 1024)];
            emptyByteArray = createByteArrayWithIncrementedInteger(SequenceNumber, arraySizeInBytes);

            return emptyByteArray;
        }

        /**
         * Create a dummy 1mb byte array 
         * */
        static byte[] createByteArrayWithIncrementedInteger(int value, int arraySize)
        {
        // Convert the integer value to a byte array (little-endian)
        byte[] result = new byte[arraySize];
        result[0] = (byte)(value >> 24);
        result[1] = (byte)(value >> 16);
        result[2] = (byte)(value >> 8);
        result[3] = (byte)value;

        // Fill the remaining bytes with a specific value (e.g., 0x20)
        for (int i = 4; i < result.Length; i++)
        {
            result[i] = 0x20; // You can adjust this value as needed
        }

        return result;
        }

    }
 }