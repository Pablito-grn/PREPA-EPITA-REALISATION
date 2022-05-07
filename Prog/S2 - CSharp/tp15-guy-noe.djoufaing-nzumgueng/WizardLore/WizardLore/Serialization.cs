using System;
using System.IO;

namespace WizardLore
{
    public static class Serialization
    {
        /// <summary>
        /// Serialize the given board and player
        /// </summary>
        /// <param name="board"> The game board </param>
        /// <param name="path"> The path to the output file </param>
        /// <param name="currentPlayer"> The enum member representing the player who will play next turn </param>
        public static void Serialize(Board board, string path,Team currentPlayer)
        {
            // Write each directory name to a file.
            using (StreamWriter sw = new StreamWriter(path))
            {
                int dim = board.GetDimension();
                sw.WriteLine(dim + " " +currentPlayer);
                sw.WriteLine();

                Hexagon hex;
                
                //Obstacle
                //Peut etre utiliser un thread pour faire un parcour des for en simultaner
                for (int x = 0; x < dim; x++)
                {
                    for (int y = 0; y < dim; y++)
                    {
                        for (int z = 0; z < dim; z++)
                        {
                            if (x != 0 && y != 0 && z != 0) continue; // a revoir
                            
                            hex = board[new Position(x, y, z)];
                            if (hex.Obstacle != null)
                            {
                                sw.WriteLine( x +',' + y + ',' + z + " " + (int) hex.Obstacle );
                            }
                        }
                    }
                }

                sw.WriteLine();
                //Unite
                for (int x = 0; x < dim; x++)
                {
                    for (int y = 0; y < dim; y++)
                    {
                        for (int z = 0; z < dim; z++)
                        {
                            if (x != 0 && y != 0 && z != 0) continue; // a revoir
                            
                            hex = board[new Position(x, y, z)];
                            if (hex.Unit != null)
                            {
                                 sw.WriteLine( x +',' + y + ',' + z + " " +  hex.Unit);
                            }
                        }
                    }
                }
                
                
                
            }
        }


        /// <summary>
        /// Deserialize a board from the given file
        /// </summary>
        /// <param name="path"> Path to the file </param>
        /// <param name="startingPlayer"> The enum member representing the player who will play next turn </param>
        public static Board Deserialize(string path, out Team startingPlayer)
        {
            if (File.Exists(path))
            {
                using StreamReader sr = new StreamReader(path);
                var line = sr.ReadLine();
                Board board = new Board(line[0] -'0');
                startingPlayer = (Team) line[1];
                //incomplet


                // obstacle
                while ((line = sr.ReadLine()) != null)
                {
                    
                        var lineSplt = line.Split(new char[] {',', ' '});

                        if (lineSplt.Length == 4)
                        {
                             var obs = (Obstacle) Int32.Parse(lineSplt[3]);
                        
                            var x = Int32.Parse(lineSplt[0]);
                            var y = Int32.Parse(lineSplt[1]);
                            var z = Int32.Parse(lineSplt[2]);
    
                            Position position = new Position(x, y, z);

                            board[position].Obstacle = obs;
                            board.obstacle.Add(new ObstacleClass(obs, position));
                        }
                        else if (lineSplt.Length == 7)
                        {
                            char unit =  Convert.ToChar(lineSplt[0]);
                            
                            var x = Int32.Parse(lineSplt[1]);
                            var y = Int32.Parse(lineSplt[2]);
                            var z = Int32.Parse(lineSplt[3]);
                            Position position = new Position(x, y, z);
                            Team team = (Team) Int32.Parse(lineSplt[4]);
                            char flag = Convert.ToChar(lineSplt[5]);
                            int pV = Int32.Parse(lineSplt[6]);

                            Unit unite = new Unit(unit, position, team, flag, pV);
                            board[position].Unit = unite;
                            if ((int) team == 1) board.unitPlayer1.Add(unite);
                            else board.unitPlayer2.Add(unite);
                        }

                        else sr.ReadLine(); //pour sauter la ligne de separation
                }


                startingPlayer = Team.PLAYER1;
                return board;
            }
            else
            {
                Console.Error.WriteLine("Error: could not open " + path );
                throw new Exception();
            }
            
        }
    }
}