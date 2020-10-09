namespace Data_Structures
{
    public class RunDataEventArgs
    {
        public RunDataEventArgs(int number, string word)
        {
            Number = number;
            Word = word;
        }

        public int Number { get; }
        public string Word { get; }
    }
}