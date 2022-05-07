using System;

namespace Quidditch
{
    public abstract class Player :  Entity
    {
        public int Team;
    }

    public class Keeper : Player   //Gardien
    {
        private const int MaxDistanceToGive = 4;
        public bool Quaffle;
        
        // Initializes the attibutes of the keeper
        /*         - Keeper stands in its ring
         * Tips: You should need to look where the rings are in the field in the file Prints.cs in order to know where are the keepers
         */
        public Keeper(int team, Game game)
        {
            Team = team;
            ToChar = 'K';
            Quaffle = false;
            
            if (team == 0)
            {
                Color = ConsoleColor.Green;
                X = 3;
                Y = game.GetFieldHeight()/2;
            }
            else
            {
                Color = ConsoleColor.Red;
                X = game.GetFieldWidth() - 4;
                Y = game.GetFieldHeight() / 2 ;
            }
        }

        // Update the keeper
        public override void Update(Game game)
        {
            if (this.Quaffle == true)
            {
                foreach (Player goalchase in game.players)
                {
                    if ((goalchase is Chaser) && (goalchase.Team == this.Team) && (Distance(goalchase, this) <  MaxDistanceToGive))
                    {
                        if (((Chaser)goalchase).Ko == 0)
                        {
                            game.balls.quaffle.taker = goalchase;
                            ((Chaser) goalchase).Quaffle = true;
                            game.balls.quaffle.taker = goalchase;

                            
                            this.Quaffle = false; // on libere la balle du gardien
                        }

                    }
                }
            }
        }
    }
    public class Seeker : Player   //Attrapeur
    {        
        private const int MaxRandomProbabilityToCatch = 75;
        // Initializes the Seeker attributes
        /*         - X and Y are random in the field
         */
        public Seeker(int team, Game game)
        {
            Team = team;
            ToChar = 'S';
            
            if (team == 0)
            {
                Color = ConsoleColor.Green;
                X = game._random.Next(2, game.GetFieldWidth()/2); 
                Y = game._random.Next(0, game.GetFieldHeight()); 
            }
            
            else
            {
                Color = ConsoleColor.Red;
                X = game._random.Next(game.GetFieldWidth()/2,game.GetFieldWidth() - 5); 
                Y = game._random.Next(0, game.GetFieldHeight()); 
            }
        }

        // Update the Seeker
        /* Tips: Seeker can see the GoldenSnitch when it is at distance < 8
         * Tipsbis: Seeker can try to catch GoldenSnitch when it is at less then 1 in distance
         * TipsTris: You can get the GoldenSnitch from the game object
         */
        public override void Update(Game game)
        {
            int goldencatch;
            
            // trytocatch
            if (Distance(this, game.balls.goldenSnitch) <= 1)
            {
                goldencatch = game._random.Next(MaxRandomProbabilityToCatch);

                if (goldencatch == 0) // valeur arbitraire de capture
                {
                    game.score[Team] += 150;
                    game.balls.goldenSnitch.Taken = true;
                }
                
            }
            // see
            if (Distance(this, game.balls.goldenSnitch) < 8)
                MoveTo(game, game.balls.goldenSnitch);
            else
                Move(game);
            
        }
    }
    public class Beater : Player   //Batteur
    {
        // Initializes Beater's attributes
        /*         - X and Y are random positions in the field
         */
        public Beater(int team, Game game)
        {
            Team = team;
            ToChar = 'B';
            
            if (team == 0)
            {
                Color = ConsoleColor.Green;
                X = game._random.Next(2, game.GetFieldWidth()/2); 
                Y = game._random.Next(0, game.GetFieldHeight()); 
            }
            else
            {
                Color = ConsoleColor.Red;
                X = game._random.Next(game.GetFieldWidth()/2,game.GetFieldWidth() - 5); 
                Y = game._random.Next(0, game.GetFieldHeight()); 
            }
        }

        // Update the Beater
        public override void Update(Game game)
        {
            foreach (Entity BludgerBeat in game.balls.bludgers)
                if (BludgerBeat is Bludger)
                    this.MoveTo(game, BludgerBeat);
                
                
        }
    }
    public class Chaser : Player   //Poursuiveur
    {
        private const int MaxDistanceCoChaser = 4;
        private const int MaxRandomToScore = 3;
        public bool Quaffle;
        public int Ko;


