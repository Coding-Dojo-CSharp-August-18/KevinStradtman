using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human person1 = new Human("James", 3,3,3,90);
            Human person2 = new Human("Kevin", 5,5,5,100);
            person2.attack(person1);
            person1.attack(person2);
            Console.WriteLine(person1.health);
            Console.WriteLine(person2.health);
        }
    }
}