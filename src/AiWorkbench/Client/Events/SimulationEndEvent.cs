using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AiWorkbench.Client.Events
{
    public class SimulationEndEvent : IClientEvent
    {
        public string EventName {  get { return "end"; } }
    }
}