        public int TryPtChaser;
        
        
        // Initialize chaser attributes
        /*         - X and Y are random positions in the field
         */
        public Chaser(int team, Game game)
        {
            Team = team;
            ToChar = 'C';
            Quaffle = false;
            Ko = 0;
            
            if (team == 0)
            {
                Color = ConsoleColor.Green;
                X = game._random.Next(2, game.GetFieldWidth()/2); 
                Y = game._random.Next(0, game.GetFieldHeight()); 
            }
            else
            {
                Color = ConsoleColor.Red;
                X = game._random.Next(game.GetFieldWidth()/2,game.GetFieldWidth() - 5); 
                Y = game._random.Next(0, game.GetFieldHeight()); 
            }
            
        }
        
        // HaveQuaffleAndGoToKeeper:
        /* Tips: 'is' can be a useful key word
         */
        private void HaveQuaffleAndGoToKeeper(Game game, Keeper keeper)
        {
            this.MoveTo(game, keeper);
            
            foreach (Player chaserco in game.players)
                if (chaserco is Chaser && (chaserco.Team == this.Team ) &&
                    (Distance(this, chaserco)< MaxDistanceCoChaser) &&
                    Distance(chaserco, keeper) < Distance(this, keeper))
                {
                    this.Quaffle = false;
                    game.balls.quaffle.taker = chaserco;
                    ((Chaser) chaserco).Quaffle = true;

                }
            
        }

        // HaveQuaffleAndTryToScore
        private void HaveQuaffleAndTryToScore(Game game, Keeper keeper)
        {
            TryPtChaser = game._random.Next(MaxRandomToScore);
            
            if (TryPtChaser ==  1)
            {
                game.score[this.Team] += 10;
            }

            this.Quaffle = false;
            game.balls.quaffle.taker = keeper;
            keeper.Quaffle = true;
        }

        // DoNotHaveQuaffle
        private void DoNotHaveQuaffle(Game game, Keeper keeper, Quaffle quaffle)
        {
            Player playerQuaffle = (Player) quaffle.taker;
            

                if (this.Team == playerQuaffle.Team)
                {
                    if (playerQuaffle is Keeper)
                        this.MoveTo(game, playerQuaffle);

                    else
                    {
                        for (int i = 0; i < 2; i++)
                            Move(game);
                    
                        this.MoveTo(game, keeper);
                    }
                }
                
                else
                    MoveTo(game, playerQuaffle);
                
        }

        // QuaffleNotTaken
        private void QuaffleNotTaken(Game game, Quaffle quaffle)
        {
            MoveTo(game, quaffle);
            
            if (Distance(this, quaffle) == 0)
            {
                this.Quaffle = true;
                quaffle.taker = this;
            }
            
        }
        
        
        // Update the Chaser:
        /* Tips : Chaser can score when the distance from the keeper is less than 4
         * Tipsbis : You should use the function GiveMeKeeper
         */
        public override void Update(Game game)
        {
            Quaffle quaffle = game.balls.quaffle;
            Keeper Keepadv = this.GiveMeKeeper(game);
            
            if (this.Ko > 0) // si chaser est KO
            {
                this.Ko--;

                if (this.Quaffle == true)
                {
                    this.Quaffle = false;
                    quaffle.taker = null;
                }
            }
            else
            {
                if (this.Quaffle == true)
                {
                    if (Distance(this, Keepadv ) < 4)
                        HaveQuaffleAndTryToScore(game, Keepadv);

                    else
                        HaveQuaffleAndGoToKeeper(game, Keepadv);
                }
 
                else
                {
                    if (quaffle.taker == null)
                        QuaffleNotTaken(game, quaffle);

                    else
                        DoNotHaveQuaffle(game, Keepadv, quaffle );
                }
            }
        }
        
        
        // This function returns the keeper of the opposite team
        private Keeper GiveMeKeeper(Game game)
        {
            foreach (var player in game.players)
            {
                if (player is Keeper && player.Team != Team)
                    return (Keeper) player;
            }
            return null; //This will never appen
        }
    }
}
