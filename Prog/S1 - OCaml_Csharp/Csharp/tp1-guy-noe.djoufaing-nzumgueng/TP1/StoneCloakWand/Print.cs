using System;
using Microsoft.VisualBasic;

namespace StoneCloakWand
 {
     public class Print
     {
         public static void PrintResult(string player)
         {
             if (player.Length == 0)
                 Console.WriteLine("It’s a draw");
             else 
                 Console.WriteLine(player + " won the round");
         }

         public static void PrintSeparator(int x)
         {
             int i = 0;
             while (i < 10)
             {
                 Console.SetCursorPosition(x, 20 + i);
                 Console.WriteLine("|");
                 i++;
             }
         }

         public static void PrintString(string str, int x, int y)
         {
             Console.SetCursorPosition(x, y);
             Console.Write(str);         
         }

         public static string StringReverse(string str, bool reverse)
         {
             string res = "";
             char spe_car ;
             int i = (str.Length) - 1 ;


             if (reverse == false) 
                 res = str;
             else 
                 while (i > (-1)) 
                 {  
                     switch (str[i])
                     {
                         case '<' : spe_car = '>';
                             break;
                         case ')' : spe_car = '(';
                             break;
                         case  '(': spe_car = ')';
                             break;
                         case '>' : spe_car = '<';
                             break;
                         case '[' : spe_car = ']';
                             break;
                         case ']' : spe_car = '[';
                             break;
                         case '}' : spe_car = '{';
                             break;
                         case '{' : spe_car = '}';
                             break;
                         case  '/' : spe_car = '\\';
                             break;
                         case  '\\' : spe_car = '/';
                             break;
                         
                         default: spe_car = str[i];
                             break;
                     }
                     res += spe_car; 
                     i--;
                 }
             return res;
             
         }

         public static void PrintStone(int x, int y, bool reverse)
         {
             PrintString(StringReverse("                                     &@%@&                                     ", reverse), x, y);
             PrintString(StringReverse("                                   @@&&@&&@@@                                  ", reverse), x, y + 1);
             PrintString(StringReverse("                                @@&&&@@@@@&&&@@                                ", reverse), x, y + 2);
             PrintString(StringReverse("                              @@&&@@@@@@@@@@@&&@@@                             ", reverse), x, y + 3);
             PrintString(StringReverse("                           @@&&&@@@@@@@@@@@@@@@&&&@@                           ", reverse), x, y + 4);
             PrintString(StringReverse("                         @@&&@@@@@@@@@@&@@@@@@@@@@&&@@@                        ", reverse), x, y + 5);
             PrintString(StringReverse("                      @@&&&@@@@@@@@@@&&&&@@@@@@@@@@@&&&@@                      ", reverse), x, y + 6);
             PrintString(StringReverse("                    @@&&@@@@@@@@@@@@&&&&@&&@@@@@@@@@@@@&&@@                    ", reverse), x, y + 7);
             PrintString(StringReverse("                 @@&&&@@@@@@@@@@@@@&&@&&@@&&@@@@@@@@@@@@@&&&@@                 ", reverse), x, y + 8);
             PrintString(StringReverse("               @@&&@@@@@@@@@@@@@@&&@@@&&@@@@&&@@@@@@@@@@@@@@&&@@               ", reverse), x, y + 9);
             PrintString(StringReverse("            @@&&&@@@@@@@@@@@@@@@&&@@&&&&&&&@@&&@@@@@@@@@@@@@@@&&&@@            ", reverse), x, y + 10);
             PrintString(StringReverse("          @@&&@@@@@@@@@@@@@@@@&&&&&@@@&&@@@@&&&&&@@@@@@@@@@@@@@@@&&@@          ", reverse), x, y + 11);
             PrintString(StringReverse("       @@&&&@@@@@@@@@@@@@@@@@&&@@@@@@@&&@@@@@@@@&&@@@@@@@@@@@@@@@@@&&&@@       ", reverse), x, y + 12);
             PrintString(StringReverse("     @@&%@@@@@@@@@@@@@@@@@@&&&@@@@@@@@&&@@@@@@@@@&&@@@@@@@@@@@@@@@@@@@&&@@     ", reverse), x, y + 13);
             PrintString(StringReverse("  @@&&&@@@@@@@@@@@@@@@@@@@&&&@@@@@@@@@&&@@@@@@@@@@&&&@@@@@@@@@@@@@@@@@@@&&&@@  ", reverse), x, y + 14);
             PrintString(StringReverse("@@%%&@@@@@@@@@@@@@@@@@@@&%&%%@@@@@@@@@@&@@@@@@@@@@&&&&@@@@@@@@@@@@@@@@@@@@&&&@@", reverse), x, y + 15);
             PrintString(StringReverse("  @@@%&@@@@@@@@@@@@@@@@%%@@%%@@@@@@@@@@%@@@@@@@@@@%%@@%%@@@@@@@@@@@@@@@@%%&@@  ", reverse), x, y + 16);
             PrintString(StringReverse("     @@%&&@@@@@@@@@@@&%&@@@@%%@@@@@@@@@%@@@@@@@@@&%@@@@%%@@@@@@@@@@@@&%%@@     ", reverse), x, y + 17);
             PrintString(StringReverse("       @@&%%@@@@@@@@%%@@@@@@@&%%@@@@@@@%@@@@@@@&%%@@@@@@&%&@@@@@@@@%%&@@       ", reverse), x, y + 18);
             PrintString(StringReverse("          @@%&&@@@@%%@@@@@@@@@@@%%%&@@@&@@@@&%%&@@@@@@@@@@%%@@@@@&%@@          ", reverse), x, y + 19);
             PrintString(StringReverse("            @@&%%&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&%%&@@            ", reverse), x, y + 20);
             PrintString(StringReverse("               @@%%&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&%%@@               ", reverse), x, y + 21);
             PrintString(StringReverse("                 @@&%%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%%&@@                 ", reverse), x, y + 22);
             PrintString(StringReverse("                    @@%%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%%@@                    ", reverse), x, y + 23);
             PrintString(StringReverse("                      @&%%@@@@@@@@@@@@@@@@@@@@@@@@@%%&@@                       ", reverse), x, y + 24);
             PrintString(StringReverse("                         @@%%@@@@@@@@@@@@@@@@@@@@&%%@@                         ", reverse), x, y + 25);
             PrintString(StringReverse("                           @&%&@@@@@@@@@@@@@@@%%&@@                            ", reverse), x, y + 26);
             PrintString(StringReverse("                              @&%&@@@@@@@@@@@%%@@                              ", reverse), x, y + 27);
             PrintString(StringReverse("                                 @%%&@@@@@&&&@&                                ", reverse), x, y + 28);
             PrintString(StringReverse("                                   @&&%@&%@@                                   ", reverse), x, y + 29);
             PrintString(StringReverse("                                     &@%@&                                     ", reverse), x, y + 30);
         }

         public static void PrintCloak(int x, int y, bool reverse)
         {
             PrintString(StringReverse("                                 @@@@@@@@@@@@@@@                                ", reverse), x, y);
             PrintString(StringReverse("                           ,@@@@@@             @@@@@@                           ", reverse), x, y + 1);
             PrintString(StringReverse("                          @@@@(       @@@@&       @@@@@                         ", reverse), x, y + 2);
             PrintString(StringReverse("                         @@@@     .@@@@@@@@@@@      @@@@                        ", reverse), x, y + 3);
             PrintString(StringReverse("                        @@@@     @@@@&     @@@@@     @@@@                       ", reverse), x, y + 4);
             PrintString(StringReverse("                       @@@@     @@@@         @@@@    .@@@/                      ", reverse), x, y + 5);
             PrintString(StringReverse("                        @@@@    (@@@@       @@@@     @@@@                       ", reverse), x, y + 6);
             PrintString(StringReverse("                        /@@@@     @@@@@@@@@@@@@     @@@@                        ", reverse), x, y + 7);
             PrintString(StringReverse("                          @@@@.     /@@@@@@@.     &@@@@                         ", reverse), x, y + 8);
             PrintString(StringReverse("                           #@@@@@               @@@@@                           ", reverse), x, y + 9);
             PrintString(StringReverse("                       @@@@@@@@@@@#           @@@@@@@@@@@%                      ", reverse), x, y + 10);
             PrintString(StringReverse("                    @@@@@@@,                         /@@@@@@@                   ", reverse), x, y + 11);
             PrintString(StringReverse("                 (@@@@@                                   @@@@@                 ", reverse), x, y + 12);
             PrintString(StringReverse("                @@@@%                @@@@@@#                @@@@@               ", reverse), x, y + 13);
             PrintString(StringReverse("              /@@@@                @@@@@*@@@@(                @@@@              ", reverse), x, y + 14);
             PrintString(StringReverse("             #@@@@                @@@@    ,@@@@                @@@@.            ", reverse), x, y + 15);
             PrintString(StringReverse("           .@@@@               ,@@@@         @@@@                @@@@           ", reverse), x, y + 16);
             PrintString(StringReverse("           @@@@                @@@@           @@@@                @@@@          ", reverse), x, y + 17);
             PrintString(StringReverse("          @@@@                @@@@             @@@@               /@@@%         ", reverse), x, y + 18);
             PrintString(StringReverse("         @@@@               /@@@,               @@@@.               @@@@        ", reverse), x, y + 19);
             PrintString(StringReverse("        %@@@.               @@@@                 @@@@               &@@@,       ", reverse), x, y + 20);
             PrintString(StringReverse("       @@@@               &@@@                    ,@@@*               @@@@      ", reverse), x, y + 21);
             PrintString(StringReverse("     ,@@@(               *@@@,                     %@@@                @@@@     ", reverse), x, y + 22);
             PrintString(StringReverse("     @@@@                @@@@                       @@@@                @@@@    ", reverse), x, y + 23);
             PrintString(StringReverse("    %@@@.                @@@@                       @@@@                %@@@,   ", reverse), x, y + 24);
             PrintString(StringReverse("    @@@@                *@@@,                       %@@@                 @@@@   ", reverse), x, y + 25);
             PrintString(StringReverse("   @@@@                 @@@@                         @@@#                 @@@%  ", reverse), x, y + 26);
             PrintString(StringReverse("  *@@@#                 @@@@                         @@@@                 @@@@  ", reverse), x, y + 27);
             PrintString(StringReverse("  @@@@                  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                  @@@@ ", reverse), x, y + 28);
             PrintString(StringReverse(",@@@(                  (@@@.                         (@@@.                  @@@@", reverse), x, y + 29);
             PrintString(StringReverse("&@@@.                  @@@@                          .@@@*                  (@@@", reverse), x, y + 30);
             PrintString(StringReverse("     @@@@@@/           @@@@                           @@@@           %@@@@@@    ", reverse), x, y + 31);
             PrintString(StringReverse("        @@@@@@@@*      @@@@                           @@@@      /@@@@@@@%       ", reverse), x, y + 32);
             PrintString(StringReverse("            (@@@@@@@@@@@@@@                           @@@@@@@@@@@@@@*           ", reverse), x, y + 33);
             PrintString(StringReverse("                  /@@@@@@@&                           @@@@@@@@,                 ", reverse), x, y + 34);
         }

         public static void PrintWand(int x, int y, bool reverse)
         {
             PrintString(StringReverse("  _                                     ", reverse), x, y);
             PrintString(StringReverse(" \\\\                                   ", reverse), x, y + 1);
             PrintString(StringReverse("  \\\\                                  ", reverse), x, y + 2);
             PrintString(StringReverse("   \\\\                                 ", reverse), x, y + 3);
             PrintString(StringReverse("    \\\\                                ", reverse), x, y + 4);
             PrintString(StringReverse("     \\\\                               ", reverse), x, y + 5);
             PrintString(StringReverse("      \\\\                              ", reverse), x, y + 6);
             PrintString(StringReverse("       \\\\                             ", reverse), x, y + 7);
             PrintString(StringReverse("        \\\\                            ", reverse), x, y + 8);
             PrintString(StringReverse("         \\\\                           ", reverse), x, y + 9);
             PrintString(StringReverse("          \\\\                          ", reverse), x, y + 10);
             PrintString(StringReverse("           \\\\                         ", reverse), x, y + 11);
             PrintString(StringReverse("            \\\\                        ", reverse), x, y + 12);
             PrintString(StringReverse("             \\\\                       ", reverse), x, y + 13);
             PrintString(StringReverse("              \\\\                      ", reverse), x, y + 14);
             PrintString(StringReverse("               \\\\                     ", reverse), x, y + 15);
             PrintString(StringReverse("                \\\\                    ", reverse), x, y + 16);
             PrintString(StringReverse("                 \\\\                   ", reverse), x, y + 17);
             PrintString(StringReverse("                  \\\\                  ", reverse), x, y + 18);
             PrintString(StringReverse("                   \\\\                 ", reverse), x, y + 19);
             PrintString(StringReverse("                    \\\\                ", reverse), x, y + 20);
             PrintString(StringReverse("                     \\\\               ", reverse), x, y + 21);
             PrintString(StringReverse("                      \\\\              ", reverse), x, y + 22);
             PrintString(StringReverse("                       \\\\             ", reverse), x, y + 23);
             PrintString(StringReverse("                        \\\\            ", reverse), x, y + 24);
             PrintString(StringReverse("                         \\\\           ", reverse), x, y + 25);
             PrintString(StringReverse("                          \\\\          ", reverse), x, y + 26);
             PrintString(StringReverse("                           \\\\         ", reverse), x, y + 27);
             PrintString(StringReverse("                            \\\\        ", reverse), x, y + 28);
             PrintString(StringReverse("                             \\\\       ", reverse), x, y + 29);
             PrintString(StringReverse("                              \\\\      ", reverse), x, y + 30);
             PrintString(StringReverse("                               \\\\     ", reverse), x, y + 31);
             PrintString(StringReverse("                                ###  ", reverse), x, y + 32);
             PrintString(StringReverse("                                 ### ", reverse), x, y + 33);
             PrintString(StringReverse("                                  ###", reverse), x, y + 34);

         }



         public static void PrintMove(int obj, int x, int y, bool reverse)
         {
             if (obj == 0)
                 PrintStone(x, y, reverse);
             else if(obj == 1)
                 PrintCloak(x, y, reverse);
             else
                 PrintWand(x, y, reverse);
         }
     }
 }
