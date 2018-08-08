using System;
using System.Collections.Generic;

namespace BoxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            List<object> items = new List<object>();
            items.Add(7);
            items.Add(28);
            items.Add(-1);
            items.Add(true);
            items.Add("chair");
            for(var i = 0; i < items.Count; i++)
            {
                Console.WriteLine(items[i]);
            }
            foreach(var item in items)
            {
                if(item is int)
                {
                    sum += (int)item;
                }
            }
            Console.WriteLine("Sum: " + sum);
        }
    }
}
