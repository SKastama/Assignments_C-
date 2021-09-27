using System;

namespace basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!!");
        }
        public static void PrintNumbers()
        {
            for (int i=1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }
        }

        public static void PrintOdds()
        {
            for (int i=1; i <= 255; i++)
            {
                if (i%2!= 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static void PrintSum()
        {
            int sum = 0;
            for (int i=1; i <= 255; i++)
            {
                sum += i;
            }
            Console.WriteLine(sum);
        }

        public static void LoopArray(int[] numbers)
        {
            for (int i=0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }

        public static int FindMax(int[] numbers)
        {
            int maxValue= 0;
            for (int i=0; i < numbers.Length; i++)
            {
                if (numbers[i] > maxValue) 
                {
                    maxValue= numbers[i];
                }
            }
            Console.WriteLine(maxValue);
            return maxValue;
        }

        public static void GetAverage(int[] numbers)
        {
            int average= 0;
            int sum = 0;
            for (int i=0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            average = (sum / numbers.Length);
            Console.WriteLine(average);
        }

        public static int[] OddArray()
        {
            int[] oddArr = new int[(255/2) + 1];
            int idx = 0;
            for (int i=1; i <= 255; i+=2)
            {
                oddArr[idx]= i;
                idx++;
            }
            return oddArr;
        }

        public static int GreaterThanY(int[] numbers, int y)
        {
            int count = 0;
            for (int i=0; i < numbers.Length; i++) {
                if (numbers[i] > y) {
                    
                }
            }

        }
















    }
}
