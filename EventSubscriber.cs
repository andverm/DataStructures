using System;

namespace Data_Structures
{
    public class EventSubscriber
    {
        public void OnVideoEncoded(object source, RunDataEventArgs e)
        {
            Print(e.Number);
            Print(e.Word);
        }

        private void Print<T>(T data)
        {
            Console.WriteLine(data);
        }
    }
}