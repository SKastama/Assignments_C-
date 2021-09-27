using System;
using System.Collections.Generic;
namespace boxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> testObject = new List<object>();
            testObject.Add(7);
            testObject.Add(28);
            testObject.Add(-1);
            testObject.Add(true);
            testObject.Add("chair");
            int sum = 0;
            foreach (var i in testObject)
                {
                    if (i is int) {
                        int number = (int)i;
                        sum += number;
                        Console.WriteLine(number);
                    }
                    if (i is bool) {
                        bool trueFalse = (bool)i;
                        Console.WriteLine(trueFalse);
                    }
                    if (i is string) {
                        string word = i as string;
                        Console.WriteLine(word);
                    }
                }
            Console.WriteLine(sum);
        }
    }
}
