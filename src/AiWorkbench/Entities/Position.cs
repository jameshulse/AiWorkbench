using System;

namespace AiWorkbench.Entities
{
    public struct Position
    {
		public Position(double x, double y)
		{
			X = x;
			Y = y;
		}

		public double X { get; set; }

		public double Y { get; set; }

        public static bool operator ==(Position a, Position b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Position a, Position b)
        {
            return a.X != b.X || a.Y != b.Y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return this.GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return (int)(X * 17 + Y * 13);
        }
    }
}