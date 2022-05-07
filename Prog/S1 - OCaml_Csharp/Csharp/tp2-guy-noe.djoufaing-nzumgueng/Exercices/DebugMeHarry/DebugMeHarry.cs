using System;
using System.Collections.Generic;

namespace DebugMeHarry
{
    public static class DebugMeHarry
    {
        /*
         * For curiosity: This is XML documentation to document properly functions.
         * Don't hesitate to use it to describe your future functions!
         * https://docs.microsoft.com/en-us/dotnet/csharp/codedoc
         */
        /// <summary>
        /// Prints the content of a list <paramref name="list"/>.
        /// </summary>
        /// <remarks>
        /// THIS FUNCTION HASN'T ANY PROBLEM
        /// </remarks>
        /// <param name="list">a list of int.</param>
        public static void printList(List<int> list)
        {
            Console.Write("[");
            for (int i = 0; i < list.Count - 1; ++i)
            {
                Console.Write(" {0},", list[i]);
            }
            Console.WriteLine(" {0} ]", list[^1]);
        }

        /// <summary>
        /// Compares two int <paramref name="i"/> and <paramref name="j"/> and returns if you have to swap them.
        /// </summary>
        /// <returns>
        /// True if you have to swap the two int, false if not.
        /// </returns>
        /// <param name="i">a simple int.</param>
        /// <param name="j">a simple int.</param>
        public delegate bool MyComp(int i, int j);

        
        
        /// <summary>
        /// Looks if <paramref name="i"/> is lower than <paramref name="j"/> and returns if you have to swap them.
        /// </summary>
        /// <returns>
        /// True if you have to swap the two int, false if not.
        /// </returns>
        /// <param name="i">a simple int.</param>
        /// <param name="j">a simple int.</param>
        public static bool lowerSort(int i, int j)
        {
            return i >= j;
        }

        
        
        /// <summary>
        /// Looks if <paramref name="i"/> is greater than <paramref name="j"/> and returns if you have to swap them.
        /// </summary>
        /// <returns>
        /// True if you have to swap the two int, false if not.
        /// </returns>
        /// <param name="i">a simple int.</param>
        /// <param name="j">a simple int.</param>
        public static bool greaterSort(int i, int j)
        {
            return i < j;
        }

        /// <summary>
        /// Tells if a int <paramref name="i"/> is even.
        /// </summary>
        /// <returns>
        /// True if the int is even, false if not
        /// </returns>
        /// <param name="i">a simple int.</param>
        public static bool isEven(int i)
        {
            bool even = i % 2 == 0;
            return even;
        }
        
        
        /// <summary>
        /// Looks if <paramref name="i"/> or <paramref name="j"/> are even and returns if you have to swap them.
        /// </summary>
        /// <returns>
        /// True if you have to swap the two int, false if not.
        /// </returns>
        /// <param name="i">a simple int.</param>
        /// <param name="j">a simple int.</param>
        public static bool evenSort(int i, int j)
        {
            
            return !isEven(i) && isEven(j);
        }

        
        
        
        /// <summary>
        /// Looks if <paramref name="i"/> is lower than <paramref name="j"/> in alphabetical logic and returns if you have to swap them.
        /// </summary>
        ///
        /// 
        /// <returns>
        /// True if you have to swap the two int, false if not.
        /// </returns>
        /// <param name="i">a simple int.</param>
        /// <param name="j">a simple int.</param>
        public static bool alphabeticalSort(int i, int j)
            /*
             * examples:
             * 11 < 2  because 1 < 2
             * 41231 < 419 because 2 < 9
             * 1 < 12 because 12 is longer
             */
        {
            int div1 = 1;
            int div2 = 1;
            while (div1 * 10 <= i)
                div1 *= 10;
            while (div2 * 10 <= j)
                div2 *= 10;
        
            while (div1 > 0 && div2 > 0)
            {
                if (i / div1 != j / div2)
                {
                    return (i / div1 > j / div2);
                }
        
                div2 /= 10;
                div1 /= 10;
            }
    
            return div2 != div1 ;
        }

        
        
        
        
        /// <summary>
        /// Swaps the content of list <paramref name="list"/> between position <paramref name="ind1"/> and <paramref name="ind2"/>.
        /// </summary>
        /// <param name="list">a list of int.</param>
        /// <param name="ind1">a simple int index.</param>
        /// <param name="ind2">a simple int index.</param>
        public static void swap(List<int> list, int ind1, int ind2)
        {
            int tmp = list[ind1];
            list[ind1] = list[ind2];
            list[ind2] = tmp;
        }
        
        /// <summary>
        /// Sorts the list <paramref name="list"/> using the comparison function <paramref name="compare"/>.
        /// </summary>
        /// <param name="list">a list of int.</param>
        /// <param name="compare">a boolean function comparing two int.</param>
        public static void sortList(List<int> list, MyComp compare)
        {
            for (int i = list.Count; i > 0; i--)
            {
                for (int j = 1; j < i; j++)
                {
                    if (compare(list[j - 1], list[j]))
                        swap(list, j - 1, j);
                }
            }
        }
    }
}