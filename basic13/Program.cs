using System;
using System.Collections.Generic;

namespace basic13
{
    class Program
    {
        public static void print1to255(){
            for(int i=1; i<256; i++){
                Console.WriteLine(i);
            }
        }

        public static void printOdd1to255(){
            for(int i=1; i<256; i+=2){
                Console.WriteLine(i);
            }
        }

        public static void printSum(){
            int sum=0;
            for (int i=0; i<256; i++){
                sum += i;
                Console.WriteLine("New number:{0} Sum: {1}", i, sum);
            }
        }

        public static void iterateArray(int[] arr){
            for (int i=0; i<arr.Length; i++){
                Console.WriteLine(arr[i]);
            }
        }

        public static void findMax(int[] arr){
            int max = arr[0];
            for (int i=1; i<arr.Length; i++){
                if (arr[i]>max){
                    max = arr[i];
                }
            }
            Console.WriteLine(max);
        }

        public static void average(int[] arr){
            int sum = arr[0];
            for (int i=1; i<arr.Length; i++){
                sum += arr[i];
            }
            Console.WriteLine(sum/arr.Length);
        }

        public static int[] oddArray(){
            List<int> odds = new List<int>();
            for (int i=1; i<256; i+=2){
                odds.Add(i);
            }
            return odds.ToArray();
        }

        public static void greaterThanY(int[] arr, int y){
            int count = 0;
            for (int i=0; i<arr.Length; i++){
                if (arr[i] > y){
                    count += 1;
                }
            }
            Console.WriteLine(count);
        }

        public static int[] squareValues(int[] arr){
            for (int i=0; i<arr.Length; i++){
                arr[i] = arr[i]*arr[i];
            }
            return arr;
        }

        public static int[] noNegs(int[] arr){
            for (int i=0; i<arr.Length; i++){
                if (arr[i]<0){
                    arr[i] =0;
                }
            }
            return arr;
        }

        public static void minMaxAvg(int[] arr){
            int min = arr[0];
            int max = arr[0];
            int sum = arr[0];
            for (int i=1; i<arr.Length; i++){
                if (arr[i]>max){
                    max = arr[i];
                }
                if (arr[i]<min){
                    min = arr[i];
                }
                sum += arr[i];
            }
            Console.WriteLine("Max: {0}, Min: {1}, Avg: {2}", max, min, sum/arr.Length);
        }

        public static int[] shiftVals(int[] arr){
            for (int i=0; i<arr.Length; i++){
                if (i==arr.Length-1){
                    arr[i]=0;
                } else {
                    arr[i] = arr[i+1];
                }
            }
            return arr;
        }

        public static object[] numToString(int[] arr){
            object[] result = new object[arr.Length];
            for (int i=0; i<arr.Length; i++){
                if (arr[i]<0){
                    result[i] = "Dojo";
                } else {
                    result[i] = arr[i];
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            print1to255();

            printOdd1to255();

            printSum();

            int[] arr = {1,3,5,7,9,13};
            iterateArray(arr);

            int[] negArr = {-3,-5,-7};
            findMax(negArr);

            int[] arr2 = {2,10,3};
            average(arr2);

            int[] oddsArray = oddArray();
            foreach (int num in oddsArray){
                Console.WriteLine(num);
            }

            int[] arr3 = {1,3,5,7};
            greaterThanY(arr3, 3);

            int[] arr4 = {1,5,10,-2};
            int[] squaredArray = squareValues(arr4);
            foreach (int num in squaredArray){
                Console.WriteLine(num);
            }

            int[] noNegsArray = noNegs(arr4);
            foreach (int num in noNegsArray){
                Console.WriteLine(num);
            }

            minMaxAvg(arr4);

            int[] arr5 = {1,5,10,7,-2};
            int[] shiftedArray = shiftVals(arr5);
            foreach (int num in shiftedArray){
                Console.WriteLine(num);
            }

            int[] arr6 = {-1,-3,2};
            object[] dojoedArray = numToString(arr6);
            foreach (var item in dojoedArray){
                Console.WriteLine(item);
            }
        }
    }
}
