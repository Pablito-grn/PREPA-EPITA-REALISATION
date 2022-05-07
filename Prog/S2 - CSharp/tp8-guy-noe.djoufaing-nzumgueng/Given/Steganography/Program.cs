using System;
using System.Drawing;

namespace Steganography
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap image = Utils.OpenImage("C:\\Users\\UncleDad\\Desktop\\tp8-guy-noe.djoufaing-nzumgueng\\hidden.bmp");

            string secret ="La sauce et le riz";

            //Embed.EmbedMsg(Utils.TextToBin(secret), image);

            Console.WriteLine(Utils.BinToText(Exctract.ExtractMsg(image, 94)));

            Utils.SaveImage("C:\\Users\\UncleDad\\Desktop\\tp8-guy-noe.djoufaing-nzumgueng\\hiddenoe2.bmp", image);
            
        }
    }
}