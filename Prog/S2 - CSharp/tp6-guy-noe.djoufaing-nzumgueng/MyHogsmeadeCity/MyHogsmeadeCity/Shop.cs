namespace MyHogsmeadeCity
{
    public class Shop : Building
    {
        public Shop(int cost, int money, int beans, int population, int happiness)
        {
            this.cost = cost;
            this.money = money;
            this.beans = beans;
            this.population = population;
            this.happiness = happiness;
        }
        
        public override string[] toString()
        {
            var shop = new string[8]
            {   " _________________________ ",
                "/| |  |   | / \\ |   |  | |\\",
                "_|_|__|___|/   \\|___|__|_|_",
                "-|  |-|-| |- n.-| |-| |  |-",
                " |- |-|-| |  O/ | |-| | -| ",
                "-|  |_|_| |_/|__|  _  |  |-",
                " |- |-|-| |-,|,-| |x| | -| ",
                "-|  |-|-| | | | | |_| |  |-",
            };

            return shop;
        }
    }
}