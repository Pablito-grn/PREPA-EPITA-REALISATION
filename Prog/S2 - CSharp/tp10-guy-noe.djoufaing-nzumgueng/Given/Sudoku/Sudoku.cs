using System;
using System.Text.RegularExpressions;

namespace WWW
{
    public class Sudoku
    {
        public int[,] grid;

        /// <summary>
        /// Initialize the grid with the given
        /// Here is an example of a grid: "...26.7.168..7..9.19...45..82.1...4...46.29...5...3.28..93...74.4..5..367.3.18..."
        /// </summary>
        /// <param name="str"> Represents the grid </param>
        public Sudoku(string str)
        {
            if (str.Length != 81)
                throw new ArgumentException();

            grid = new int[9, 9];

            int c = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int car = (int) str[c];

                    if ((car != '.') && ((car < '0') || (car > '9')))
                        throw new ArgumentException();

                    if (str[c] == '.')
                        grid[i, j] = 0;

                    else
                        grid[i, j] = str[c] - '0';


                    c++;
                }
            }

        }

        /// <summary>
        /// Prints the grid on the console
        /// </summary>
        public void print() // a refaire
        {

            for (int i = 0; i < 9; i++)
            {
                if (i%3 == 0)
                    Console.WriteLine("-------------------------------");
                
                Console.Write("|");

                for (int j = 0; j < 9; j++)
                {
                    if (j > 0 && j % 3 == 0)
                        Console.Write("|");

                    Console.Write(grid[i, j] != 0 ? " " + grid[i, j] + " " : "   ");
                    if(j == 8)
                        Console.Write("|");

                }
                
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------");

        }
        

        /// <summary>
        /// Returns true if the given column is solved
        /// </summary>
        /// <param name="x"> index of the column</param>
        public bool is_column_solved(int x)
        {
            (int, int)[] tableauTest = new (int, int)[]
                {(1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (7, 0), (8, 0), (9, 0)};
            
            int nb;

            for (int i = 0; i < 9; i++)
            {
                nb = grid[x, i];
                if ((nb == 0) || tableauTest[nb - 1] != (nb, 0))
                    return false;
                else
                    tableauTest[nb - 1] = (nb, 1);
            }

            return true;
        }

        /// <summary>
        /// Returns true if the given line is solved
        /// </summary>
        /// <param name="y"> index of the line</param>
        public bool is_line_solved(int y)
        {
            (int, int)[] tableauTest = new (int, int)[]
                {(1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (7, 0), (8, 0), (9, 0)};
            
            int nb;

            for (int i = 0; i < 9; i++)
            {
                nb = grid[i, y];
                if ((nb == 0) || tableauTest[nb - 1] != (nb, 0))
                    return false;
                else
                    tableauTest[nb - 1] = (nb, 1);
            }

            return true;
        }

        /// <summary>
        /// Returns true if the 3x3 square containing the given coords is solved
        /// </summary>
        /// <param name="x"> index of the column</param>
        /// <param name="y"> index of the line</param>
        public bool is_square_solved(int x, int y)
        {
            (int, int)[] tableauTest = new (int, int)[]
                {(1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (7, 0), (8, 0), (9, 0)};
            int nb;

            for (int i = x; i < x + 3; i++)
            {
                for (int j = y; j < y + 3; j++)
                {
                    nb = grid[i, j];

                    if ((nb == 0) || tableauTest[nb - 1] != (nb, 0))
                        return false;
                    else
                        tableauTest[nb - 1] = (nb, 1);
                }
            }

            return true;
        }

        /// <summary>
        /// Returns true the grid is solved
        /// Here is a exemple of a solved grid : 435269781682571493197834562826195347374682915951743628519326874248957136763418259
        /// </summary>
        public bool is_solved()
        {
            bool isSolved;
            bool isSolved2;


            for (int i = 0; i < 9; i++)
            {
                isSolved = is_column_solved(i);
                isSolved2 = is_line_solved(i);

                if (!isSolved || !isSolved2)
                    return false;
            }

            return true;

        }

        /// <summary>
        /// Returns true if the given column already contains the given value
        /// </summary>
        /// <param name="x"> index of the column</param>
        /// <param name="val"> value that must be checked</param>
        public bool already_in_column(int x, int val)
        {
            for (int i = 0; i < 9; i++)
            {
                if (grid[x, i] == val)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Returns true if the given line already contains the given value
        /// </summary>
        /// <param name="y"> index of the line</param>
        /// <param name="val"> value that must be checked</param>
        public bool already_in_line(int y, int val)
        {
            for (int i = 0; i < 9; i++)
            {
                if (grid[i, y] == val)
                    return true;
            }

            return false;

        }

        /// <summary>
        /// Returns true if the 3x3 square containing the given already contains the given value
        /// </summary>
        /// <param name="x"> index of the column</param>
        /// <param name="y"> index of the line</param>
        /// <param name="val"> value that must be checked</param>
        public bool already_in_square(int x, int y, int val)
        {
            for (int i = 0; i < 9; i++)
            {
                if (grid[3 * (x / 3) + i / 3, 3 * (y / 3) + i % 3] != '.' &&
                    grid[3 * (x / 3) + i / 3, 3 * (y / 3) + i % 3] == val) ;
            }
                
            //for (int i = x; i < x + 3; i++)
            //    for (int j = y; j < y + 3; j++)
            //        if (grid[i, j] == val)
            //            return true;
            
            return true;
        }

    



    public bool solve_rec()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (grid[i, j] == 0)
                {
                    for (int k = 1; k < 10; k++)
                    {
                        if (canAdd(i, j, k))
                        {
                            grid[i, j] = k;
                            if (solve_rec())
                                return true;
                            grid[i, j] = 0;
                        }
                    }
                    return false;
                }
            }
        }

        return true;
    }

    public bool canAdd(int x, int y, int val)
    {
        if (already_in_column(x, val) || already_in_line(y, val))
            return false;
        
       // x = x > 0 ? (x % 3) : 0 ;
       // y = y > 0 ? (y % 3) : 0 ;

        if (already_in_square(x, y, val))
            return false;

        
        return true;
    }
    /// <summary>
    /// Solves the grid
    /// </summary>
    public void solve()
    {
        solve_rec();
    }
}

}
