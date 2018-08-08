using System;
using System.Collections.Generic;
namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //Arrays
            int[] numArray;
            numArray = new int[10] {0,1,2,3,4,5,6,7,8,9};
            string[] peopleArray;
            peopleArray = new string[4] {"Tim", "Martin", "Nikki", "Sara"};
            bool[] truthyFalsey;
            truthyFalsey = new bool[10] {true, false, true, false, true, false, true, false, true, false};

            //Lists
            List<string> flavors = new List<string>();
            flavors.Add("Chocolate Chip Cookie Dough");
            flavors.Add("Chocolate Chip");
            flavors.Add("Mint Chocolate Chip");
            flavors.Add("Sherbert");
            flavors.Add("Vanilla");
            Console.WriteLine(flavors[2]);
            flavors.Remove("Mint Chocolate Chip");
            Console.WriteLine("There are {0} flavors that we carry.", flavors.Count);

            //Dictionaries
            Dictionary<string,string> flavor = new Dictionary<string,string>();
            flavor.Add("Kevin", "Chocolate Chip Cookie Dough");
            flavor.Add("Kyle", "Chocolate Chip");
            flavor.Add("Debra", "Mint Chocolate Chip");
            flavor.Add("John", "Sherbert");
            flavor.Add("Patrick", "Vanilla");
            foreach(KeyValuePair<string,string> entry in flavor)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}
