using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace Basics
{
    public class Basics
    {
        /// <summary>
        /// As the name states it apply a filter function on each pixel of the image
        /// </summary>
        /// <param name="image"> The image to modify</param>
        /// <param name="filter"> The function to apply on each pixel</param>
        public static Bitmap ApplyFilter(Bitmap image, Func<Color, Color> filter)
        {
            int w = image.Width;
            int h = image.Height;
            int r, g, b = 0;
            Bitmap imageClone = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    Color pixelColor = image.GetPixel(i, j);
                    r = pixelColor.R;
                    g = pixelColor.G;
                    b = pixelColor.B;
                    
                    Color pixelColorClone = Color.FromArgb(r, g, b);
                    
                    imageClone.SetPixel(i, j, filter(pixelColor));
                }
            }

            return imageClone;
        }
        
        
        /// <summary>
        /// A Black and White filter
        /// </summary>
        /// <param name="color"> The color to modify </param>
        /// <returns> The new color</returns>
        public static Color BlackAndWhite(Color color)
        {
            int r, g, b, average;

            r = color.R;
            g = color.G;
            b = color.B;
            
            Color black = Color.FromArgb(0,0,0);
            Color white = Color.FromArgb(255,255,255);

            average = (r + g + b) / 3;

            if (average > 127)
                return black;
            else
                return white;
        }

        /// <summary>
        /// A Yellow filter
        /// </summary>
        /// <param name="color"> The color to modify </param>
        /// <returns> The new color</returns>
        public static Color Yellow(Color color)
        {
            Color yellowColor = Color.FromArgb(color.R, color.G, 0);
            return yellowColor;
        }

        /// <summary>
        /// A Grayscale filter
        /// </summary>
        /// <param name="color"> The color to modify </param>
        /// <returns> The new color</returns>
        public static Color Grayscale(Color color)
        {
            int r, g, b, res = 0;

            r = (int) (color.G * 0.21f);
            g = (int) (color.G * 0.72f);
            b = (int) (color.G * 0.07f);
            res = r + g + b;

            
            Color greyColor = Color.FromArgb(res, res, res);

            return greyColor;
        }

        /// <summary>
        /// A Negative filter
        /// </summary>
        /// <param name="color"> The color to modify </param>
        /// <returns> The new color</returns>
        public static Color Negative(Color color)
        {
            int r = 255 - color.R , v = 255- color.G , b = 255 -color.B ;
            Color negativeColor = Color.FromArgb(r, v, b);
            return negativeColor;
            
        }

        /// <summary>
        /// Remove the maxes of the composants of the color
        /// </summary>
        /// <param name="color"> The color to modify </param>
        /// <returns> The new color</returns>
        public static Color RemoveMaxes(Color color)
        {
            int r = color.R , v = color.G , b = color.B ;
            int max = Max(r, v, b);

            if (r == max)
                r = 0;
            if (v == max)
                v = 0;
            if (b == max)
                b = 0;
            Color removeMaxes = Color.FromArgb(r, v, b);
            return removeMaxes;
        }

        public static int Max(int a, int b, int c)
        {
            if ((a >= b) && (a >= c))
                return a;
            else if ((b >= c) && (b >= c))
                return b;
            else
                return c;
        }

        /// <summary>
        /// Create the new_image as if the image was seen in a mirror
        /// ....o.  =>  .o....
        /// ...o..  =>  ..o...
        /// ..o...  =>  ...o..
        /// .o....  =>  ....o.
        /// o.....  =>  .....o
        /// </summary>
        /// <param name="image"> The image to 'mirror'</param>
        /// <returns> The new image</returns>
        public static Bitmap Mirror(Bitmap image)
        {
            int w = image.Width;
            int h = image.Height;
            
            Bitmap reverse = new Bitmap(w, h);
            
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    Color pixelColor = image.GetPixel(i, j);
                    reverse.SetPixel(w-i-1, j, pixelColor);
                }
            }

            return reverse;
        }
        

        /// <summary>
        /// Apply a right rotation
        /// </summary>
        /// <param name="image"> The image to rotate</param>
        /// <returns> The new_image</returns>
        public static Bitmap RotateRight(Bitmap image)
        {
            int w = image.Width;
            int h = image.Height;

            Bitmap reverse = new Bitmap(h, w);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    Color pixelColor = image.GetPixel(i, j);
                    
                    reverse.SetPixel(h-j-1,i ,pixelColor);
                }
            }

            return reverse;        
        }

        /// <summary>
        /// <!> Bonus <!>
        /// Rotate to the right n times
        /// </summary>
        /// <param name="image"> The image to rotate</param>
        /// <param name="n"> Number of rotation (n can be negative and thus must be handled properly)</param>
        /// <returns> The new_image</returns>
        public static Bitmap RotateN(Bitmap image, int n)
        {
            for (int i = 0; i < n; i++)
            {
                image = RotateRight(image);
            }
            return image;
        }
    }
}
