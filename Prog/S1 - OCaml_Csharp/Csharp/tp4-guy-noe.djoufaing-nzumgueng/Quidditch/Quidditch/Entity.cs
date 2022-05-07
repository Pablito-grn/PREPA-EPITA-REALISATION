using System;

namespace Quidditch
{
    public abstract class Entity
    {
        // Attributes
        public int X; // X position on the field
        public int Y; // Y position on the field
        public char ToChar; // Representation of the entity
        public ConsoleColor Color; // Color of the representation
        // Initalize a random object
        protected static Random _random = new Random();
        
        // Methods
        // Each entity needs a fuction that updates
        public abstract void Update(Game game);

        // Set position
        protected void SetXY(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Calculate the absolute value of an integer
        public static int Abs(int x){return x > 0 ? x : -x;}
        // Calculate the distance between e1 and e2
        public static int Distance(Entity e1, Entity e2)
        {
            return Abs(e1.X - e2.X) + Abs(e1.Y - e2.Y);
        }
        // Returns true if the distance between e1 and e2 is lower than dist
        public static bool CloseTo(Entity e1, Entity e2, int distance)
        {
            return Distance(e1,e2) < distance;
        }

        // Move
        /* Tips: The class 'Game' defines a method ValidPosition
         * Tipsbis: You should use the random object
         */
        protected void Move(Game game)
        {
            int x = game._random.Next(3);
            int y = game._random.Next(3);
            int i = 0;
           while(i< 32 && game.ValidPosition(this.X + x - 1, this.Y + y - 1) == false)
           { 
               x = game._random.Next(3); 
               y = game._random.Next(3);
               i++;
               
           }
           SetXY(this.X + x - 1, this.Y + y - 1);
           
        }

        // MoveTo
        /* Tips: The class 'Game' defines a method ValidPosition
         */
        protected void MoveTo(Game game, Entity entity)
        {
            int Xpro = X, Ypro = Y; // juste pour initialiser
            int distanceMin = Abs(X - entity.X) + Abs(Y - entity.Y);
            int distancetemp;
            
            
            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    distancetemp = Abs(X + x - entity.X) + Abs(Y + y - entity.Y);

                    if ( distancetemp <= distanceMin && game.ValidPosition(X+x, Y+y))
                    {
                        distanceMin = distancetemp;
                        Xpro = X + x;
                        Ypro = Y + y;
                    }

                }
            }
            
            SetXY(Xpro, Ypro);

        }
    }
}
