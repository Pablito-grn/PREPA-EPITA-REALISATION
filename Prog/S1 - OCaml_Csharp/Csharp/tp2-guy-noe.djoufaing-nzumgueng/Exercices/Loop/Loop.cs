using System;

namespace Exercice
{
    public class Loop
    {
        public static void PrintNaturals(uint n)
        {
            
            uint a = n;
            
            /*j' affiche tous les nombres jusqu'a n-1 avec des espaces et je rajoute le nombre a la fin de la grace au stockage dans a */

            for (int i = 1; i < n; i++)
            {
                Console.Write(i + " ");
            }
            Console.Write(a);

            Console.WriteLine();
        }

        public static Boolean testprimes(int n)
        {
            bool res = true;
            
            if (n == 2 || n ==3)
                res = true;
            
            else if (n % 2 == 0)
                res = false;
            
            else
                for (int a = 3; a * a <= n; a += 2)
                    if (n % a == 0)
                        res = false;
            

            return res;
        }
        
        public static void PrintPrimes(int n)
        {

            for (int i = 2; i <= n; i++)
            {
                if (i == 2)
                    Console.Write(i);
                
                else if (testprimes(i) == true)
                {
                    Console.Write(" " + i);
                }
            }
        }

        public static ulong Fibonacci(ulong n)
        {
            ulong f0 = 0,  f1 = 1,  result = 0;
            //On commence par traiter les cas n = 0 ou 1 puis on applique la formule generale avec f0 = F(n-2) et f1 = F(n-1), result = stockage du resultat .
            
            if (n == 0)
                   result = 0;
            else if (n == 1) 
                result = 1;
            else
                for (ulong i = 1; i < n; i++)
                {
                    result = f1 + f0;
                    f0 = f1;
                    f1 = result;
                }



            Console.Write(result);
            return result;
        }
        
        public static long Factorial(uint n)
        {
            long result = 1;

            if (n == 0)
                result = 1;
            else
            {
                for (int i = 1; i <= n; i++)
                    result *= i;
            }
            return result;
        }
        
        public static long Factdecimal(uint n)
        {
            long result = 0;

            while ( 0 != n)
            {
                result += Factorial(n % 10);
                n /= 10;
            }
            
            return result;
        }
            
        public static void PrintStrong(uint n)
        {
            for (uint i = 1; i <= n; i++)
            {
                if (i == 1) 
                    Console.Write(1);
                else if (Factdecimal(i) == i)
                    Console.Write(" " + i);
            }
        } 
        
        public static long Power(long a, ulong b)
        {
            long result = 1;
            if (b == 0)
                result = 1;
            else 
                for (uint i = 1; i <= b; i++) 
                    result *= a;
            
            return result;
        }

        public static bool IsArmstrong(int n)
        {
            bool test;
            
            //calcul du nombre de chiffre du nombre
            long n1 = n, n2 = n, result = 0;
            ulong i = 0;
            
            while (n1 > 0)
            {
                n1 = n1/10;
                i++;
            }
            
            //calcul de la puissance de chaque chiffre
            while ( n > 0)
            {
                result += Power((n % 10), i);
                n = n/10;
            }
            
            //test de Amstrong
            if (result == n2)
                test = true;
            else
                test = false;
            
            Console.Write(test); // je sais pas s'il faut enlever le print mais vu que c'est pas dit, je le laisse
            return test;
        }
        
        public static float Abs(float n)
        {
            float result = 0;

            if (n < 0)
                result = (-n);
            else
                result = n;
            
            return result;
        }
        
        public static float Sqrt(float n)
        {
            float X0 = Abs(n), Xn = 0, X1 = (X0/2);

            if (n < 0)
            {
                Console.Error.WriteLine("Argument must to be positive");
                return 0;
            }
            
            for (int i = 0; i <= 3; i++)
            {
                Xn = (X1 + (X0 / X1)) / 2 ;
                X1 = Xn;
            }
            Console.Write(Xn);
            return Xn;
        }
        
        public static void PrintTree(uint n)
        {
            uint es = n, st = 1; //espace , i = nombre de ligne; r = la repetition, st = les etoiles
            
            for (int i = 1 ; i <= n; i++)
            {
                    // rep ligne
                    for (int r = 0; r < 2; r++)
                    {
                        if ((i == 1) || (i == n))
                            r = 1;
                        
                        for (int j = 0; j < es; j++ )
                            Console.Write(" ");
                        
                        for (int a = 0; a < st; a++)
                            Console.Write("*");
                        
                        Console.WriteLine();
                    }
                    es -=1;
                    st += 2;
            }

            for (int a = 0; a < 2; a++)
            {
                if (n < 3)
                    a = 1;
                
                for (int i = 0; i < n; i++)
                    Console.Write(" ");
                
                Console.WriteLine("*");
            }
        }

        public static int Syracuse(uint n)
        {
            int i = 1;

            while (n != 1)
            {
                if (n % 2 == 0)
                    n /= 2;
                else
                    n = n * 3 + 1;

                i++;
            }
            
            Console.Write(i);
            return i;
        }
        
    }
}