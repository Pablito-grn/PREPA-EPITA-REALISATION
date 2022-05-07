using System;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            //--. --- - --- -.. .. ...- .. -. .- - .. --- -. .-. --- --- --
            //"BWP LVD ZZSNW BCM AEQB CAH QN QA TAM YVWKCMA WBBV GKM ZTSEL
            //string test = Vigenere.Vigenere_decode("BWP LVD ZZSNW BCM AEQB CAH QN QA TAM YVWKCMA WBBV GKM ZTSEL", "CODE");
            //string test2 = Vigenere.Vigenere_encode("This TP is the best", "info");
            
            //int[] test = Transposition.Permutation_rule("Authority");
            
            char[,] test2 = Transposition.Create_table_encrypt("WE ARE ALL TOGETHER ", "GOAL", 5);

            char[,] test  = Transposition.Create_table_decrypt("CTARMEYOGTRILISNPNOH", "GOAL", 5);
            
            string test3 = Transposition.Permutation_decrypt("CTARMEYOGTRILISNPNOH", "GOAL");
            
            string test4 = Transposition.Permutation_encrypt("WEAREALLTOGETHER", "GOAL");

            foreach (var c in test2)
            {
                Console.Write(c);
            }


        }
    }
}