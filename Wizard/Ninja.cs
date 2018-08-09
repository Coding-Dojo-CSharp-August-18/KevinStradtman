using System;

namespace Wizard
{
    public class Ninja : Human
    {
        public Ninja(string i) : base(i)
        {
            dexterity = 175;
        }
        public void Steal(object enemy)
        {
            Human opponent = enemy as Human;
            if(opponent != null)
            {
                health += 10;
                attack(opponent);
            }
        }
        public void GetAway()
        {
            health -= 15;
        }
    }
}