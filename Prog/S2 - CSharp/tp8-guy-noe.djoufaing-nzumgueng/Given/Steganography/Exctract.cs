using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace Steganography
{
    public class Exctract
    {
        public static int[] ExtractMsg(Bitmap image, int length)
        {
            length = 8 * length;
            int[] res = new int[length];
            int h = image.Height, w = image.Width;
            Color pixel1, pixel2;
            int nbBits, msg;
            int index = 0;

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j + 1 < h; j += 2)
                {
                    pixel1 = image.GetPixel(i, j);
                    pixel2 = image.GetPixel(i, j+1);
                    
                    nbBits = Utils.SaveLSB(pixel2.R, 3);
                    msg = Utils.SaveLSB(pixel1.R, nbBits);
                    Utils.InsertBits(res, index, nbBits, msg);
                    index += nbBits;
          
                    if (index > length)
                        return res;
                }
            }
            return res;
        }
    }
}