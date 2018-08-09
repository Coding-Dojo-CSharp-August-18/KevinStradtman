using System;

namespace Phone
{
    public class Nokia : Phone, IRingable 
    {
        public Nokia(string versionNumber, int batteryPercentage, string carrier, string ringTone) 
            : base(versionNumber, batteryPercentage, carrier, ringTone) {}
        public string Ring() 
        {
            string returnRing = $"... {this.ringTone} ...";
            return returnRing;
        }
        public string Unlock() 
        {
            string returnUnlock = $"Nokia {this.versionNumber} unlocked with passcode";
            return returnUnlock;
        }
        public override void DisplayInfo() 
        {
            Console.WriteLine("###################");
            Console.WriteLine($"{this.versionNumber}");
            Console.WriteLine($"{this.batteryPercentage}");
            Console.WriteLine($"{this.carrier}");
            Console.WriteLine($"{this.ringTone}");
            Console.WriteLine("###################");
        }
    }
}