using System;

namespace WizardLore
{
    public static class Printer
    {
        
        // The position of the current cursor
        // Needed by 'Place Cursor'
        // Note that Position represents the position of a cell in the given coordinates system (x,y,z)
        private static Position _cursorPos;
        
        
        /*
         * -----------------------------------------------------------------
         *                         PUBLIC METHODS
         * -----------------------------------------------------------------
         */



        
        /// <summary>
        /// Print the given board
        /// </summary>
        /// <param name="board"> The board to print </param>
        public static void PrintBoard(Board board)
        {
            PrintTop(board);
            PrintMiddle(board);
            PrintBottom(board);
        }
        
        /// <summary>
        /// Place the cursor at the given position in the given coordinate system
        /// This is way more complex than it should be because it doesn't use SetCursorPosition()
        /// </summary>
        /// <param name="board"> The game board </param>
        /// <param name="pos"> The position of the cursor to place </param>
        /// <param name="team"> The team of the current player, used for the cursor's color </param>
        public static void PlaceCursor(Board board, Position pos, Team team)
        {
            
            int oldLeft = Console.CursorLeft;
            int oldTop = Console.CursorTop;
            
            if (_cursorPos != null)
            {
                SetCursorPosFromPos(_cursorPos, board.GetDimension());
                Hexagon oldHex = board[_cursorPos];
                Console.BackgroundColor = GetObstacleColor(oldHex.Obstacle);
                Console.Write("_");
            }
            
            SetCursorPosFromPos(pos, board.GetDimension());
            Hexagon hex = board[pos];
            Console.BackgroundColor = GetObstacleColor(hex.Obstacle);
            Console.ForegroundColor = team == Team.PLAYER1 ? ConsoleColor.Red : ConsoleColor.Blue;
            Console.Write("A");
            Console.ResetColor();
            _cursorPos = pos;

            Console.CursorLeft = oldLeft;
            Console.CursorTop = oldTop;
            
        }
        
        
        /*
         * -----------------------------------------------------------------
         *                        PRIVATE METHODS
         * -----------------------------------------------------------------
         */

        /// <summary>
        /// Print the top part of the board
        /// </summary>
        /// <param name="board"> The game board </param>
        private static void PrintTop(Board board)
        {
            int len = board.GetDimension();

            for (int i = 0; i < len; i++)
            {
                Console.Write(" ");
                
                for (int j = 0; j < len - 1 - i; j++)
                    Console.Write("    ");
                Console.Write(" ___");

                for (int j = 0; j < i; j++)
                {
                    Console.Write("/");
                    
                    Hexagon hex = GetEntity(board, i - 1, len - i + j * 2);
                   Console.BackgroundColor = GetObstacleColor(hex.Obstacle);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             Console.ForegroundColor = GetTeamColor(hex.Unit);
                    
                    // Equivalent to hex.Unit.ToString()
                    Console.Write(hex.ToString());
                    
                    Console.ResetColor();
                    Console.Write("\\");
                    
                    if (j != i - 1) // Also very unoptimized :)
                        Console.BackgroundColor = GetObstacleColor(GetEntity(board, i - 2, len - i + j * 2 + 1).Obstacle);
                    Console.Write("___");
                    Console.ResetColor();
                }

                Console.WriteLine();
            }
            
        }

