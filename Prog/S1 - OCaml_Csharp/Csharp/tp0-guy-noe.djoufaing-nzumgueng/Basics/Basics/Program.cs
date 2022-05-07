using System;
using System.IO;

namespace Basics
{


    class Program
    {
        static void Main(string[] args)
        {
        }

        
        public static void HappyBirthday()
        {
            Console.WriteLine("Happy Birthday Harry !");
        }

        public static void HappyBirthdayAdvanced(string name)
        {
            Console.WriteLine("Happy Birthday " + name + " !");
        }

        public static uint SentLetters(uint owls)
        {
            uint nbr_lettre = 0;
            if (owls > 0)
                nbr_lettre = owls + SentLetters(owls - 1);
            else
                nbr_lettre = 0;
            
            return nbr_lettre;
        }


        public static string SortingHat(uint n)
        {
            string ChoixPita = "";
            switch (n%4)
            {
                case 0 :
                    ChoixPita = "Gryffindor";
                    break;
                case 1 :
                    ChoixPita = "Hufflepuff";
                    break;
                case 2 :
                    ChoixPita = "Ravenclaw";
                    break;
                case 3 :
                    ChoixPita = "Slytherin.";
                    break;
                default:
                    Console.WriteLine("Division par 4 impossible");
                    break;
            }
            
            return ChoixPita;
        }

        public static void QuidditchWinner(string house1, uint score1, string house2, uint score2)
        {
            if (score1 > score2)
                Console.WriteLine(house1 + " wins by " + (score1 - score2) + "points");
            else if (score1 < score2)
                Console.WriteLine(house2 + " wins by " + (score2 - score1) + "points");
            else
                Console.WriteLine(" It's a tie!");
        }

        public static bool IsDigit(char c)
        {
            int nbr_lettre = (int) c;
            bool test ;
            
            if (nbr_lettre >= 0 && nbr_lettre < 128)
                test = true;
            else
                test = false;
            
            return test;
        }

        public static bool IsAlpha(char c)
        {
            int nbr_lettre = (int) c;
            bool test;
            
            if ((nbr_lettre > 64 && nbr_lettre < 91) || (nbr_lettre > 96 && nbr_lettre < 123))
                test = true;
            else
                test = false;
            return test;
        }

        public static char ToUpper(char c)
        {
            int nbr_lettre = (int) c;
            char result;

            if (nbr_lettre > 64 && nbr_lettre < 91)
                 result = c;
            else
                result = (char) (nbr_lettre - 27);
            
            return result;
            
        }
        
    }
    
    


    }
