using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;

namespace WizardLore
{
    public class Game
    {
        private Team player1, player2;
        public Board board;
        private Position cursorPosition = new Position(0,0,0);
        private Team actualPlayer;
        private bool selection;
        private int dim;
        private int ptPlayer1 = 0, ptPlayer2 = 0;
        private bool play = true;

        private string path = "C:\\Users\\UncleDad\\Desktop\\tp15-guy-noe.djoufaing-nzumgueng\\WizardLore\\given_boards\\normal_game_sauv.txt";
        
        List<(int, int, int)> xy = new List<(int, int, int)> {(0, 1, 0), (0, -1, 0), (1, 0, 0), (-1, 0, 0), (1, 1, 0), (-1, -1, 0)}; // (x, y, 0)
        List<(int, int, int)> xz = new List<(int, int, int)> {(0,0,1), (0,0,-1), (1, 0, 0), (-1, 0, 0), (1, 0, 1), (-1, 0, -1)}; //(x, 0, z)
        List<(int, int, int)> yz = new List<(int, int, int)> {(0,0,1), (0,0,-1),(0,1,0),(0,-1,0),(0,1,1),(0,-1,-1)};  //(0, y, z)
            
        List<(int, int, int)> Y = new List<(int, int, int)> {(0,0,1), (0,1,0),(0,-1,0),(0,1,1),(1,0,0),(1,1,0)};  //(0,y,0)
        List<(int, int, int)> Z = new List<(int, int, int)> {(0,0,1), (0,-1,0),(1,0,0),(0,1,0),(1,0,1),(0,1,1)};  //(0,0,z)
        List<(int, int, int)> X = new List<(int, int, int)> {(0,0,1), (0,-1,0),(1,0,0),(0,1,0),(1,0,1),(0,1,1)};  //(x, 0, 0)
        List<(int, int, int)> zero = new List<(int, int, int)> {(0,0,1), (0,1,0),(0,1,1),(1,0,0),(1,0,1),(1,1,0)};  //(0, 0, 0)


        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public Game(string path)
        {
            board = Serialization.Deserialize(path, out player1);
            dim = board.GetDimension();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="board"></param>
        /// <param name="player"></param>
        private List<Unit> UnitActivation(Team player)
        {
            int choice= -1;
            do
            {
                Console.WriteLine("How many units do you want to use? (1 or 2):");
                choice = Int32.Parse(Console.ReadLine());   
            } while (choice < 1 || choice > 2);
            
            

            // sert a faire de la liste un tor
            int len = (int) player == 1 ? board.unitPlayer1.Count : board.unitPlayer2.Count;
            
            int i = 0;
            
            //liste contenant les unites selectionne
            List<Unit> unitSelected = new List<Unit>(choice);
            
            Console.Write("Enter the units: ");
            
            //TOUCHES
            while (selection)
            {

               Unit temp;
               
                var arrowLeft = Console.ReadKey().Key == ConsoleKey.LeftArrow;
                var arrowRight =Console.ReadKey().Key == ConsoleKey.RightArrow;
                
                if (arrowLeft || arrowRight)
                {
                    if(player == player1)
                    {
                        if (!unitSelected.Contains(board.unitPlayer1[i%len]))
                        {
                            temp = board.unitPlayer1[i%len];
                            Printer.PlaceCursor(board, temp.Position, player);
                        }
                    }
                    else
                        if (!unitSelected.Contains(board.unitPlayer2[i%len]))
                        {
                            temp = board.unitPlayer2[i%len];
                            Printer.PlaceCursor(board, temp.Position, player);
                        }                    

                    i = arrowLeft ? i++ : i--;
                }
                
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    if (unitSelected.Count == choice) selection = false;
                    else Console.Write("Enter the units: ");
                }
            }

            return unitSelected;
        }
        
        
        /// <summary>
        /// Change Or Not the position of the unit
        /// </summary>
        /// <param name="unit">Unit to move</param>
        private bool Move(Unit unit)
        {
            bool haveMoving;
            Console.WriteLine("Where do you want it to move? (or not): ");

            (Position, bool) res = SelectNextCase(unit);
            unit.Position = res.Item1; 
            
            return res.Item2;


        }

