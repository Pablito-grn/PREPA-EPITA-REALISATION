using System;

namespace WWW
{
    class Program
    {
        static void Main(string[] args)
        {
            string sd = "...26.7.168..7..9.19...45..82.1...4...46.29...5...3.28..93...74.4..5..367.3.18...";
            Sudoku sk = new Sudoku(sd);
            sk.print();
            sk.solve();
            sk.print();

        }
    }
}