using System;

namespace MyHogsmeadeCity
{
    public class Prison : Building, ITaxable
    {
        public Prison(int cost, int money, int beans, int population, int happiness)
        {
            this.cost = cost;
            this.money = money;
            this.beans = beans;
            this.population = population;
            this.happiness = happiness;
        }


        public override string[] toString()
        {
            var prison = new string[10]
            {   "     | |_| |    | |_| |    ",
                "     |__|__|____|__|__|    ",
                "    \\_|__|__|__|__|__/     ",
                "      |__|__|[]|__|__|     ",
                "      ||__|__|__|__|_|     ",
                "      |__|__|[]|__|__|     ",
                "      ||__|__|__|__|_|     ",
                "      |__|__|==|__|__|     ",
                "  ,;.;||__|_| ||__|_|,;.   ",
                ",;.;.,|==|==|__|==|==|;,.,."
            };

            return prison;
        }

        public int LoseMoney()
        {
            return -5;
        }
    }
}