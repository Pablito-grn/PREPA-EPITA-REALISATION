using System;
using System.Diagnostics;

namespace Morpion
{
    public class Game
    {

        public char[][] tableArray = new[] {new char[3], new char[3], new char[3]};

        public static uint __depth;

        public int valuePlateau = 0;
        // 0 1 2
        // 3 4 5
        // 6 7 8
        
        // display of the game with the numbers corresponding to the boxes
        // the display is shifted to the right in case you wish to display the board of the current game to its left
        void positions()
        {
            if (!Console.IsOutputRedirected)
            {
                int y = 0;
                Console.SetCursorPosition(20, y++);
                Console.WriteLine(" ___________");
                for (int i = 0; i < 3; i++)
                {
                    Console.SetCursorPosition(20, y++);
                    Console.WriteLine("| {0} | {1} | {2} |", i * 3, i * 3 + 1, i * 3 + 2);
                    Console.SetCursorPosition(20, y++);
                    Console.WriteLine("|___________|");
                }
            }
        }
        
        public void __PrintPositions()
        {
            if (!Console.IsOutputRedirected)
            {
                int y = 0;
                Console.SetCursorPosition(80, y++);
                Console.WriteLine(" ___________");
                for (int i = 0; i < 3; i++)
                {
                    Console.SetCursorPosition(80, y++);
                    Console.WriteLine("| {0} | {1} | {2} |", tableArray[i][0], tableArray[i][1], tableArray[i][2]);
                    Console.SetCursorPosition(80, y++);
                    Console.WriteLine("|___________|");
                }
            }
        }
        
        public static Game load_game(String board, uint depth)
        {
            Game game = new Game();

            __depth = depth;
            if (board.Length != 0)
            {
                int c = 0;
                
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        game.tableArray[i][j] = board[c];
                        c++;
                    }
                }
            }

            return game; 
        }
        
        
        // return the state of the board,
        // if there is a winner, draw or if the game is not over
        // 2 -> IA / 1 -> Player / 3 -> Draw / 0 -> Not finish
        public int stop()
        {
            bool isEmpty = false;
            for (int i = 0; i < tableArray.Length; i++)
            {
                for (int j = 0; j < tableArray.Length; j++)
                {
                    if (tableArray[i][j]=='x')
                    {
                        __TestWin('x', (i, j));
                        return 2;
                    }

                    if (tableArray[i][j]=='o')
                    {
                        __TestWin('o', (i, j));
                        return 1;
                    }

                    if (tableArray[i][j]=='_')
                        isEmpty = true;

                }
            }
            
            if (isEmpty) return 0;
            return 3;
        }


        public int __evaluate()
        {
            return 0;
        }
        public bool __TestWin(Char c, (int, int) coordCase)
        {
            switch (coordCase)
            {
                case (0,0):
                    if (__IsSameCase(1, c) && __IsSameCase(2, c)) return true;
                    else if (__IsSameCase(3, c) && __IsSameCase(6, c)) return true;
                    else if (__IsSameCase(4, c) && __IsSameCase(8, c)) return true;
                    break;
                
                case (0,1):
                    if (__IsSameCase(4, c) && __IsSameCase(7, c)) return true;
                    break;
                case (0,2):
                    if (__IsSameCase(5, c) && __IsSameCase(8, c)) return true;
                    break;
                case (1,0):
                    if (__IsSameCase(4, c) && __IsSameCase(5, c)) return true;
                    break;
                case (2,0):
                    if (__IsSameCase(7, c) && __IsSameCase(8, c)) return true;
                    break;
            }

            return false;
        }
        
        // start a game turn
        public void play()
        {
            int caseSelectjoueur = -1 ;

            // Jeu du joueur
            do
            {
                Console.Write("Entrez un numero de case valide : ");
                caseSelectjoueur = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

                if (!__IsValidCase(caseSelectjoueur))
                    Console.WriteLine("You must play a number between 0 and 8 inclusive");
                else
                {
                    if (!__IsEmptyCase(caseSelectjoueur))
                    {
                        Console.WriteLine("The box is already taken");
                        caseSelectjoueur = -1;
                    }
                }
            } while (!__IsValidCase(caseSelectjoueur));

            tableArray[caseSelectjoueur / 3][caseSelectjoueur % 3] = 'o';

            //Jeu de l'Ia

            int caseSelectIA = __Minimax(__depth, true, __FindNextEmptyCase(tableArray)); 
            
            tableArray[caseSelectIA/ 3][caseSelectIA % 3] = 'x';
        }

        
        
        //nbCase = numero de la case
        public bool __IsValidCase(int nbCase)
        {
            return nbCase > -1 && nbCase < 9;
        }
        public bool __IsEmptyCase(int nbCase)
        {
            int i = nbCase / 3, j = nbCase % 3;
            return tableArray[i][j] == '_'; //================= Comme ca une case vide dans le tableau?
        }
        public bool __IsEmptyCase(int i, int j)
        {
            return tableArray[i][j] == '_'; //================= Comme ca une case vide dans le tableau?
        }
        public bool __IsSameCase(int nbCase, char c )
        {
            int i = nbCase / 3, j = nbCase % 3;
            return tableArray[i][j] == c;
        }

        public (int, int) __FindNextEmptyCase(char[][] table)
        {
            for (int i = 0; i < table.Length; i++)
            {
                for (int j = 0; j < table.Length; j++)
                {
                    if (table[i][j] == '_') return (i, j);
                }
            }

            throw new ApplicationException();
        }
        public string state()
        {
            string res = "";
            for (int i = 0; i < tableArray.Length; i++)
            {
                for (int j = 0; j < tableArray.Length; j++)
                {
                    res += tableArray[i][j];
                }
            }

            return res;
        }

        public int __Minimax(uint depth, bool maximizingPlayer, (int, int) nbcase)
        {
            int nodeValue = 0;
            
            if (depth == 0 || nbcase == (2,2) || stop() != 0 )
                return nodeValue;
            

            if (maximizingPlayer)
            {
                nodeValue = Int32.MinValue;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (__IsEmptyCase(i, j))
                        {
                            nodeValue = Math.Max(nodeValue, __Minimax(depth - 1, false, (i, j)));
                        }
                    }
                }
                return nodeValue;
            }
            else
            {
                nodeValue = Int32.MaxValue;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (__IsEmptyCase(i, j))
                        {
                            nodeValue = Math.Min(nodeValue, __Minimax(depth - 1, true, (i, j)));
                        }
                    }
                }
                return nodeValue;
            }
        }
    }
    
}