using System;
using System.Linq;
using System.Collections.Generic;
namespace Basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            // PrintOneTo255();
            // PrintOdds();
            // PrintSum();
            // IterateThroughArray();
            // FindMax();
            // GetAverage();
            // ArrayWithOddNumbers();
            // ValuesGreaterThanY();
            // SquareTheValues();
            // MinMaxAvg();
            // MinMaxAvg2();
            // ShiftingTheValuesInArray();
            // object[] container = new object[3] {-1,-3,5};
            // NumberToString(container);
        }
        public static void PrintOneTo255()
        {
            for(var i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }
        }
        public static void PrintOdds()
        {
            for(var i = 1; i <= 255; i++)
            {
                if(i % 2 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        public static void PrintSum()
        {
            int sum = 0;
            for(var i = 0; i <= 255; i++)
            {
                sum += i;
                Console.WriteLine("New Number: {0}, Sum: {1}", i, sum);
            }
        }
        public static void IterateThroughArray()
        {
            int[] X;
            X = new int[6] {1,3,5,7,9,13};
            for(var i = 0; i < X.Length; i++)
            {
                Console.WriteLine(X[i]);
            }
        }
        public static void FindMax()
        {
            int[] array;
            array = new int[6] {-2,-1,-33,-44,-34,-12};
            int maxValue = array.Max();
            Console.WriteLine(maxValue);
        }
        public static void GetAverage()
        {
            int[] array;
            array = new int[3] {2,10,3};
            int sum = 0;
            int avg = 0;;
            for(var i = 0; i < array.Length; i++)
            {
                sum += array[i];
                avg = sum / array.Length;
            }
            Console.WriteLine(avg);
        }
        public static void ArrayWithOddNumbers()
        {
            List<int> numList = new List<int>();
            for(var i = 1; i <= 255; i++)
            {
                
                if(i % 2 != 0)
                {
                    numList.Add(i);
                    for(var x = 0; x < numList.Count; x++)
                    {
                        Console.WriteLine(numList[x]);
                    }
                }
            }
        }
        public static void ValuesGreaterThanY()
        {
            int Y = 122;
            for(var i = 1; i < 255; i++)
            {
                if(i > Y) 
                {
                    Console.WriteLine(i);
                }
            }
        }
        public static void SquareTheValues()
        {
            int[] arr;
            arr = new int[4] {1,5,10,-2};
            for(var i = 0; i < arr.Length; i++)
            {
                int mult;
                mult = arr[i] * arr[i];
                Console.WriteLine(mult);
            }
        }
        public static void MinMaxAvg()
        {
            int[] arr;
            arr = new int[4] {1,5,10,-2};
            int minValue = 0;
            int maxValue = 0;
            int avg = 0;
            int sum = 0;
            minValue = arr.Min();
            maxValue = arr.Max();
            for(var i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                avg = sum / arr.Length;
            }
            Console.WriteLine("Min: " + minValue);
            Console.WriteLine("Max: " + maxValue);
            Console.WriteLine("Average: " + avg);
        }
        public static void MinMaxAvg2()
        {
            int[] arr;
            arr = new int[5] {1,2,3,4,5};
            int max = 0;
            int min = 0;
            int sum = 0;
            foreach(int i in arr)
            {
                sum += i;
                if(i > max)
                {
                    max = 1;
                }
                else if(i < min) 
                {
                    min = i;
                }
            }
            double avg = sum / arr.Length;
            Console.WriteLine("Min: " + min);
            Console.WriteLine("Max: " + max);
            Console.WriteLine("Avg: " + avg);
        }
        public static void ShiftingTheValuesInArray()
        {
            int[] arr;
            arr = new int[5] {1,5,10,7,-2};
            for(var i = 0; i < arr.Length-1; i++)
            {
                arr[i] = arr[i + 1];
            }
                arr[arr.Length-1] = 1;
                string output = "";
                foreach(int num in arr)
                {
                    output += num + " ";
                }
                output += "";
                Console.WriteLine(output);
        }
        public static object[] NumberToString(object[] arr)
        {
            for(var i = 0; i < arr.Length; i++)
            {
                if((int)arr[i] < 0)
                {
                    arr[i] = "Dojo";
                }
                Console.WriteLine(arr[i]);
            }
            return arr;
        }
    }
}