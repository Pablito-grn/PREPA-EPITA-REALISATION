using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace HideAndSeek
{
    public enum color_type
    {
        R,
        G,
        B,
    }
    public class Seek
    {

        /// <summary>
        /// Decompress a value that was on 'n' bits to a value on 8 bits
        /// </summary>
        /// <param name="to_decompress"> The value to decompress</param>
        /// <param name="n"> On how many bits it has been compressed</param>
        /// <returns> The decompressed value</returns>
        public static int DecompressBits(int to_decompress, int n)
        {
            // on sait que 255 ( 11111111) valeur max sur 8 bits est compressé en 3 (111) valeur max sur 3 bits on peut donc effectuer un produit en croix
            int getMaxBit8 = Bits.GetMaxForNBits(8);
            int getMaxBitn = Bits.GetMaxForNBits(n);
            
            int res = to_decompress * getMaxBit8 / getMaxBitn;
            
            return res;
        }

        /// <summary>
        /// Seek a new image in the Bitmap image and in the color 'where_is_hidden' on 'n' bits
        /// </summary>
        /// <param name="image"> The image where it is hidden</param>
        /// <param name="where_is_hidden"> In which color it is hidden</param>
        /// <param name="n"> On how many bits it is hidden</param>
        /// <returns> The image found</returns>
        public static Bitmap SeekGrayScale(Bitmap image, color_type where_is_hidden, int n)
        {
            int w = image.Width, h = image.Height;
            Bitmap res = new Bitmap(w, h);
            Color pixelColor;
            int color;

            if (where_is_hidden == color_type.R)
            {
                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        pixelColor = image.GetPixel(i, j);
                        color = Bits.GetLeastSignificantBits(pixelColor.R, n);
                        color = DecompressBits(color, n);
                        
                        pixelColor = Color.FromArgb(color, color, color);
                        res.SetPixel(i, j, pixelColor);
                    }
                }
            }
            else if (where_is_hidden == color_type.G)
            {
                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        pixelColor = image.GetPixel(i, j);
                        color = Bits.GetLeastSignificantBits(pixelColor.G, n);
                        color = DecompressBits(color, n);
                        
                        pixelColor = Color.FromArgb(color, color, color);
                        res.SetPixel(i, j, pixelColor);
                    }
                }
            }
            else // (where_is_hidden == color_type.B)
            {
                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        pixelColor = image.GetPixel(i, j);
                        color = Bits.GetLeastSignificantBits(pixelColor.B, n);
                        color = DecompressBits(color, n);
                        
                        pixelColor = Color.FromArgb(color, color, color);
                        res.SetPixel(i, j, pixelColor);
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// Seek a new image in the Bitmap image on 'n' bits
        /// </summary>
        /// <param name="image"> The image where it is hidden</param>
        /// <param name="n"> On how many bits it is hidden</param>
        /// <returns> The image found</returns>
        public static Bitmap SeekColor(Bitmap image, int n)
        {
            int w = image.Width, h = image.Height;
            Bitmap res = new Bitmap(w, h);
            Color pixelColor;
            int colorR, colorG, colorB;

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    pixelColor = image.GetPixel(i, j);
                    colorR = Bits.GetLeastSignificantBits(pixelColor.R, n);
                    colorR = DecompressBits(colorR, n);
                    
                    colorG = Bits.GetLeastSignificantBits(pixelColor.G, n);
                    colorG = DecompressBits(colorG, n);
                    
                    colorB = Bits.GetLeastSignificantBits(pixelColor.B, n);
                    colorB = DecompressBits(colorB, n);
                    
                    pixelColor = Color.FromArgb(colorR, colorG, colorB);
                    res.SetPixel(i, j, pixelColor);
                }
            }
            
        
            
 
            return res;
        }
    }
}
