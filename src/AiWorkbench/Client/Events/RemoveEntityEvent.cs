using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AiWorkbench.Client.Events
{
    public class RemoveEntityEvent : IClientEvent
    {
        public Guid EntityId { get; private set; }

        public string EventName { get { return "remove-entity"; } }

        public RemoveEntityEvent(Guid entityId)
        {
            EntityId = entityId;
        }
    }
}
