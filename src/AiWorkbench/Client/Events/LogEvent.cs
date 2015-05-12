using System;

namespace AiWorkbench.Client
{
    public class LogEvent : IClientEvent
    {
		public string EventName{ get { return "log"; } }

		public string Message { get; private set; }

        public LogEvent(string message)
        {
            Message = message;
        }
    }
}