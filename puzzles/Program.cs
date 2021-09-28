using System;
using System.Collections.Generic;
using System.Linq;
namespace puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public static int[] RandomArray()
        {
            Random rand = new Random();
            int[] randArr = new int[10];
            int max= 0;
            int min= 0;
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                randArr[i] = rand.Next(5, 25);
                if (randArr[i] > max) 
                {
                    max = randArr[i];
                }
                if (randArr[i] < min) 
                {
                    min = randArr[i];
                }
                sum += randArr[i];
            }
            Console.WriteLine(max);
            Console.WriteLine(min);
            Console.WriteLine(sum);
            return randArr;
        }
        public static string TossCoin()
        {
            Random rand = new Random();
            Console.WriteLine("Tossing a Coin!");
            int toss = rand.Next(0, 1);
            if (toss == 0) 
            {
                return "Heads";
            }
            else 
            {
                return "Tails";
            }
        }
        public static string TossMultipleCoins(int num)
        {
            int headsCount = 0;
            int tailsCount = 0;
            for (int i = num; i < num; i++)
            {
                string result = TossCoin();
                if (result == "Heads")
                {
                    headsCount+= 1;
                }
                if (result == "Tails")
                {
                    tailsCount+= 1;
                }
            }
            string total = $"{headsCount} heads / {tailsCount} tails";
            return total;
        }
        public static List<string> Names()
        {
            Random rand = new Random();
            List<string> nameList = new List<string>();
            List<string> nameListNew = new List<string>();
            nameList.Add("Todd");
            nameList.Add("Tiffany");
            nameList.Add("Charlie");
            nameList.Add("Geneva");
            nameList.Add("Sydney");
            var shuffled = nameList.OrderBy(item => rand.Next());
            foreach(var value in shuffled)
            {
                if (value.Length > 5)
                {
                    nameListNew.Add(value);
                }
            }
            return nameListNew;
        }
    }
}
