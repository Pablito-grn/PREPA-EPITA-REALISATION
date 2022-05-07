using System;

namespace Morpion
{
    class Program
    {
        static void Main(string[] args)
        {
            Play();
        }
        
        // start the game
        static public void Play()
        {
            bool play = true;
            
            do
            {
                
                Console.Write("Choississez la difficulte de l'ia (1: facile | 2: moyen | 3: difficile):  ");
                int difficulty = Int32.Parse(Console.ReadLine());
                difficulty = difficulty < 0 || difficulty > 3 ? difficulty : 2;

                uint depth;

                if (difficulty == 1)
                    depth = 1;
                else if (difficulty == 2)
                    depth = 2;
                else
                    depth = 5;

                string test = "_________";//"___ooox_x";
                Morpion.Game game = Game.load_game(test, 2);

                while (game.stop() == 0)
                {
                    game.play();
    
                    Console.WriteLine();
                    game.__PrintPositions();
                }
                
                Console.WriteLine(game.__evaluate());
                Console.Write("Une autre partie ? :  ");
                if (Console.ReadLine() != "yes") play = false;
                


            } while (play);


        }
    }
}