using System;

namespace AiWorkbench.Entities
{
    public abstract class Entity
    {
        protected Entity(int x, int y, double headingDegrees = 0)
        {
            Position = new Position(x, y);
            Heading = Angle.FromDegrees(headingDegrees);
        }

		protected Entity(Position startPosition, double headingDegrees = 0)
            : this()
		{
			Position = startPosition;
			Heading = Angle.FromDegrees(headingDegrees);            
		}

        private Entity()
        {
            Id = Guid.NewGuid();
        }

		public Guid Id { get; private set; }

		public int X { get { return Position.X; } }

		public int Y { get { return Position.Y; } }

		public Position Position { get; set; }

		public Angle Heading { get; set; }

		public abstract void Update();
    }
}