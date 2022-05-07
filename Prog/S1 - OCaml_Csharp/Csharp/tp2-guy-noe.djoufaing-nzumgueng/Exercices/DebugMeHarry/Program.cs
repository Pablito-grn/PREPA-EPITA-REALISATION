using System;
using System.Collections.Generic;

namespace DebugMeHarry
{
    class Program
    {
        static void Main() // THIS FUNCTION DOES NOT HAVE ANY PROBLEM
        {
            var rnd = new Random(); // Initialize a random to generate the list
            ConsoleColor dflt = Console.ForegroundColor; // Keep in memory what was the color of your console
            /* The goal of changing colors is for you to see what depends on your list, and what does not */
            
            /* -- USER INTERFACE -- */
            
            Console.ForegroundColor = ConsoleColor.DarkRed; // i'M sOOoO DaRk
            Console.WriteLine("Hello World!");
            Console.WriteLine("Welcome to my sorted list generator!");
            Console.Write("Please write a size for your new list (enter 0 for default list): ");
            
            Console.ForegroundColor = dflt;
            string input = Console.ReadLine(); // It lets you enter a number for the size of the list
            int input_num = int.Parse(input); // It parses the string we got to get our number

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine("Thank you ! I'm generating your new list.");
            List<int> list;
            if (input_num == 0) // If you asked for the default list
            {
                list = new List<int> {50, 2, 3, 46, 8, 13, 265, 4, 14, 9123, 25, 42, 0, 1, 49, 503, 8023};
            }
            else // If you asked for a specific number of elements
            {
                list = new List<int>();
                for (int i = 0; i < input_num; ++i)
                {
                    int n = rnd.Next(input_num * 5); // This gets a number in [0, input_num * 5[
                    list.Add(n); // Adds the number to the list
                }
            }

            Console.WriteLine("Here is your list before sorting:");
            Console.ForegroundColor = dflt;
            DebugMeHarry.printList(list); // This function prints the list in parameter
            
            /* -- MAIN PART OF THE PROGRAM -- */
            /* IT EXECUTES THE REQUIRED TESTS */
            
            DebugMeHarry.sortList(list, DebugMeHarry.evenSort); // Sort your list by comparing thanks to evenSort function
            
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine("EvenSort:");
            Console.WriteLine("Want something like: \n[ 50, 2, 46, 8, 4, 14, 42, 0, 3, 13, 265, 9123, 25, 1, 49, 503, 8023 ]");
            Console.WriteLine("(Even numbers are at the left, and odd at the right)");
            Console.ForegroundColor = dflt;
            Console.Write("Your result: \n");
            DebugMeHarry.printList(list);
            
            DebugMeHarry.sortList(list, DebugMeHarry.lowerSort); // Sort your list by comparing thanks to lowerSort function
            
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine("LowerSort:");
            Console.WriteLine("Want something like: \n[ 0, 1, 2, 3, 4, 8, 13, 14, 25, 42, 46, 49, 50, 265, 503, 8023, 9123 ]");
            Console.WriteLine("(It's just the basic sorting increasing order)");
            Console.ForegroundColor = dflt;
            Console.Write("Your result: \n");
            DebugMeHarry.printList(list);
            
            DebugMeHarry.sortList(list, DebugMeHarry.greaterSort); // Sort your list by comparing thanks to greaterSort function
            
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine("GreaterSort:");
            Console.WriteLine("Want something like: \n[ 9123, 8023, 503, 265, 50, 49, 46, 42, 25, 14, 13, 8, 4, 3, 2, 1, 0 ]");
            Console.WriteLine("(It's just the basic sorting decreasing order)");
            Console.ForegroundColor = dflt;
            Console.Write("Your result: \n");
            DebugMeHarry.printList(list);
            
            DebugMeHarry.sortList(list, DebugMeHarry.alphabeticalSort); // Sort your list by comparing thanks to alphabeticalSort function
            
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine("AlphabeticalSort:");
            Console.WriteLine("Want something like: \n[ 0, 1, 13, 14, 2, 25, 265, 3, 4, 42, 46, 49, 50, 503, 8, 8023, 9123 ]");
            Console.WriteLine("(Looks like alphabetical order in a dictionary)");
            Console.ForegroundColor = dflt;
            Console.Write("Your result: \n");
            DebugMeHarry.printList(list);
            
            /* It's the end of our incredible journey! */
        }
    }
}