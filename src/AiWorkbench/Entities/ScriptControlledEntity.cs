using Microsoft.ClearScript.V8;
using System;

namespace AiWorkbench.Entities
{
	public abstract class ScriptControlledEntity : Entity
	{
        private static V8Runtime _runtime = new V8Runtime();

        private V8ScriptEngine _engine;
        private string _updateScript;

        public ScriptControlledEntity(string updateScript, Position startPosition, double headingDegrees)
			: base(startPosition, headingDegrees)
		{
            _engine = new V8ScriptEngine();
            _updateScript = updateScript ?? String.Empty;
		}

        protected void AddObject<T>(string name, T instance)
        {
            _engine.AddRestrictedHostObject<T>(name, instance);
        }

        protected void AddObject(string name, object instance)
        {
            _engine.AddHostObject(name, instance);
        }

        protected void AddHelper<THelper>(string nameOverride = "")
		{
			_engine.AddHostType(String.IsNullOrEmpty(nameOverride) ? typeof(THelper).Name : nameOverride, typeof(THelper));
		}

        protected void RunScript(string script)
        {
            _engine.Execute(_updateScript);
        }

		public override void Update()
		{
            RunScript(_updateScript);
        }
	}
}