        /// <summary>
        /// Select the next position case for a move
        /// </summary>
        /// <param name="unit">Unit to move</param>
        /// <returns>Position of the next</returns>
        public (Position, bool) SelectNextCase(Unit unit)
        {
            bool caseSelection = true;
            Position actualPosition = unit.Position;
            Position tempPos = actualPosition;
            bool haveMoving = false; // s'est deplace ?

            int i = 0;
            
            
            Printer.PlaceCursor(board, tempPos, actualPlayer);
            while (caseSelection)
            {
                var arrowLeft = Console.ReadKey().Key == ConsoleKey.LeftArrow;
                var arrowRight =Console.ReadKey().Key == ConsoleKey.RightArrow;
                
                if (arrowLeft)
                {
                    do
                    {
                        i = (i - 1) % 7;
                        tempPos = GetAdjacent(actualPosition, i, unit.moveDistance);
                    } while (!CanMoveHere(tempPos));

                    Printer.PlaceCursor(board, tempPos, actualPlayer);
                    haveMoving = true;
                }
                else if (arrowRight)
                {
                    do
                    {
                        i = (i + 1) % 7;
                        tempPos = GetAdjacent(actualPosition, i, unit.moveDistance);
                    } while (!CanMoveHere(tempPos));

                    Printer.PlaceCursor(board, tempPos, actualPlayer);
                    haveMoving = true;
                }
                
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                    caseSelection = false;
                
            }

            return (tempPos, haveMoving);
        }

