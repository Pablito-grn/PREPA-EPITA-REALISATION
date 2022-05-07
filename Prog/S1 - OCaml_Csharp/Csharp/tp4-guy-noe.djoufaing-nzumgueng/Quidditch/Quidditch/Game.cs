using System;
using System.Collections.Generic;
using System.Threading;

namespace Quidditch
{
    public class Game
    {
        public Balls balls;
        public List<Player> players;
        public int[] score;
        public int time;

        private Printer printer = new Printer();
        
        
        private int _fieldwidth;
        public int GetFieldWidth()
        {
            return _fieldwidth;
        }
        private int _fieldheight;
        public int GetFieldHeight()
        {
            return _fieldheight;
        }
        public Random _random = new Random();

        public void SetFieldWidth(int w)
        {
            _fieldwidth = w;
        }
        public void SetFieldHeight(int h)
        {
            _fieldheight = h;
        }
        
        
        // AddTeam
        public void AddTeam(int team)
        {
            
            players.Add(new Keeper(team, this));

            players.Add(new Seeker(team, this));
            
            for (int i = 0; i < 3; i++)
                players.Add(new Chaser(team, this));
            
            for (int i = 0; i < 2; i++)
                players.Add(new Beater(team, this));
            

            
            
        }

        // Game initializes the game
        /* Tips: To change the name of your Console, (cf. TP1)
         */
        public Game(int w, int h)
        {
            time = 0;
            score = new int[] {0, 0};
            _fieldheight = h;
            _fieldwidth = w;
            balls = new Balls(this);

            players = new List<Player>();

            for (int i = 0; i < 2; i++)
                AddTeam(i);
            
            Console.Title = "’Quidditch Game";

        }
        
        // ValidPosition
        public bool ValidPosition(int x, int y)
        {bool res = false;

            if (x < GetFieldWidth() && y < GetFieldHeight() && x > 0 && y > 0)
            {
                res = true;
                
              foreach (Player playerPosition in players)
                  if ((playerPosition.X == x) && (playerPosition.Y == y))
                      res = false;
            }

            return res;

        }
        
        // Update
        /* Tips: Use the function Thread.Sleep(int) to have a break at each step and to be able to see your printing 
         */
        public int Play()
        {
            int result;
            while ( balls.goldenSnitch.Taken == false)
            {
                printer.PrintGame(this);
                
                //update des entity
                foreach (Player playermaj in players)
                    playermaj.Update(this);
                
                foreach (Entity ball in balls.all)
                    ball.Update(this);

                time++;

                Thread.Sleep(50);
            }

            if (score[0] > score[1])
                result = 0;
            else if (score[1] > score[0])
                result = 1;
            else
                result = -1;

            return result;
            
            Thread.Sleep(100000);

        }
    }
}
