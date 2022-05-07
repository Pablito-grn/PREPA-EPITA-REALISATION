using System;
using System.Collections.Generic;
using System.Drawing;

namespace Steganography
{
    public class Utils
    {
        // This Quantization table is used to determine the number of bits to use to hide a message in a pixel.
        public static Dictionary<int[] , int> QuantizationTable = new Dictionary<int[], int>()
        {
            { new int[] {0, 1}, 1},
            { new int[] {2, 32}, 2},
            { new int[] {33, 64}, 3},
            { new int[] {65, 255}, 4}
        };


        public static int []  ConvertToBin(int num, int nbBits)
        {
            int[] res = new int[nbBits];
            int temp;

            for (int i = nbBits-1; i >(-1); i--)
            {
                temp = num / 2;
                res[i] =  (num - 2*temp);
                num = temp;
            }

            return res;
        }

        // This function converts a string into an array of bits.
        public static int[] TextToBin(string secret)
        {
            int j = 0;
            int[] res = new int[8 * secret.Length];

            foreach (var c in secret)
            {
                int[] tab = ConvertToBin((int) c, 8);
                
                foreach (var i in tab)
                {
                    res[j] = i;
                    j++;
                }
            }

            return res;
        }

        // This function converts an array of bits into a string.
        // We consider that the array length is a multiple of 8.
        
        public static int ConvertToDec(int[] num)
        {
            int res = 0;
            int tmp;
            int len = num.Length;

            for (int i = 0; i < len ; i++)
            {
                tmp = 1;
                
                if (num[i] == 1)
                {
                    for (int j = 0; j < len-1-i; j++)
                        tmp *= 2;
                    
                    res += tmp;
                }
            }

            return res;
        }
        
        public static string BinToText(int[] bin)
        {
            int i = 0;
            int j = 0;
            int[] tab = new int[8];
            string res = "";

            
            foreach (var c in bin)
            {
                tab[i] = bin[j];
                i++;
                j++;
                
                if (i == 8)
                {
                    i = 0;
                    res += (char) ConvertToDec(tab);
                }
            }
            return res;
        }

        // This function extract the nbBits bits beginning from the index position from the secret array.
        // It is also converting the binary result into decimal.
        public static int ExtractBits(int[] secret, int index, int nbBits)
        {
            return ConvertToDec(ExtractBitsTab(secret, index, nbBits));
        }
        public static int[] ExtractBitsTab(int[] secret, int index, int nbBits)
        {
            int[] tab = new int[nbBits];
            int j = 0;
            int len = secret.Length;

            int fin = (index + nbBits) < len ? (index + nbBits) : len;
            
            for (int i = index; i < fin; i++)
            {
                tab[j] = secret[i];
                j++;
            }
            
            while (j<nbBits)
            {
                tab[j] = 0;
                j++;
            }
            return tab;
        }
        
        
        // This function translates the int value (in decimal) into binary in the secret array.
        public static void InsertBits(int[] secret, int index, int nbBits, int value)
        {
            int[] valueBin = ConvertToBin(value, nbBits);
            int[] tmp= new int[]{};
            int j = index, len = secret.Length;
            
    
            tmp = ExtractBitsTab(valueBin, 0, nbBits);
            
            foreach (var c in tmp)
            {
                if (j<len)
                {
                    secret[j] = c;
                    j++;
                }
                else
                    break;
            }
        }

        // Assuming we already have grey pixels (R = G = B).
        // This is | pixel1.R - pixel2.R |.
        public static int GetDifference(Color pixel1, Color pixel2)
        {
            int r1 = pixel1.R;
            int r2 = pixel2.R;
            return (r1 - r2) < 0 ? (r2 - r1) : (r1 - r2);
        }

        
        // This function opens an image.
        public static Bitmap OpenImage(string path)
        {
            return new Bitmap(path);
        }

        // This function saves the image into the file 'name'.
        public static void SaveImage(string name, Bitmap image)
        {
            image.Save(name);
            image.Dispose();
        }
        
        // This function clears the nbBits LSB of the int color.
        public static int ClearLSB(int color, int nbBits)
        {
            if (color <= 0)
                return color;
            color >>= nbBits;
            color <<= nbBits;
            return color;
        }
        
        // This function replaces the nbBits LSB by newLSB.
        public static int ReplaceLSB(int color, int nbBits, int newLSB)
        {
            color = ClearLSB(color, nbBits);

            return color + newLSB;
        }
        
        // This function saves ONLY the nbBits LSB of the int color.
        public static int SaveLSB(int color, int nbBits)
        {
            if (color <= 0)
                return color;
            color <<= 8 - nbBits;
            color %= 256;
            color >>= 8 - nbBits;
            return color;
        }
    }
}