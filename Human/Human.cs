namespace Human
{
    public class Human
    {
        public string name;
        public int strength;
        public int intelligence;
        public int dexterity;
        public int health;

        public Human(string val)
        {
            name = val;
            strength = 3;
            dexterity = 3;
            intelligence = 3;
            health = 100;
        }
        public Human(string val, int a, int b, int c, int d)
        {
            name = val;
            strength = a;
            dexterity = b;
            intelligence = c;
            health = d;
        }
        public void attack(Human person)
        {
            person.health -= 5 * strength;
        }
    }
}