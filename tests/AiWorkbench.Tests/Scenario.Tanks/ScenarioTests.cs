using AiWorkbench.Entities;
using Scenario.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AiWorkbench.Tests.Scenario.Tanks
{
    public class ScenarioTests
    {
        public void InitialisationTest()
        {
            var simulation = new Simulation();

            string userScript = "tank.forward()";

            simulation.AddEntityManager(new TankManager());
            simulation.AddEntity(new Tank(userScript, new Position(0, 0), 0));

            //var frame = simulation.Step(); // TODOD: Internals visibleto

            //Assert.NotEqual(0, frame.ClientEvents.Count);
            //Assert.NotEqual(0, frame.ElapsedMilliseconds);
        }
    }
}
