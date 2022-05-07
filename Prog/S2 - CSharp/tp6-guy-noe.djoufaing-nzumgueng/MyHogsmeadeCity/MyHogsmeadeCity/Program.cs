using System;

namespace MyHogsmeadeCity
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(10000, 3000);
            game.Update();
            
        }
    }
}
