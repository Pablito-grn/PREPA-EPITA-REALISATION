using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace MyHogsmeadeCity
{
    public enum Action
    {
        ADD,
        REMOVE,
        PRINT,
        QUIT,
        NOTHING,
        FAIL
    }

    class Game
    {
        private List<Building> buildingList;
       
        private int TotalBeans;
        private int TotalMoney;
        private int TotalPopulation;
        private int TotalHappiness;
       
        private int IncreaseBeans;
        private int IncreaseMoney;
        
        public Game(int money, int beans)
        {
            TotalBeans = beans;
            TotalMoney = money;
            TotalPopulation = 0;

            TotalHappiness = 0;
            IncreaseBeans = 0;
            IncreaseMoney = 0;

            buildingList = new List<Building>();
        }

        public void AddTotal(Building building)
        {
            TotalBeans += building.GetBeans();
            TotalMoney += building.GetMoney();
            TotalPopulation += building.GetPopulation();
            TotalHappiness += building.GetHappiness();
        }

        public void AddBuilding(Building building)
        {
            AddTotal(building);
            buildingList.Add(building);
        }

        public void RemoveBuilding(int index)
        {
            buildingList.RemoveAt(index - 1);
            TotalPopulation -= buildingList[index].GetPopulation();
            TotalHappiness -= buildingList[index].GetHappiness();
            TotalBeans -= buildingList[index].GetBeans();
            TotalMoney -= buildingList[index].GetMoney();
        }

        
        public int[] ConvertMoney(int money)
        {
            int[] moneys = {0, 0, 0};
            moneys[1] = money / 27;
            moneys[0] = money % 27 ;
    
            moneys[2]  = moneys[1] / 21;
            moneys[1] = moneys[1] % 21;
    
            return moneys;
        }
        
        public void PrintInfo()
        {
            int[] totalmoney = ConvertMoney(TotalMoney);
            int[] moneyperround = ConvertMoney(IncreaseMoney);
    
            Console.WriteLine("You have {0} Galleons, {1} Sickles and {2} Knuts", totalmoney[2], totalmoney[1], totalmoney[0]);
            Console.WriteLine("You have {0} Galleons, {1} Sickles and {2} Knuts per round", moneyperround[2], moneyperround[1], moneyperround[0]);
            
            
            Console.WriteLine("You have {0} beans", TotalBeans);
            
            Console.WriteLine("You gain {0} beans per round", IncreaseBeans);
            Console.WriteLine("The rate of happiness is : {0}", TotalHappiness);
            Console.WriteLine("There are {0} people in your town", TotalPopulation);
        }

        public void PrintCity()
        {
            int l = buildingList.Count;
            
            for (int i = 0; i < l; i++)
            {
                // dimensions d'un batiment
                int xb = buildingList[i].toString()[0].Length; //27
                int yb = buildingList[i].toString().Length; //Q = 7, S = 8, P = 10, H= 8;
                
          
                if ((i % 3) == 0)
                {
                    Console.SetCursorPosition(0, Console.CursorTop + 1 );
                    
                    for (int j = 0; j < yb; j++)
                        Console.WriteLine(buildingList[i].toString()[j]);
                    
                }
                else
                {
                    Console.SetCursorPosition(Console.CursorLeft + xb+1, Console.CursorTop - yb );

                    for (int j = 0; j < yb; j++)
                    {
                        Console.WriteLine(buildingList[i].toString()[j]);
                        Console.SetCursorPosition(Console.CursorLeft + xb+1, Console.CursorTop );
                        if ((i%3) == 2)
                        {
                            Console.SetCursorPosition(Console.CursorLeft + xb + 1, Console.CursorTop );
                        }
                    }

                }
            }
            
        }
        
        
        public Action GetNextAction()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            var choix = "";
            Console.WriteLine("What do you want to do ? ...");
            Console.WriteLine("Add | Remove | Print | Nothing | Quit");
            choix = Console.ReadLine();
            
            switch (choix)
            {
                case "Add":
                    return Action.ADD;
                    
                case "Remove":
                    return Action.REMOVE;

                case "Print":
                    return Action.PRINT;
                
                case "Nothing":
                    return Action.NOTHING;
                   
                case "Quit":
                    return Action.QUIT;
                    
                default:
                    return Action.FAIL;
                    
            }
        }

        public Building Construct()
        {

            string choix = "";
            Console.WriteLine("Which building do you want to construct ?");
            Console.WriteLine("quidditch | house | prison | shop");
            

            
            choix =  Console.ReadLine();

            switch (choix)
            {
                case "quidditch":
                    Quidditch quiAdd = new Quidditch(800, 10, 15, 17, 100);
                    AddBuilding(quiAdd);
                    TotalBeans -= quiAdd.GetCost();
                    
                    return quiAdd;
                
                case "house":
                    House houseAdd = new House(300, 3, 15, 4, 5); 
                    AddBuilding(houseAdd);
                    TotalBeans -= houseAdd.GetCost();

                    return houseAdd;
                
                case "prison":
                    Prison prisonAdd = new Prison(2000, 15, 15, 3, 50);
                    AddBuilding(prisonAdd);
                    TotalBeans -= prisonAdd.GetCost();

                    return prisonAdd;
                
                case "shop":
                    Shop shopAdd = new Shop(1000, 18, 15, 17, 14);
                    AddBuilding(shopAdd);
                    TotalBeans -= shopAdd.GetCost();
                    
                    return shopAdd;
                
                default:
                    return null;
            }

        }

        public void Destroy()
        {
            int index = 0;
            do
            {
                Console.WriteLine("Which building do you want to destroy ?");
                Console.Write("Write a number from 0 to {0} :  ", buildingList.Count);
                index = Int32.Parse(Console.ReadLine());
            } while ( index <= 0 || index > buildingList.Count);
            
            
            RemoveBuilding(index);
        }

        public void DestroyRandomBuilding()
        {
            if (TotalBeans < 0 || TotalMoney < 0 && buildingList.Count > 0)
            {
                int index = new Random().Next(buildingList.Count);
                RemoveBuilding(index);
            }
        }
        
        public bool Update()
        {
            IncreaseMoney = 0;
            IncreaseBeans = 0;
            
            bool res = false;
            do
            {
                var up = GetNextAction();
                switch (up)
                {
                    case Action.ADD:
                        Construct();
                        break;
                
                    case Action.REMOVE:
                        Destroy();
                        break;
                
                    case Action.PRINT:
                        PrintInfo();
                        PrintCity();
                        break;
                
                    case Action.NOTHING:
                        break;
                
                    case Action.QUIT:
                        res = true;
                        break;
                }

                // update == les dragees a chaque tour ect
                if (up != Action.QUIT && up != Action.PRINT)
                {
                    foreach (var batBenefit in buildingList)
                    {
                        IncreaseBeans += batBenefit.GetBeans();
                        IncreaseMoney += batBenefit.GetMoney(); 
                    }

                    TotalMoney += IncreaseMoney;
                    TotalBeans += IncreaseBeans;
                }
            
                foreach (var taxBat in buildingList)
                {
                    var randTax = new Random().Next(5);

                    if (taxBat is House && randTax == 3) // taxe des houses
                    {
                        TotalMoney -= ((House) taxBat).LoseMoney();
                    }

                    else if (taxBat is Prison && randTax==5) // taxe des prisons
                    {
                        TotalMoney -= ((Prison) taxBat).LoseMoney();
                    }
                }
            
                if(TotalMoney < 0 || TotalBeans < 0)
                    DestroyRandomBuilding();
                
                
            } while (TotalBeans >= 1 && TotalMoney >= 1 && buildingList.Count >= 0 && res == false);
            
            return res;
        }
        
    }
    

}