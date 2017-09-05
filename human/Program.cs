using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human alpha = new Human("Alpha");
            Human beta = new Human("Beta", 10, 10, 10, 150);
            alpha.Attack(beta);
            Console.WriteLine(beta.health);
        }
    }
}
