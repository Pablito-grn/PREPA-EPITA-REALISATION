namespace WizardLore
{
    public class Hexagon
    {
        public Obstacle Obstacle ;
        public  Unit Unit = null;
        public  Position _position;
        
        public Hexagon(Position position, Obstacle obstacle = Obstacle.BATTLEFIELD)
        {
            Obstacle = obstacle;
            _position = position;
        }
        
        public override string ToString()
        {
            return Unit == null ? "   " : Unit.ToString();
        }
    }
}