using System;

namespace MyHogsmeadeCity
{
    

    
    class House : Building, ITaxable
    {
        public House(int cost, int money, int beans, int population, int happiness)
        {
            this.cost = cost;
            this.money = money;
            this.beans = beans;
            this.population = population;
            this.happiness = happiness;
        }


        public override string[] toString()
        {
            var maison = new string[8] {
                "  _______________________  ",
                " / , , , , , , , , , , , \\ ",
                "/-------------------------\\",
                "|| ----- ----            ||",
                "|| | | | ||||            ||",
                "|| | | | ||||            ||",
                "|| ----- ||||            ||",
                "||       ----            ||"};
            
            return maison;
        }



        public int LoseMoney()
        {
            return -5;
        }
    }
    

}