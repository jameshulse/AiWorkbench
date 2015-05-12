using System;

namespace AiWorkbench.Entities
{
    public struct Position
    {
		public Position(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X { get; set; }

		public int Y { get; set; }

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
            return X * 17 + Y * 13;
        }
    }
}