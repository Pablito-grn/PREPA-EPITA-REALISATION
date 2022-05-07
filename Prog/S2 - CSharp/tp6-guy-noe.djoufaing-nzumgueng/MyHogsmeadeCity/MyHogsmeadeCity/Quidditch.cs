namespace MyHogsmeadeCity
{
    public class Quidditch : Building
    {
        public Quidditch(int cost, int money, int beans, int population, int happiness)
        {
            this.cost = cost;
            this.money = money;
            this.beans = beans;
            this.population = population;
            this.happiness = happiness; 
        }

        public override string[] toString()
        {
            string[] quidditch = new string[7]
            {   "|>      |>       <|      <|",
                "|\\     |__|______|__|    /|",
                "| \\_ __|__|______|__|___/ |",
                "|------|--|------|--|-----|",
                "|------|--|------|--|-----|",
                "|------|--|------|--|-----|",
                "|------|--|------|--|-----|"
            };

            return quidditch;
            
        }
    }
}