using AiWorkbench.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ClearScript;
using AiWorkbench;

namespace Scenario.Tanks
{
    public interface ITankController
    {
        [ScriptMember(Name = "forward")]
        void Forward();

        [ScriptMember(Name = "backward")]
        void Backward();

        [ScriptMember(Name = "turnLeft")]
        void TurnLeft();

        [ScriptMember(Name = "turnRight")]
        void TurnRight();

        [ScriptMember(Name = "shoot")]
        void Shoot();
    }

    public class Tank : ScriptControlledEntity, ITankController
    {
        public Movement NextMovement { get; private set; }
        public bool IsShooting { get; private set; }

        public double SpinSpeed { get; set; }
        public double MovementSpeed { get; set; }
        public int Health { get; internal set; }

        public enum Movement
        {
            None = 0,
            Forward,
            Backward,
            TurnLeft,
            TurnRight
        }

        public enum Action
        {
            None = 0,
            Shoot = 1
        }

        public Tank(string updateScript, Position startPosition, double headingDegrees)
            : base(updateScript, startPosition, headingDegrees)
        {
            AddObject<ITankController>("tank", this);
            AddHelper<MathHelper>("Math");

            // TODO: Work out how to add console logger...

            MovementSpeed = 1;
            Health = 100;
        }

        #region Script Accessible
        
        public void Forward()
        {
            NextMovement = Movement.Forward;
        }

        public void Backward()
        {
            NextMovement = Movement.Backward;
        }

        public void TurnLeft()
        {
            NextMovement = Movement.TurnLeft;
        }

        public void TurnRight()
        {
            NextMovement = Movement.TurnRight;
        }

        public void Shoot()
        {
            IsShooting = true;
        }

        #endregion

        public void PrepareForNextFrame()
        {
            NextMovement = Movement.None;
            IsShooting = false;
        }
    }
}
