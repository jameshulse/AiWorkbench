using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AiWorkbench.Client
{
    public class Frame
    {
        private readonly Stopwatch _watch;

        public Frame()
		{
			ClientEvents = new List<IClientEvent>();
            _watch = Stopwatch.StartNew();
        }

		public ICollection<IClientEvent> ClientEvents { get; private set; }

        public void RaiseEvent<TEvent>(TEvent model)
            where TEvent : IClientEvent
        {
            ClientEvents.Add(model);
        }

		public long ElapsedMilliseconds { get { return _watch.ElapsedMilliseconds; } }
    }
}