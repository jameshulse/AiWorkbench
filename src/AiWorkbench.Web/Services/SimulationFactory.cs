using Scenario.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AiWorkbench.Web.Services
{
    public static class SimulationTypes
    {
        public const string Tank = "tank";
    }

    public class SimulationFactory
    {
        public Simulation Create(string simulationType, string playerScript)
        {
            switch(simulationType)
            {
                case SimulationTypes.Tank:
                    return CreateTankSimulation(playerScript);

                default:
                    throw new InvalidOperationException("Unknown simulation type");
            }
        }

        private Simulation CreateTankSimulation(string playerScript)
        {
            var sim = new Simulation();

            sim.AddEntityManager(new TankManager());
            sim.AddEntity(new Tank(playerScript, new Entities.Position(10, 250), 90));

            return sim;
        }
    }
}
