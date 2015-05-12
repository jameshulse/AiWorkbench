using AiWorkbench.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AiWorkbench
{
    public class EventManager
    {
        private List<IClientEvent> _currentEvents;

        public EventManager()
        {
            _currentEvents = new List<IClientEvent>();
        }

        public void Raise<T>(T value)
            where T : IClientEvent
        {
            _currentEvents.Add(value);
        }

        internal void ClearEvents()
        {
            _currentEvents.Clear();
        }
    }
}
