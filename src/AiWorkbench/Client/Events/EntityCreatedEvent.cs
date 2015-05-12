using System;
using AiWorkbench.Entities;

namespace AiWorkbench.Client.Events
{
    public class EntityCreatedEvent : IClientEvent
    {
        public EntityCreatedEvent(Entity entity)
        {
            EntityId = entity.Id;
            Position = entity.Position;
            Heading = entity.Heading;
            EntityTypeName = entity.GetType().Name;
        }

        public string EventName { get { return "entity-created"; } }

        public Guid EntityId { get; set; }

        public Position Position { get; set; }

        public string EntityTypeName { get; set; }

        public Angle Heading { get; set; }
    }
}