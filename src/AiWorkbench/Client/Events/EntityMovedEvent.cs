using AiWorkbench.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AiWorkbench.Client.Events
{
    public class EntityMovedEvent : IClientEvent
    {
        public EntityMovedEvent(Entity entity)
        {
            Position = entity.Position;
            Heading = entity.Heading;
            EntityId = entity.Id;
        }

        public string EventName { get { return "entity-moved"; } }

        public Guid EntityId { get; set; }

        public Position Position { get; set; }

        public Angle Heading { get; set; }
    }
}