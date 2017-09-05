namespace human
{
    public class Human
    {
        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;

        public Human(string val)
        {
            name = val;
        }

        public Human(string cname, int cstrength, int cintelligence, int cdexterity, int chealth){
            name = cname;
            strength = cstrength;
            intelligence = cintelligence;
            dexterity = cdexterity;
            health = chealth;
        }

        public void Attack(object victim){
            if (victim is Human){
                Human attacked = victim as Human;
                attacked.health -= 5 * strength;
            }
        }
    }
}