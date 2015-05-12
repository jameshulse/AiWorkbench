using AiWorkbench.Client;
using AiWorkbench.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AiWorkbench.Entities
{
    internal interface IEntityManager
    {
        void Update(IEnumerable<Entity> entities, Frame frame);
    }

    public class EntityManager<TEntity> : IEntityManager
        where TEntity : Entity
    {
        public void Update(IEnumerable<Entity> entities, Frame frame)
        {
            foreach(var entity in entities.OfType<TEntity>())
            {
                var originalPosition = entity.Position;
                var originalHeading = entity.Heading;

                entity.Update();

                PostUpdate(entity, entities, frame);

                if (entity.Position != originalPosition || entity.Heading != originalHeading)
                    frame.RaiseEvent(new EntityMovedEvent(entity));
            }
        }

        protected virtual void PostUpdate(TEntity entity, IEnumerable<Entity> allEntities, Frame frame)
        {

        }
    }
}
