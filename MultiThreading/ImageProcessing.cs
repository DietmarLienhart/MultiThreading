using System;
using System.Diagnostics;

namespace MultiThreading
{
    public class ImageProcessing
    {
        // private variables
        private readonly Stopwatch watchProcessing = new Stopwatch();

        // public variables
        public long ProcessingTime;

        public ImageProcessing(int seqNr) {
            SequenceNumber = seqNr;
        }

        public int SequenceNumber
        { get; set; }

        /// <summary>
        /// processing images simulation (does nothing than wait actually ...)
        /// </summary>
        public void runProcessing()
        {
            watchProcessing.Start();
            processImage();
            watchProcessing.Stop();
            ProcessingTime = watchProcessing.ElapsedMilliseconds;
        }

        /// <summary>
        /// process images -> basically just a sleep to take some CPU time longer than the image acquisition for simulation of fluctuations!
        /// </summary>
        private void processImage()
        {
            // sleeping "block" -> to simulate processing time fluctuations
            double randomSleep = (double) new Random().Next(20, 50) / 10; // between 2 and 5
            
            Thread.Sleep(Convert.ToInt32(randomSleep) * 100); // TODO remove 100 -> slowed down for debugging console window and demo purpose only!

            // print info that image was processed
            Console.WriteLine("IMAGE PROCESSING PERFORMED: " + SequenceNumber + " with a delay of: " + randomSleep.ToString());
        }
    }
 }