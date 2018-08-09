using System;

namespace Wizard
{
    class Samurai : Human
    {
        public Samurai(string i) : base(i)
        {
            health = 200;
        }
        public void DeathBlow(object enemy)
        {
            Human opponent = enemy as Human;
            if(opponent != null)
            {
                if(opponent.health < 50)
                {
                    opponent.health = 0;
                }
            }
        }
        public void Meditate()
        {
            health = 200;
        }
    }
}