        /// <summary>
        /// Print the middle part of the board
        /// </summary>
        /// <param name="board"> The game board </param>
        private static void PrintMiddle(Board board)
        {
            
            int len = board.GetDimension();
            
            for (int i = 0; i < len; i++)
            {
                Console.Write(" ");
                
                for (int j = 0; j < len; j++)
                {
                    Console.Write("/");
                    
                    Hexagon hex = GetEntity(board, i * 2 + len - 1, j * 2);
                    Console.BackgroundColor = GetObstacleColor(hex.Obstacle);
                    Console.ForegroundColor = GetTeamColor(hex.Unit);
                    Console.Write(hex.ToString());
                    
                    Console.ResetColor();
                    Console.Write("\\");

                    if (j != len - 1)
                    {
                        Console.BackgroundColor = GetObstacleColor(GetEntity(board, i * 2 + len - 2, j * 2 + 1).Obstacle);
                        Console.Write("___");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
                Console.Write(" ");
                
                for (int j = 0; j < len; j++)
                {
                    Console.Write("\\");
                    Console.BackgroundColor = GetObstacleColor(GetEntity(board, i * 2 + len - 1, j * 2).Obstacle);
                    Console.Write("___");
                    Console.ResetColor();
                    Console.Write("/");

                    if (j != len - 1)
                    {
                        Hexagon hex = GetEntity(board, i * 2 + len, j * 2 + 1);
                        Console.BackgroundColor = GetObstacleColor(hex.Obstacle);
                        Console.ForegroundColor = GetTeamColor(hex.Unit);
                        Console.Write(hex.ToString());
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
            
        }
        
        /// <summary>
        /// Print the bottom part of the board
        /// </summary>
        /// <param name="board"> The game board </param>
        private static void PrintBottom(Board board)
        {
            
            int len = board.GetDimension();

            for (int i = len - 2; i >= 0; i--)
            {
                Console.Write(" ");
                
                for (int j = 0; j < len - 1 - i; j++)
                    Console.Write("    ");

                for (int j = 0; j <= i; j++)
                {
                    Console.Write("\\");
                    Console.BackgroundColor = GetObstacleColor(GetEntity(board, (len - 1) * 4 - i, len - i + j * 2 - 1).Obstacle);
                    Console.Write("___");
                    Console.ResetColor();
                    Console.Write("/");
                    
                    if (j != i)
                    {
                        Hexagon hex = GetEntity(board, (len - 1) * 4 - (i - 1), len - i + j * 2);
                        Console.BackgroundColor = GetObstacleColor(hex.Obstacle);
                        Console.ForegroundColor = GetTeamColor(hex.Unit);
                        Console.Write(hex.ToString());
                        Console.ResetColor();
                    }
                }

                Console.WriteLine();
            }
            
        }

        /// <summary>
        /// Get an entity from the board using coordinates of a theoretical grid
        /// This really isn't very optimized, but it shouldn't matter
        /// </summary>
        /// <param name="board"> The game board </param>
        /// <param name="line"> The line number in the grid </param>
        /// <param name="col"> The column number in the grid </param>
        private static Hexagon GetEntity(Board board, int line, int col)
        {
            
            int dim = board.GetDimension();
            Position pos = new Position(0,0,0);
            Position unitX = new Position(1,0,0);
            Position unitY = new Position(0,1,0);
            Position unitZ = new Position(0,0,1);
            
            if (col > dim - 1)
                for (int i = 0; i < col - dim + 1; i++)
                    pos += unitX;
            else
                for (int i = 0; i < dim - 1 - col; i++)
                    pos += unitZ;

            int l = (dim - 1) * 2 + Math.Abs(col - dim + 1);
            if (line > l)
            {
                Position inc = new Position(1, 0, 1);
                for (int i = 0; i < (line - l) / 2; i++)
                    pos += inc;
            }
            else
            {
                for (int i = 0; i < (l - line) / 2; i++)
                    pos += unitY;
            }

            return board[pos];
        }

        /// <summary>
        /// Convert an obstacle to a color
        /// </summary>
        /// <param name="obs"> The obstacle being converted </param>
        private static ConsoleColor GetObstacleColor(Obstacle obs)
        {
            
            switch (obs)
            {
                case Obstacle.MOUNTAIN:
                    return ConsoleColor.Gray;
                case Obstacle.FOREST:
                    return ConsoleColor.DarkGreen;
                case Obstacle.RIFT:
                    return ConsoleColor.DarkBlue;
                default: // Obstacle.NONE
                    return ConsoleColor.Black;
            }
        }

        /// <summary>
        /// Convert a unit to a color depending on his team
        /// </summary>
        /// <param name="unit"> The unit being converted </param>
        private static ConsoleColor GetTeamColor(Unit unit)
        {
            
            if (unit == null)
                return ConsoleColor.White;
            
            if (unit.Team == Team.PLAYER1)
                return ConsoleColor.Red;
            
            // unit.Team == Team.PLAYER2
            return ConsoleColor.Blue;
            
        }

        /// <summary>
        /// Converts a position in the given coordinates system into coordinates for SetCursorPosition
        /// </summary>
        /// <param name="pos"> The position (x,y,z) </param>
        /// <param name="dimension"> The dimension of the board </param>
        private static void SetCursorPosFromPos(Position pos, int dimension)
        {
            int left = 2 + 4 * (dimension - 1);
            int top = 2 + 2 * (dimension - 1);

            for (int i = 0; i < pos.X; i++)
            {
                left += 4;
                top += 1;
            }
            for (int i = 0; i < pos.Y; i++)
            {
                top -= 2;
            }
            for (int i = 0; i < pos.Z; i++)
            {
                left -= 4;
                top += 1;
            }
            
            Console.SetCursorPosition(left, top);
        }
    }
}