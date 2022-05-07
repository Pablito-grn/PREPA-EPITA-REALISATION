using System;

namespace Crypto
{
    public class Transposition
    {
        public static int[] Permutation_rule(string key)
        {
            int keyLenght = key.Length;
            int[] res = new int[keyLenght];
            int j = 0, cpt = 1;

            key = key.ToUpper();
            for (int i = 65; i < 91; i++)
            {
                for (int ltr = 0; ltr < keyLenght; ltr++)
                {
                    if ((int) key[ltr] == i)
                    {
                        res[ltr] = cpt;
                        cpt++;
                    }
                }
            }

            return res;
        }

        public static char[,] Create_table_encrypt(string message, string key, int size)
        {
            int keyLenght = key.Length;
            int messageLenght = message.Length;
            int[] ordre = Permutation_rule(key);
            
            int ordreLenght = ordre.Length, i = 0;
            int cptMsg = 0;
            char[,] matrcice = new char[size , keyLenght];
            

            do
            {
                for (int j = 0; j < ordreLenght; j++)
                {
                    if (j == i)
                    {
                        for (int k = 0; k < size-1; k++)
                        {
                            matrcice[j, k] = message[cptMsg];
                            cptMsg++;
                        }
                    }
                }

                i++;
            } while (i < keyLenght);

            return matrcice;
        }
        
        public static string Permutation_encrypt(string message, string key)
        {
            int keyLenght = key.Length, i = 0;
            int temp = 0;
            int[] ordre = Permutation_rule(key);
            string res = "";
            char[,] matrice = Create_table_encrypt(message, key, 5);

            do
            {
                temp = Array.IndexOf(ordre, i+1);
                
                for (int j = 0; j < 5; j++)
                    res += matrice[j, temp];
                
                i++;
            } while (i<keyLenght);

            return res;
        }

        
        
        
        
        
        
        
        public static char[,] Create_table_decrypt(string message, string key, int size)
        {
            int keyLenght = key.Length, e= 0, i = 0;
            int messageLenght = message.Length, temp = 0;
            int[] ordre = Permutation_rule(key);
            
            char[,] matrice = new char[size , keyLenght];

            do
            {
                temp = Array.IndexOf(ordre, i+1);
                
                for (int j = 0; j < size; j++)
                {
                    matrice[j, temp] = message[e];
                    e++;
                }

                i++;
            } while (i<keyLenght);
            
            return matrice;
        }
        
        public static string Permutation_decrypt(string message, string key)
        {
            char[,] matrice = Create_table_decrypt(message, key, 5);
            string res = "";
            
            foreach (var c in matrice)
                res += c;
            
            return res;
        }
    }
}
