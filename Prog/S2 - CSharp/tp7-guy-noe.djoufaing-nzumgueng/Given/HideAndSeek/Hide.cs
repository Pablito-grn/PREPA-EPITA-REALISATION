using System.Drawing;
using System;

namespace HideAndSeek
{
    public class Hide
    {

        /// <summary>
        /// Compress a value that was on 8 bits into a value on 'n' bits
        /// </summary>
        /// <param name="to_compress"> The value to compress</param>
        /// <param name="n"> On how many bits it must be compressed</param>
        /// <returns> The compressed value</returns>
        public static int CompressBits(int to_compress, int n)
        {
            // inverse de decompresse bit sur le produit en croix

            int getMaxBit8 = Bits.GetMaxForNBits(8);
            int getMaxBitn = Bits.GetMaxForNBits(n);
            
            int res = to_compress * getMaxBitn / getMaxBit8;
            return res;
        }

        /// <summary>
        /// Hides the image 'to_hide' which is supposed to be a grayscale in the color 'where_to_hide'
        /// of the image 'image'
        /// </summary>
        /// <param name="image"> The image where you have to hide the image</param>
        /// <param name="to_hide"> The image to hide</param>
        /// <param name="where_to_hide"> In which of composant R, G or B you want to hide it</param>
        /// <param name="n"> The number of bits you want to hide</param>
        public static void HideGrayScale(Bitmap image, Bitmap to_hide, color_type where_to_hide, int n)
        {
            int w = image.Width, h = image.Height;
            Color pixelColor, pixelColor2;
            int color, colorR, colorG, colorB;

            if (where_to_hide == color_type.R)
            {
                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        pixelColor = to_hide.GetPixel(i, j);
                        color = pixelColor.R;
                        color = CompressBits(color, n);
                        
                        pixelColor2 = image.GetPixel(i, j);
                        colorR = pixelColor2.R;
                        colorG = pixelColor2.G;
                        colorB = pixelColor2.B;


                        Bits.SetLeastSignificantBits(ref colorR, color, n);
                        
                        pixelColor = Color.FromArgb(colorR, colorG, colorB);
                        
                        image.SetPixel(i, j, pixelColor);
                    }
                }
            }
            else if (where_to_hide == color_type.G)
            {
                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        pixelColor = to_hide.GetPixel(i, j);
                        color = pixelColor.G;
                        color = CompressBits(color, n);
                        
                        pixelColor2 = image.GetPixel(i, j);
                        colorR = pixelColor2.R;
                        colorG = pixelColor2.G;
                        colorB = pixelColor2.B;


                        Bits.SetLeastSignificantBits(ref colorG, color, n);
                        
                        pixelColor = Color.FromArgb(colorR, colorG, colorB);
                        
                        image.SetPixel(i, j, pixelColor);
                    }
                }
            }
            else // (where_is_hidden == color_type.B)
            {
                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        pixelColor = to_hide.GetPixel(i, j);
                        color = pixelColor.B;
                        color = CompressBits(color, n);
                        
                        pixelColor2 = image.GetPixel(i, j);
                        colorR = pixelColor2.R;
                        colorG = pixelColor2.G;
                        colorB = pixelColor2.B;


                        Bits.SetLeastSignificantBits(ref colorB, color, n);
                        
                        pixelColor = Color.FromArgb(colorR, colorG, colorB);
                        
                        image.SetPixel(i, j, pixelColor);
                    }
                }
            }
        }

        /// <summary>
        /// Hides the image 'to_hide' in the image 'image'
        /// Red color of 'to_hide' is hidden in Red color of image
        /// Green color of 'to_hide' is hidden in Green color of image
        /// And Blue color of 'to_hide' is hidden in Blue color of image
        /// </summary>
        /// <param name="image"> The image where you have to hide the image</param>
        /// <param name="to_hide"> The image to hide</param>
        /// <param name="n"> The number of bits you want to hide</param>
        public static void HideColor(Bitmap image, Bitmap to_hide, int n)
        {
            int w = image.Width, h = image.Height;
            Color pixelColor, pixelColor2;
            int colorR1, colorG1, colorB1, colorR, colorG, colorB;
            
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    pixelColor = to_hide.GetPixel(i, j);
                    
                    colorR1 = pixelColor.R;
                    colorR1 = CompressBits(colorR1, n);
                    
                    colorG1 = pixelColor.R;
                    colorG1 = CompressBits(colorG1, n);
                    
                    colorB1 = pixelColor.R;
                    colorB1 = CompressBits(colorB1, n);
                    
                    pixelColor2 = image.GetPixel(i, j);
                    colorR = pixelColor2.R;
                    colorG = pixelColor2.G;
                    colorB = pixelColor2.B;


                    Bits.SetLeastSignificantBits(ref colorR, colorR1, n);
                    Bits.SetLeastSignificantBits(ref colorG, colorG1, n);
                    Bits.SetLeastSignificantBits(ref colorB, colorB1, n);

                        
                    pixelColor = Color.FromArgb(colorR, colorG, colorB);
                        
                    image.SetPixel(i, j, pixelColor);
                }
            }
        }
    }
}
