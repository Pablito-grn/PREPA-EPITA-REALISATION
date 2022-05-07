using System;

namespace Quidditch
{
    class Program
    {
        static void Main(string[] args)
        {
            Game NwGame = new Game(40, 12);
            NwGame.Play();
        }
    }
}
