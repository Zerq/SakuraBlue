using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnicatz.AccessDenied{  
    /*
    [AttributeUsage(AttributeTargets.Class)]
    public class InstantiatorWhiteListAttribute : Attribute {
        public Type[] AllowedTypes { get; set; }
    }

    public class WhiteListInstantiator<T> where T : class {
        public static T NewInstance(params object[] parameters) {   
            var attribute = typeof(T).GetCustomAttributes(true).FirstOrDefault(n => n.GetType() == typeof(InstantiatorWhiteListAttribute)) as InstantiatorWhiteListAttribute;
            return  NewInstance(attribute, parameters);
        }
        public static T NewInstance(InstantiatorWhiteListAttribute attribute, params object[] parameters)
        {
            var tempParams = new List<object>();
            tempParams.Add(new LockToken());
            tempParams.AddRange(parameters);

            StackTrace stackTrace = new StackTrace();
            Type source = stackTrace.GetFrame(2).GetMethod().DeclaringType;

            if (attribute.AllowedTypes.Contains(source))
            {
                return (T)Activator.CreateInstance(typeof(T), tempParams.ToArray()); // this is legit create an instance
            }
            else
            {
                return null; //nope! this was not white listed!
            }
        }
    }
    */
}
