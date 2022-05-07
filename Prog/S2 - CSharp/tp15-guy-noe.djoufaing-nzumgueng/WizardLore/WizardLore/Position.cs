using System;

namespace WizardLore
{
    public class Position
    {
        public int X;
        public int Y;
        public int Z;
        
        public Position(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Redefine the operator SUM to sum two position
        /// </summary>
        /// <param name="a">Position1 to sum</param>
        /// <param name="b">Position2 to sum</param>
        /// <returns></returns>
        public static Position operator +(Position a, Position b)
        {
            return new Position(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        
        /// <summary>
        /// Redefine the operator SUM to sum a position with a tuple a coordonnate
        /// </summary>
        /// <param name="a">Position to sum</param>
        /// <param name="xyz">coordonate to sum</param>
        /// <returns></returns>
        public static Position operator +(Position a, (int x, int y ,int z)xyz)
        {
            return new Position(a.X + xyz.x, a.Y + xyz.y, a.Z + xyz.z);
        }
        
        public static bool operator ==(Position a, Position b)
        {
            if ((Object) a == null && ((Object) b == null )) return true;
            if ((Object) a == null || ((Object) b == null )) return false;
            
            return (a.X == b.X && a.Y == b.Y && a.Z == b.Z);
        }

        public static bool operator !=(Position a, Position b)
        {
            if ((Object) a == null && ((Object) b == null )) return false;
            if ((Object) a == null || ((Object) b == null )) return true;
            
            return (a.X != b.X || a.Y != b.Y || a.Z != b.Z);
        }
    }
}