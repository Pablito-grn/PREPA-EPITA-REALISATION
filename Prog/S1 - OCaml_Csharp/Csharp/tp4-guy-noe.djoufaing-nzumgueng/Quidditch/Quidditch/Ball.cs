using System;
using System.Collections.Generic;

namespace Quidditch
{
    
    public class Quaffle : Entity
    {
        public Entity taker;

        // Initialize Quaffle's fields
        /*         - the position
         *         - the color -> DarkYellow
         *         - the representation
         */
        public Quaffle(int x, int y)
        {
            X = x;
            Y = y;
            ToChar = 'Q';
            Color = ConsoleColor.DarkYellow;
        }

        // Update the Quaffle
        /* Tips: The Quaffle has the position of his possessor
         */
        public override void Update(Game game)
        {
            if (taker != null)
            {


                if (taker is Keeper)
                {
                    Keeper takekeeper = (Keeper) taker;
                    if (takekeeper.Quaffle == true)
                    {
                        taker = takekeeper;
                        X = taker.X;
                        Y = taker.Y;
                    }
                }
                else //(taker is Chaser)
                {
                    Chaser takechaser = (Chaser) taker;
                    if (takechaser.Quaffle == true)
                    {
                        taker = takechaser;
                        X = taker.X;
                        Y = taker.Y;
                    }
                }
            }


        }
    }
    
    public class Bludger : Entity
    {
        private const int DistanceAttack = 2;
        private const int DistanceBeater = 3;
        private const int MaxHit = 8;
        private const int MinHit = 4;
        private const int MaxRandomChanceToHit = 10;
        private const int MaxChanceToHit = 3;
        
        // Initialize bludger's field
        /*        - the position
         *        - the color -> DarkGray
         *        - the representation
         */
        public Bludger(int x, int y)
        {
            X = x;
            Y = y;
            ToChar = 'B';
            Color = ConsoleColor.DarkGray;
        }
        
        // CanAttack tells if the bludger can attack a player
        /* Tips: Look for the special word 'is'
         */
        
        public bool CanAttack(Player player, Game game)
        {
            if (player is Chaser)
            {
                Chaser playerChaser = (Chaser) player;

                if ((playerChaser.Ko == 0) && (Distance(playerChaser, this) < DistanceAttack ))
                {
                    // si on trouve un beater proche de chaser
                    foreach (Player NearBeater in game.players)
                        if ((NearBeater is Beater) && (NearBeater.Team == playerChaser.Team) && (Distance(NearBeater, playerChaser) < DistanceBeater))
                            return false;
                    
                    return true;
                }
            }
            return false;
        }
        
        // Update the bludger
        /* Tips: Game has a field Balls that has a field Quaffle
         */
        public override void Update(Game game)
        {
            Quaffle quaffle = game.balls.quaffle;

            
            if (quaffle.taker != null)
                for (int i = 0; i < 2; i++)
                    this.MoveTo(game, quaffle);
            
            this.Move(game);
            
            int degat = game._random.Next(MaxRandomChanceToHit);
            int ptKo;
            
            if (degat < MaxChanceToHit) // si <3 pour avoir 3/10
            {
                foreach (Player cible in game.players)
                {
                    if (CanAttack(cible, game) == true)
                    {
                        ptKo = game._random.Next(MinHit, MaxHit);
                        ((Chaser) cible).Ko = ptKo;
                    }
                }
            }
        }
    }
    
    public class GoldenSnitch : Entity
    {
        public bool Taken = false;
        
        // Initialize GoldenSnitch's fields
        /*         - the position
         *         - the color -> Yellow
         *         - the representation
         */
        public GoldenSnitch(int x, int y)
        {
            X = x;
            Y = y;
            Color = ConsoleColor.Yellow;
            ToChar = 'G';
        }

        // Update the GoldenSnitch
        public override void Update(Game game)
        {
            for (int i = 0; i < 5; i++)
            {
                this.Move(game);
            }
        }
    }
    
    // This class gives fast access to every balls of the game
    public class Balls
    {
        public List<Bludger> bludgers;
        public GoldenSnitch goldenSnitch;
        public Quaffle quaffle;

        public List<Entity> all;
        public Balls(Game game)
        {
            int h = game.GetFieldHeight();
            int w = game.GetFieldWidth();
            quaffle = new Quaffle(w / 2, h / 2);
            bludgers = new List<Bludger>();
            for (int i = 0; i < 2; i++)
                bludgers.Add(new Bludger(game._random.Next(w),game._random.Next(h)));
            goldenSnitch = new GoldenSnitch(game._random.Next(w),game._random.Next(h));
            
            all = new List<Entity>();
            all.Add(quaffle);
            all.Add(bludgers[0]);
            all.Add(bludgers[1]);
            all.Add(goldenSnitch);
        }
    }
}
