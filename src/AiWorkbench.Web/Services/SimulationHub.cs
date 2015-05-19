using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace AiWorkbench.Web.Services
{
    [HubName("simulation")]
    public class SimulationHub : Hub
    {
        private static SimulationFactory _simulationFactory;
        private static Dictionary<string, Simulation> _currentSimulations = new Dictionary<string, Simulation>();

        static SimulationHub()
        {
            _simulationFactory = new SimulationFactory();
        }
        
        public void Run(string simulationType, string playerScript)
        {
            var simulation = _simulationFactory.Create(simulationType, playerScript);

            simulation.Run()
                .ToObservable()
                .Buffer(TimeSpan.FromSeconds(1), 10)
                .Subscribe(frames =>  this.Clients.Caller.Update(frames));
        }
    }
}
