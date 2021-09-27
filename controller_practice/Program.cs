using System;
using System.Collections.Generic;


namespace controller_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = {1,2,3,4,6,7,8,9};
            for (int x = 0; x < numArray.Length; x++)
                {
                    Console.WriteLine(numArray[x]);
                }
            string[] stringArray = new string[] {"Tim", "Martin", "Nikki", "Sara"};
            foreach (string y in stringArray)
                {
                    Console.WriteLine(y);
                }
            string[] trueFalseArray = {"true", "false", "true", "false", "true", "false", "true", "false", "true", "false"};
            foreach (string z in trueFalseArray)
                {
                    Console.WriteLine(z);
                }
            
            List<string> icecream = new List<string>();
            icecream.Add("Chocalate");
            icecream.Add("Cookies n Cream");
            icecream.Add("Vanilla");
            icecream.Add("Prailines and Cream");
            icecream.Add("Strawberry");
            Console.WriteLine(icecream.Count);
            icecream.RemoveAt(3);
            Console.WriteLine(icecream.Count);

            Random rand = new Random();
            Dictionary<string,string> dictionaryTest = new Dictionary<string,string>();
            foreach (string i in stringArray) 
                {
                    dictionaryTest.Add(i, icecream[rand.Next(0, (icecream.Count))]);
                }
            foreach (var entry in dictionaryTest)
                {
                    Console.WriteLine(entry.Key + " - " + entry.Value);
                }
        }
    }
}
