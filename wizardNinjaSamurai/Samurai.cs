using System;

namespace wizardNinjaSamurai
{
    public class Samurai : Human
    {
        static int numSamurai = 0;
        
        public Samurai(string person, int str = 3, int intel = 3, int dex = 3) : base(person, str, intel, dex, 200)
        {
            numSamurai += 1;
        }

        public void death_blow(object obj){
            base.attack(obj);
            Human enemy = obj as Human;
            if(enemy == null)
            {
                Console.WriteLine("Failed Attack");
            }
            else if(enemy.health < 50){
                enemy.health = 0;
            }
        }

        public void meditate(){
            health = 200;
        }

        public int how_many(){
            return numSamurai;
        }
    }
}