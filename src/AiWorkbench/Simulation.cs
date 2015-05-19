using AiWorkbench.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using AiWorkbench.Client;
using System.Diagnostics;
using AiWorkbench.Client.Events;

namespace AiWorkbench
{
    public class Simulation
    {
		private List<Entity> _entities;
        private List<IEntityManager> _entityManagers;

		public Simulation()
		{
			_entities = new List<Entity>();
            _entityManagers = new List<IEntityManager>();
		}

        public void AddEntityManager<TEntity>(EntityManager<TEntity> manager)
            where TEntity : Entity
        {
            _entityManagers.Add(manager);
        }

        public void AddEntity<T>(T entity)
            where T : Entity
		{
			_entities.Add(entity);
		}

        public IEnumerable<Frame> Run()
        {
            yield return InitialFrame();

            for(int i = 0; i < 50; i++) // TODO: Some sort of end condition...
                yield return Step();

            yield return FinalFrame();
        }

        internal Frame InitialFrame()
        {
            var initial = new Frame();

            _entities.ForEach(e => initial.ClientEvents.Add(new EntityCreatedEvent(e)));

            return initial;
        }

        internal Frame Step()
        {
            var frame = new Frame();

            foreach (var manager in _entityManagers)
                manager.Update(_entities, frame);

            return frame;
        }

        internal Frame FinalFrame()
        {
            // TODO: Append win condition event
            var end = new Frame();

            end.ClientEvents.Add(new SimulationEndEvent());

            return end;
        }
    }
}