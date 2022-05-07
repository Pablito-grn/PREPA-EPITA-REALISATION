using System;

namespace Basics
{
    public class Arrays
    {
        // Returns the position of an element in an array
        // If the element is not in the array, returns -1
        public static int Search(int[] arr, int e)
        {
            int l = arr.Length, i = 0, result = (-1);
            while (i<l && result == (-1))
            {
                if (arr[i] == e)
                    result = i;
                i++;
            }
            return result;
        }

        
        
        
        // Write the function ViceMax, that takes an array as parameter and returns the second largest
        // value in it. You can suppose the array contains at least 2 elements and at least 2 different
        // values.
        public static int ViceMax(int[] array)
        {
            int l = array.Length, i = 0, pg = array[0] , pg2 = 0;
            
            while (i<l)
            {
                if (array[i] > pg)
                {
                    pg2 = pg;
                    pg = array[i];
                }
                else if (array[i] < pg && array[i] > pg2)
                    pg2 = array[i];
                
                i++;
            }
            return pg2;
        }
        
        // Returns the king of the hill
        // If there isn't one, returns -1
        public static int KingOfTheHill(int[] arr) // a faire
        {
            int l = arr.Length, res = (-1);
            bool kingfind = false;

            for (int i = 0; i < l-1; i++)
            {
                if (arr[i] > arr[i+1] && kingfind == false)
                {
                    res = arr[i];
                    kingfind = true;
                }
                else if (arr[i] < arr[i+1] && kingfind == true)
                {
                    res = (-1);
                    break;
                }
            }

            return res;
        }

        // Returns a copy of the provided array
        public static int[] CloneArray(int[] arr)
        {
            int l = arr.Length;
            int[] arr2 = new int[l];

            for (int i = 0; i < l; i++)
            {
                arr2[i] = arr[1];
            }
            return arr2;
        }

        // Returns a sorted array, using the BubbleSort method
        public static bool EstTriee(int[] arr)
        {
            bool test = true;
            int l = arr.Length;
            for (int i = 0; i < (l-1); i++)
                if (arr[i] > arr[i + 1])
                    test = false;
            
            return test;
        }
        
        
        public static void BubbleSort(int[] arr)
        {
            int temp, l = arr.Length;
            while (EstTriee(arr) != true)
            {
                for (int i = 0; i < (l-1); i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i + 1];
                        arr[i+1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
        }

        // Bonus
        // Sorts an array using another sort method.
        // In this case: https://en.wikipedia.org/wiki/Comb_sort
        public static void AnotherSort(int[] arr)
        {
            int temp, l = arr.Length; 
            float interval = l ;
            while (EstTriee(arr) != true)
            { 
                interval = interval / 1.3f;
                
                for (int i = 0; i < (l-interval); i++)
                {
                    if (arr[i] > arr[i+(int) interval])
                    {
                        temp = arr[i+(int) interval];
                        arr[i+ (int) interval] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
            
        }
    }
}
