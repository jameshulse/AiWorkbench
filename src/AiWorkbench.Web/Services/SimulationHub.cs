using AiWorkbench.Client;
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
        private SimulationFactory _simulationFactory;

        public SimulationHub()
        {
            _simulationFactory = new SimulationFactory();
        }

        public override Task OnConnected()
        {
            return base.OnConnected();
        }
        
        public IEnumerable<Frame> Run(string simulationType, string playerScript)
        {
            var simulation = _simulationFactory.Create(simulationType, playerScript);

            // TODO: Stream to client as the simulation may never end
            //simulation.Run().ToObservable().Subscribe(f => Clients.Caller.update(f));

            return simulation.Run();
        }
    }
}
