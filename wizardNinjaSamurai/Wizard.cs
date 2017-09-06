using System;

namespace wizardNinjaSamurai
{
    public class Wizard : Human
    {
        public Wizard(string person, int str = 3, int dex = 3) : base(person, str, 25, dex, 50){}

        public void heal(){
            health += intelligence * 10;
        }

        public void fireball(object obj){
            Human enemy = obj as Human;
            if(enemy == null)
            {
                Console.WriteLine("Failed Attack");
            }
            else
            {
                Random rand = new Random();
                enemy.health -= rand.Next(20,51); 
            }

        }
    }
}