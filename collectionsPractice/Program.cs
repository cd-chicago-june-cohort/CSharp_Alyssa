using System;
using System.Collections.Generic;

namespace collectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
        // Three Basic Arrays
        // Create an array to hold integer values 0 through 9
            int[] arr1 = {0,1,2,3,4,5,6,7,8,9};
            foreach (var num in arr1){
                Console.WriteLine(num);
            }
        // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            string[] arr2 = {"Tim", "Martin", "Nikki", "Sara"};
            foreach (var name in arr2){
                Console.WriteLine(name);
            }
        // Create an array of length 10 that alternates between true and false values, starting with true
            bool[] arr3 = new bool[10];
            for (int i=0; i<arr3.Length; i++){
                if (i%2==0){
                    arr3[i] = true;
                } else {
                    arr3[i] = false;
                }
            }
            foreach (var state in arr3){
                Console.WriteLine(state);
            }
        // Multiplication Table
            int [,] multTable = new int[10,10];
            for (int i=0; i<10; i++){
                multTable[0,i]=i+1;
            }
            for (int j=0; j<10; j++){
                multTable[j,0]=j+1;
            }
            for (int k=1; k<10; k++){
                for (int l=1; l<10; l++){
                    multTable[k,l] = multTable[k,0] * multTable[0,l];
                }
            }
            for (int m = 0; m < 10; m++)
            {
                for (int n = 0; n < 10; n++)
                {
                    Console.Write(string.Format("{0} ", multTable[m, n]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        // List of Flavors
            List<string> flavors = new List<string>();
            flavors.Add("Vanilla");
            flavors.Add("Chocolate");
            flavors.Add("Salted Caramel");
            flavors.Add("Coconut");
            flavors.Add("Mint Chip");
            Console.WriteLine(flavors.Count);
            Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);
            Console.WriteLine(flavors.Count);

        // User Info Dictionary
            Dictionary<string,string> user = new Dictionary<string,string>();
            user.Add("Tim", null);
            user.Add("Martin", null);
            user.Add("Nikki", null);
            user.Add("Sara", null);
            Random rand = new Random();
            foreach (string name in arr2){
                user[name] = flavors[rand.Next(0,4)];
            }
            foreach (KeyValuePair<string,string> entry in user){
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}
