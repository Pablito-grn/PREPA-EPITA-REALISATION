using System;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
        }
                
        public static void HelloWho(string str)
        {
            if (str.Length == 0)
                str = "World";
            
            Console.WriteLine("Hello " +str+ " !");
        }

        public static void PrintMany(string str, int n)
        {
            if (n < 0 )
                Console.Error.WriteLine("n must be positive");
            else
                while (n > 0)
                {
                    Console.WriteLine(str);
                    n -= 1;
                }
        }

        public static int Facto(int n)
        {
            int fact = 1;
            if (n < 0)
            {
                Console.Error.WriteLine("n must be positive");
                fact = (-1);
            }
            else
            {
                if (n == 0)
                    fact = 1;
                else
                    while (fact < n)
                        fact *= (fact + 1);
            }
            return fact;
        }

        public static int Fibonacci(int n)
        {
            int res = 0;
            if (n < 0)
            {
                Console.Error.WriteLine("n must be positive");
                res = (-1);
            }
            else
            {
                while (n > 0)
                {
                    res += n;
                    n--;
                }                
            }
            
            Console.WriteLine(res);
            return res;
        }

        public static int DivisorSum(int n)
        {
            int sum = 0, div = 1;
            
            if (n <= 0)
            {
                Console.Error.WriteLine("n must be strictly positive");
                sum = -1;
            }
            else
            {
                while (div < n)
                {
                    if ((n % div) == 0)
                        sum += div;
                    
                    div++;
                }
            }
            
            Console.WriteLine(sum);
            return sum;
        }

        public static int conversion(string str, int i)
        {
            int conv = 0;
            while (i < str.Length)
            {
                if ((str[i] < '0') || (str[i] > '9'))
                {
                    Console.Error.WriteLine("Invalid number '"+ str + "'");
                    return 0;
                }
                else
                    conv = conv*10 + (str[i] - '0');
                i++;
            }
            return conv;
        }
        
        public static int StringToNumber(string str)
        { 
            int result = 0;
            
            if (str.Length == 0)
            {
                result = 0;
                Console.Error.WriteLine("Invalid number ''");
            }
            else
            {
                if (str[0] == '-')
                    result = -(conversion(str, 1));
                else
                    result = conversion(str, 0);
            }
            
            Console.WriteLine(result);
            return result;
        }

        public static void PrintIsPerfectNumber()
        {
            string usrInput = Console.ReadLine();
            int usrNbr = StringToNumber(usrInput);
            if (DivisorSum(usrNbr) == usrNbr)
                Console.WriteLine("Yes :) ");
            else
                Console.WriteLine("No :( ");

            Console.WriteLine(usrInput);
        }
        
        
    }
}