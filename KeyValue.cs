namespace Data_Structures
{
    public class KeyValue
    {
        public int Key { get; }
        public string Value { get; set; }

        public KeyValue(int key, string value)
        {
            Key = key;
            Value = value;
        }

        public void UpdateValue(string value)
        {
            Value = value;
        }
    }
}