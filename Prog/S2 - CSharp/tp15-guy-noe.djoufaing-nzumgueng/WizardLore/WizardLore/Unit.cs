namespace WizardLore
{
    public class Unit
    {
        public enum Units
        {
            Infantile,
            BroomWizards,
            AdvancedWizards
        }

        public int pV;
        public char flag;
        public Team Team;
        public Position Position;
        public int moveDistance;
        public int de;
        public int attackDistance;

        public Units _unit;


        /// <summary>
        /// Constructor of the unit class
        /// </summary>
        /// <param name="unit"> a char representing the first letter of a enum</param>
        /// <param name="position"> the position of the unit</param>
        /// <param name="team">enum member representing the owner of the unit</param>
        /// <param name="flag">a char representing the first color of the flag</param>
        /// <param name="pV">int representing the amount of live of the unit</param>
        public Unit(char unit, Position position, Team team, char flag, int pV)
        {
            
            if (unit == 'I') _unit = Units.Infantile;
            if (unit == 'B') _unit = Units.BroomWizards;
            if (unit == 'A') _unit = Units.AdvancedWizards;
            
            this.pV = pV;
            this.flag = flag;

            this.flag = flag;
            if (this.flag == 'G') de = 2;
            if (this.flag == 'B') de = 3;
            if (this.flag == 'R') de = 4;


                Team = team;
            this.Position = position;
            
            moveDistance = _unit == Units.BroomWizards ? 2 : 1;
            attackDistance = _unit == Units.AdvancedWizards ? 2 : 1;
        }
        
        
        
        /// <summary>
        /// Print the units char
        /// </summary>
        /// <returns> string (unit char, flag, pv) </returns>
        public override string ToString()
        {
            string res = "";
            if (_unit == Units.AdvancedWizards) res += 'A';
            if (_unit == Units.Infantile) res += 'I';
            if (_unit == Units.BroomWizards) res += 'B';

            res += flag;
            res += pV.ToString();
            return res;
        }
        
        
    }
}