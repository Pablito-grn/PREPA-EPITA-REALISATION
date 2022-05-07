using System;
using System.Security;

namespace Patronus
{
    public static class Patronus
    {
        public static void PrintBoard(char[,] board, int height, int width)
        {
            for (int i = 0; i < height; i++)
            {
                if (i < 10)
                    Console.Write(i + "     |");
                else
                    Console.Write(i + "    |");
                
                for (int j = 0; j <width; j++)
                {
                    Console.Write(board[i,j]);
                }
                
                Console.WriteLine("|");
            }
        }

        public static void DrawSquare(char[,] board, int x, int y, int size)
        {
            int large = x + size;
            int haut = y + size;
            int l = board.GetLength(1); 
            
            // on recupere la taille d'une ligne du tableau pour la comparer a la largeur
            for (int i = y; i < haut; i++) 
                for (int j = x; j < large; j++) 
                    board[i,j] = 'X';
                 
        }


        public static int GetMaxSquareAt(char[,] board, int x, int y)
        {
            int cote = 0, large = board.GetLength(1);

            // je calcule la longeur de la ligne 1
            
            for (int i = x; i < large; i++)
            {
                if (board[y, i] == '.')
                    cote++;
                else
                    break;
            } 
            // je teste si la longeur de la ligne 1 rentre dans les ligens suivantes sinon je dimminue  la longeur et recommence a la ligne 1
             
            for (int j = y; j < (y + cote); j++)
                for (int i = x; i < (x + cote); i++)
                    if (board[j, i] != '.')
                    {
                        cote--;
                        j = y-1;
                        break;
                    }
            return cote;
        }
        
        public static int GetMaxSquare(char[,] board, ref int maxX, ref int maxY)
        {
            int h = board.GetLength(1), l = board.GetLength(1);
            int xtemp = 0, ytemp = 0, sizetemp = 0;

            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < l; i++)
                {
                    var temp = GetMaxSquareAt(board, i, j);
                    if (temp > sizetemp)
                    {
                        sizetemp = temp;
                        xtemp = i;
                        ytemp = j;
                    }
                }
            }

            maxX = xtemp;
            maxY = ytemp;

            return sizetemp;
        }

        public static void PrintPatronus(char[,] board)
        {
            int x = 0, y = 0, size = GetMaxSquare(board, ref x, ref y);
            DrawSquare(board, x, y, size);

            string[] patronus = new []{"Muggle", "Mouse", "Car", "Dog", "Racoon", "Firecracker Scroutt", "Doe", "Deer","Phoenix"};
            
            if (size > 8)
                Console.WriteLine("Your patronus is " + patronus[8]);
            else if (size == 0)
                Console.WriteLine("You don’t have a patronus, you are a " + patronus[0]);
            else
                Console.WriteLine("Your patronus is " + patronus[size]);
        }
    }
}
