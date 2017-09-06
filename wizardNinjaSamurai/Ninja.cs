namespace wizardNinjaSamurai
{
    public class Ninja : Human
    {
        public Ninja(string person, int str = 3, int intel = 3, int hp = 100) : base(person, str, intel, 175, hp){}

        public void steal(object obj){
            base.attack(obj);
            health += 10;
        }

        public void get_away(){
            health -=15;
        }
    }
}