using System;
using System.Collections.Generic;
using System.Data;

namespace WizardLore
{
   // public int dimension;

    public class Board
    {
        private int dimension;
        //getter dimension
        public int GetDimension() => dimension;
        
        private List<Hexagon> hexagons;
        
        public List<ObstacleClass> obstacle;

        /// <summary>
        /// List of units of each player
        /// </summary>
        public List<Unit> unitPlayer1;
        public List<Unit> unitPlayer2;
        
        /// <summary>
        /// Constructor of game board
        /// </summary>
        /// <param name="dimension">length of hexagon side</param>
        public Board(int dimension)
        {
            this.dimension = dimension;
            hexagons = new List<Hexagon>();
            InitHexagone(hexagons, dimension);
            obstacle = new List<ObstacleClass>();
            unitPlayer1 = new List<Unit>();
            unitPlayer2 = new List<Unit>();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lHex"></param>
        /// <param name="dim"></param>
        public void InitHexagone(List<Hexagon> lHex, int dim)
        {
            for (int x = 0; x < dim; x++)
            {
                for (int y = 0; y < dim; y++)
                {
                    for (int z = 0; z < dim; z++)
                    {
                        if(x == 0 || y == 0 || z == 0) lHex.Add(new Hexagon(new Position(x, y, z), Obstacle.BATTLEFIELD));
                    }
                }
            }
        }

        //Update les positions des unites et desactive celles mortes
        public void Update(Board board)
        {
            foreach (var unit in unitPlayer1)
            {
                board[unit.Position].Unit = unit;
            }
            foreach (var unit in unitPlayer2)
            {
                board[unit.Position].Unit = unit;
            }
        }
        
        
        

        
        //Indexer du board
        public Hexagon this[Position position]
        {
            get
            {
                //Console.WriteLine(hexagons.FindIndex(hex => hex._position == position));
                Hexagon hexa = hexagons.Find(hex => hex._position == position);
                return hexa;
            }
            //Hexagon hex = lHex.Find(lHex, h => h.unit != null);

            set
            {
                Hexagon hexa = hexagons.Find(hex => hex._position == position);
                hexa._position = position;
            }
        }
        
    }
    
   
}