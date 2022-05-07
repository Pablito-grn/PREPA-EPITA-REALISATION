namespace WizardLore
{
    public enum Obstacle
    {
        BATTLEFIELD = 0,
        FOREST = 1,
        MOUNTAIN = 2,
        RIFT = 3
    }
 
    public class ObstacleClass
    {
        public Obstacle obs;
        
        
        public Position position;

        public ObstacleClass(Obstacle obstacle, Position position)
        {
            obs = obstacle;
            this.position = position;
        }
    }
}