using System;
using System.Threading;

namespace Data_Structures
{
    public class RunData
    {
        public int Number { get; }

        public RunData(int number)
        {
            Number = number;
        }
    }

    public class EventRunner
    {
        // 1. Define delegate
        // 2. Define event based on delegate.
        // 3. Raise the event.

        public delegate void ProgramFinishedEventHandler(object source, RunData data);

        public event ProgramFinishedEventHandler VideoEncoded;

        public void Run(int data)
        {
            Console.WriteLine("Program started...");
            Thread.Sleep(3000);

            OnVideoEncoded(data);
        }

        private void OnVideoEncoded(int data)
        {
            var runData = new RunData(data);
            VideoEncoded?.Invoke(this, runData);
        }
    }

    public class Debugger
    {
        public void OnVideoEncoded(object source, RunData e)
        {
            Print(e.Number);
        }

        private void Print<T>(T data)
        {
            Console.WriteLine(data);
        }
    }

    public static class Program
    {
        public static void Main()
        {
            var eventRunner = new EventRunner();
            var debugger = new Debugger();
            eventRunner.VideoEncoded += debugger.OnVideoEncoded;

            eventRunner.Run(21);

            // var trie = new TrieUsingDictionary();
            //
            // trie.Insert("abc");
            // trie.Insert("abde");
            //
            // Console.WriteLine();
        }
    }
}