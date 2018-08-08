using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomArray();
            int num = 10;
            TossMultipleCoins(num);
            Names();
        }
        public static void RandomArray()
        {
            Random rand = new Random();
            int[] arr = new int[15];
            int min = 25;
            int max = 0;
            int sum = 0;
            for(var i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(5,25);
                if(arr[i] > max)
                {
                    max = arr[i];
                }
                else if(arr[i] < min)
                {
                    min = arr[i];
                }
                sum += arr[i];
            }
            double avg = sum / arr.Length;
            Console.WriteLine("Min: " + min);
            Console.WriteLine("Max: " + max);
            Console.WriteLine("Avg: " + avg);
        }
        public static void TossCoin()
        {
            Console.WriteLine("Tossing a coin!");
            Random rand = new Random();
            int output = rand.Next(0, 100);
            string outputString = "";
            if(output < 50)
            {
                outputString = "Heads";
                Console.WriteLine(outputString);
            }
            else
            {
                outputString = "Tails";
                Console.WriteLine(outputString);
            }
        }
        public static void TossMultipleCoins(int num)
        {
            for(var i = 0; i < num; i++)
            {
                TossCoin();
            }
        }
        static string[] Names()
        {
          
        }
    }
}