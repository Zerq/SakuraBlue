using Omnicatz.AccessDenied;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakuraBlueAbstractAndBase.ScriptEngine {
    public class ScriptEngine {
        public ScriptEngine(LockToken @lock) {
            LockToken.Enforce<ScriptEngine>(@lock);
            Engine = new Microsoft.ClearScript.V8.V8ScriptEngine();
            Engine.AllowReflection = true;
        }
        public Microsoft.ClearScript.ScriptEngine Engine { get; private set; }
        public void AddHostType(string name, Type type) { Engine.AddHostType(name, type); }
        public void AddHostObject(string name, object item) { Engine.AddHostObject(name, item); }
        public void Execute(string script) { Engine.Execute(script); }
        public void Clear() { Engine.Dispose(); Engine = null; Engine = new Microsoft.ClearScript.V8.V8ScriptEngine(); Engine.AllowReflection = true; }
    }
}
