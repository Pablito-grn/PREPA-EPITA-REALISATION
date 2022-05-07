using System;

namespace MyHogsmeadeCity
{
    public abstract class Building
    {
        protected int money;
        protected int beans;
        protected int population;
        protected int happiness;
        protected int cost;

        public abstract string[] toString();

        public int GetMoney()
        {
            return money;
        }

        public int GetBeans()
        {
            return beans;
        }

        public int GetPopulation()
        {
            return population;
        }

        public int GetHappiness()
        {
            return happiness;
        }

        public int GetCost()
        {
            return cost;
        }
        
    }
}