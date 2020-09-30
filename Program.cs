using System;

namespace Data_Structures
{
    public static class Program
    {
        public static void Main()
        {
            var dictionary = new DictionaryClass();

            dictionary.Add(1, "one");
            dictionary.Add(2, "two");
            dictionary.Add(3, "three");
            dictionary.Add(4, "four");
            dictionary.Add(5, "five");
            dictionary.Add(6, "six");
            dictionary.Add(7, "seven");
            dictionary.Add(8, "eight");
            dictionary.Add(9, "nine");
            dictionary.Add(10, "ten");
            dictionary.Add(11, "eleven");
            dictionary.Add(12, "twelve");
            dictionary.Add(13, "thirteen");
            dictionary.Add(14, "fourteen");
            dictionary.Add(15, "fifteen");
            dictionary.Add(16, "sixteen");
            dictionary.Add(17, "seventeen");
            dictionary.Add(18, "eighteen");
            dictionary.Add(19, "nineteen");
            dictionary.Add(20, "twenty");
            dictionary.Add(20, "NEWtwenty");

            dictionary.Remove(3);

            dictionary.Print();

            Console.WriteLine();

            var valueOne = dictionary.Get(11);
            var valueTwo = dictionary.Get(3);

            Console.WriteLine(valueOne);
            Console.WriteLine(valueTwo);

            string input = "this will be a good sentence to test my new method";
            var charFinder = new CharFinder();
            var result = charFinder.FindMostRepeatedChar(input);

            Console.WriteLine(result);
        }
    }
}