using System;

namespace Basics
{
    public class Reference
    {
        // Swaps two variables
        // i create temporation variable (temp) to swap element
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }



        // Returns the floor part of a float
        // and replaces the value of the variable by its decimal part
        public static int Trunc(ref float f)
        {
            int res = 0, temp1 = 0;
            
            if (f < 0)
                res = (-1);

            else
            {
                res = (int) f;
                f = f - res; 
            }
            return res;
        }

        // Rotates a char n times
        // I create a function to test if x in a char or a number
        public static char wheel(char c, int n, char min, char max)
        {
            bool neg = false;
            int ci = (int) c;
            int maxi = (int) max;
            int mini = (int) min;

            if (n < 0)
            {
                n = (-n);
                neg = true;
            }

            while (ci + n > maxi)
                n = min + n - maxi - 1;

            if (neg == true)
                c = (char) (ci - n);
            else
                c = (char) (ci + n);
            
            Console.Write(c + "  ");
            return c;
        }

        public static void RotChar(ref char c, int n)
        {
            if (c >= '0' && c <= '9')
                wheel(c, n, '0', '9');
            
            else if (c >= 'A' && c <= 'Z')
                wheel(c, n, 'A', 'Z');
            
            else if (c >= 'a' && c <= 'z')
                wheel(c, n, 'a', 'z');

            else
                Console.Error.Write("Invalid argument, please respect the input");
        }

        public static void RotN(char[] arr, int n)
        {
            int l = arr.Length;
            char[] arr1 = new char[l];

            for (int i = 0; i < l; i++)
                RotChar(ref arr[i], n);
            
        }
    }
}