using System;
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
            DummyByteArray = generateAnEmptyByteArray();
            watchAcquisition.Stop();
            AcquisitionTime = watchAcquisition.ElapsedMilliseconds;
        }

        private byte[] generateAnEmptyByteArray()
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
            
            Thread.Sleep(Convert.ToInt32(randomSleep) * 100); // TODO remove 100 -> slowed down for debugging console window!

            Console.WriteLine("ACQUISITION PERFORMED: " + SequenceNumber + " with a delay of: " + randomSleep.ToString());

            return emptyByteArray;
        }

    }
 }