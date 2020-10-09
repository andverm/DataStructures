using System;
using System.Threading;

namespace Data_Structures
{
    public class EventCaller
    {
        // 1. Define delegate
        // 2. Define event based on delegate.
        // 3. Raise the event.

        public event EventHandler<RunDataEventArgs> VideoEncoded;

        public void Run(RunDataEventArgs data)
        {
            Console.WriteLine("Program started...");
            Thread.Sleep(3000);

            OnVideoEncoded(data);
        }

        private void OnVideoEncoded(RunDataEventArgs data)
        {
            VideoEncoded?.Invoke(this, data);
        }
    }
}