        /// <summary>
        /// Chech if the unit can move at this position
        /// </summary>
        /// <param name="position"> Position to check</param>
        /// <returns>Bool</returns>
        public bool CanMoveHere(Position position)
        {
            if (!IsValidPosition(position)) return false;
            if (isOnObstacle(position, Obstacle.RIFT)) return false;
            if (isOnUnit(position)) return false;

            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"> actual positon </param>
        /// <param name="index"> index of the coordonnate in the list of coordonnate </param>
        /// <param name="d"> distance of adjactent </param>
        /// <returns>retrieve the position of the adjacent position</returns>
        public Position GetAdjacent(Position position, int index, int d)
        {
            int x = position.X;
            int y = position.Y;
            int z = position.Z;
            Position tmpPos;

            List<(int, int, int)> tmpList;
            
            if (x == 0)
            {
                if (y == 0)
                {
                    tmpList = CoordonnateXtime(zero, d);
                    tmpPos = position + tmpList[index];
                    if (z == 0 && IsValidPosition(tmpPos)) return tmpPos;

                    tmpList = CoordonnateXtime(Z, d);
                    tmpPos = position + tmpList[index];
                    if (IsValidPosition(tmpPos)) return tmpPos;
                }

                tmpList = CoordonnateXtime(Y, d);
                tmpPos = position + tmpList[index];
                if (z == 0 && IsValidPosition(tmpPos)) return tmpPos;

                tmpList = CoordonnateXtime(yz, d);
                tmpPos = position + tmpList[index];
                if (IsValidPosition(tmpPos)) return tmpPos;
            }

            if (y == 0)
            {
                tmpList = CoordonnateXtime(X, d);
                tmpPos = position + tmpList[index];
                if (z == 0 && IsValidPosition(tmpPos)) return tmpPos;

                tmpList = CoordonnateXtime(xz, d);
                tmpPos = position + tmpList[index];
                if (IsValidPosition(tmpPos)) return tmpPos;
            }

            tmpList = CoordonnateXtime(xy, d);
            tmpPos = position + tmpList[index];
            if (IsValidPosition(tmpPos)) return tmpPos;

            return position; // this case shouldn't happen
        }

        /// <summary>
        /// Because Some unit can move of 2 cases
        /// </summary>
        /// <param name="x"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<(int, int, int)> CoordonnateXtime(List<(int, int, int)> list, int x)
        {
            for (var i = 0; i < list.Count; i++)
            {
                var elt = list[i];
                elt = (elt.Item1 * x, elt.Item2 * x, elt.Item3 * x);
            }

            return list;
        }

        /// <summary>
        /// Check if the cooedonnate of the position are in the board
        /// </summary>
        /// <param name="position">Position with coordonnate to check</param>
        /// <returns></returns>
        public bool IsValidPosition(Position position)
        {
            int x = position.X;
            int y = position.Y;
            int z = position.Z;
            
            if (x != 0 || y != 0 || z != 0)
                if (x > -1 && x < dim || y > -1 && y < dim || z > -1 && z < dim)
                    return true;
            return false;

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attaquant">Unite qui attaque</param>
        /// <param name="cible">Unite qui est attaque</param>
        public void Fight(Unit attaquant, Unit cible)
        {
            int de = attaquant.de;
            
            Console.Clear();
            if (isOnObstacle(cible.Position, Obstacle.FOREST)) de -= 1;
            else if (isOnObstacle(cible.Position, Obstacle.MOUNTAIN)) de -= 2;
            
            Console.WriteLine("Do you want this unit to attack? (yes/no): ");

            string reponse;
            do
            {
                reponse = Console.ReadLine();
            } while (reponse != "yes" || reponse != "no");
            
            if (reponse == "yes")
            {
                // if unit can attack
                
                
                
                
            }
            
            
        }

        /// <summary>
        /// Check if this position contain an obstacle
        /// </summary>
        /// <param name="position"></param>
        /// <param name="obs">Montain or Forest</param>
        /// <returns></returns>
        public bool isOnObstacle(Position position, Obstacle obs)
        {
            foreach (var obstacle in board.obstacle)
            {
                if((int) obstacle.obs == (int) obs)
                    if (obstacle.position == position)
                        return true;
            }

            return false;
        }
        
        /// <summary>
        /// Check if this position contain an obstacle
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool isOnUnit(Position position)
        {
            foreach (var unit in board.unitPlayer1)
            {
                if (unit.Position == position)
                    return true;
            }
            foreach (var unit in board.unitPlayer2)
            {
                if (unit.Position == position)
                    return true;
            }

            return false;
        }
        
        
        /// <summary>
        /// Check if the unit can retreat else the unit take a point of damage
        /// </summary>
        /// <param name="unit">unit to retreat</param>
        public void Retreat(Unit unit)
        {
            Position pos = unit.Position + ;
            if (CanMoveHere(pos))
                unit.Position = pos;
            else
            {
                pos = unit.Position +  ;
                if (CanMoveHere(pos))
                    unit.Position = pos;
                else
                    unit.pV--;
            }
        
        }
        

        public void BeforeRound()
        {
            Console.WriteLine( "Press any key to continue. Press q to quit"); 
            
            if(Console.ReadKey().KeyChar == 'q') Quit();
            else
            {
                Console.Clear();
                Printer.PrintBoard(board);
            }
        }

        public void Round(Team player)
        {
            UnitActivation(player);
            // Activation
            UnitActivation(player1);
            UnitActivation(player2);
                
                
            //Fight
            
            foreach (var unit in board.unitPlayer1)
            {
                bool canAttack = Move(unit);
                if (unit._unit == Unit.Units.AdvancedWizards && canAttack )
                    continue;
                
                //Fight(unit, );
            }        
        }
        public void Play()
        {
            actualPlayer = player2;
            //game
            do
            {
                BeforeRound();
                actualPlayer = actualPlayer == player1 ? player2 : player1;
                Round( actualPlayer == player1 ? player1 : player2);
            } while (play);
            
            
            int winner = CheckWin();
            if (winner != 0)
            {
                if (winner == 1) Console.WriteLine("Player 1 wins the game!");
                else Console.WriteLine("Player 2 wins the game!");
            }

        }


        private int CheckWin()
        {
            if (ptPlayer1 > 3)
            {
                play = false;
                return 1;
            }
            if (ptPlayer2 > 3)
            {
                play = false;
                return 2;
            }
            return 0;
        }

        /// <summary>
        /// Save the part and quit the game 
        /// </summary>
        /// <exception cref="Exception">it's Call to simulate a game over</exception>
        public void Quit()
        {
            Console.WriteLine( "Do you want to save the game? y / n: "); 
            
            if(Console.ReadKey().KeyChar == 'y')
            {
                Console.WriteLine("");
                string pathSave = Console.ReadLine();
                Serialization.Serialize(board, pathSave, actualPlayer);
            }
            play = false;
        }
    }
}