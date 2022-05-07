using System;
using System.Text.RegularExpressions;

namespace StoneCloakWand
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            
            //Print.PrintMove(1, 20, 10 , false);
            //Print.PrintCloak(10, 1, false);
             int scorep1 = 0, scorep2 = 0, nbpartie = 0;
             string player1 = "", player2 = "";


             do
             {
                 Console.Write("Joueur 1 decline ton identite : ");
                 player1 = Console.ReadLine();
             } while (player1.Length == 0);
             
             Console.WriteLine();
           
             do
             {
                 Console.Write("Joueur 2 decline ton identite : ");
                 player2 = Console.ReadLine();
             } while (player2.Length == 0);
             
             Console.WriteLine();
             Console.WriteLine("Press a touch to start");
             
             Console.ReadLine();

             while (((scorep1 != 2 ) || (scorep2 != 2)) && nbpartie <3)
                 {
                     int scoremanche = PlayRound(player1, player2);
                     
                     int h = Console.GetCursorPosition().Top;
                     Console.SetCursorPosition(110, h);
                     
                     switch (scoremanche)
                     { 
                         case 1:
                             Print.PrintResult(player1);
                             scorep1++;
                             nbpartie++;
                             break;
                         
                         case 2:
                             Print.PrintResult(player2);
                             scorep2++;
                             nbpartie++;
                             break;
                         
                         case 0:
                             Print.PrintResult("");
                             break;
                     }
                     
                     Console.WriteLine();
                     Console.WriteLine();
                     Console.WriteLine();
                     Console.WriteLine();
                     
                     Console.WriteLine("Press key to continuous : ");
                     Console.ReadLine();
                 }
             
             switch (HasEnded(scorep1, scorep2))
             {
                 case 1:
                     Console.WriteLine("The winner is " + player1 + " who won the match " + scorep1 + " - " +
                                       scorep2 + " against " + player2);
                     break;
                 case 2:
                     Console.WriteLine("The winner is " + player2 + " who won the match " + scorep2 + " - " +
                                       scorep1 + " against " + player1);
                     break;
             }
 
        }

        public static int GetPlayerObject(string player)
        {
            Console.WriteLine(player + " Choose your weapon : ");
            int choix = Console.ReadLine()[0] - '0';
            
            if (choix < 0 || choix > 2)
                do
                {
                    Console.Error.WriteLine("Action has be either 0, 1 or 2 ");
                    choix = Console.ReadLine()[0] - '0';
                } while (choix < 0 || choix > 2);

            return choix;
        }

        public static int HasEnded(int p1_score, int p2_score)
        {
            int res = 0;
            if (p1_score > p2_score)
                res = 1;
            else if (p2_score > p1_score)
                res = 2;
            else
                res = 0; 
            return res;
        }

        public static int PlayRound(string p1_name, string p2_name)
        {
            int res = 0;
            Console.Clear();
            
            int p1_objet = GetPlayerObject(p1_name);
            int p2_objet = GetPlayerObject(p2_name);
            
            switch (p1_objet)
            {
                case 0:
                    switch (p2_objet)
                    {
                        case 0 : res = 0;
                            break;
                        case 1 : res = 2;
                            break;
                        default: res = 1;
                            break;
                    }
                    break;
                
                case 1:
                    switch (p2_objet)
                    {
                        case 0 : res = 1;
                            break;
                        case 1 : res = 0;
                            break;
                        default: res = 2;
                            break;
                    }
                    break;
                
                case 2:
                    switch (p2_objet)
                    {
                        case 0 : res = 2;
                            break;
                        case 1 : res = 1;
                            break;
                        default: res = 0;
                            break;
                    }
                    break;
            }
            
                        
            Print.PrintMove(p1_objet,20, 5, false);
            
            Print.PrintSeparator(120);
            
            Print.PrintMove(p2_objet, 155, 5, false);
            
            
            return res;

        }

    }
}