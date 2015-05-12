using AiWorkbench.Entities;
using Scenario.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AiWorkbench.Tests.Scenario.Tanks
{
    public class TankEntityTests
    {
        [Fact]
        public void MostRecentMovementHappens()
        {
            const string script = "tank.backward(); tank.forward();";

            var tank = new Tank(script, new Position(0, 0), 90);

            tank.MovementSpeed = 1;

            tank.Update();

            Assert.Equal(1, tank.Position.X);
        }
    }
}
