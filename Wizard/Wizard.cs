using System;

namespace Wizard
{
    public class Wizard : Human
    {
        public Wizard(string i) : base(i)
        {
            health = 50;
            intelligence = 25;
        }
        public void Heal(object self)
        {
            health = 10 * intelligence;
        }
        public void FireBall(object enemy)
        {
            Random rand = new Random();
            Human opponent = enemy as Human;
            int randomHit = rand.Next(20, 50);
            if(opponent != null)
            {
                opponent.health -= randomHit;
            }
        }
    }
}