using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Omnicatz.AccessDenied{


   

    public sealed  class Singleton {

        public static object CallMethod(MethodInfo method, params object[] input) {
            ParameterInfo[] parameters = method.GetParameters();
            bool hasParams = false;
            if (parameters.Length > 0)
                hasParams = parameters[parameters.Length - 1].GetCustomAttributes(typeof(ParamArrayAttribute), false).Length > 0;

            if (hasParams) {
                int lastParamPosition = parameters.Length - 1;

                object[] realParams = new object[parameters.Length];
                for (int i = 0; i < lastParamPosition; i++)
                    realParams[i] = input[i];

                Type paramsType = parameters[lastParamPosition].ParameterType.GetElementType();
                Array extra = Array.CreateInstance(paramsType, input.Length - lastParamPosition);
                for (int i = 0; i < extra.Length; i++)
                    extra.SetValue(input[i + lastParamPosition], i);

                realParams[lastParamPosition] = extra;

                input = realParams;
            }

            return method.Invoke(null, input);
        }

        public static object GetInstance(Type type, params object[] parameters) {
          
            var method = typeof(Singleton<>).MakeGenericType(type).GetMethod(nameof(Singleton<object>.GetInstance));


            return CallMethod(method, parameters);


           // return method.Invoke((object)null, parameters);  
            }
        }
        public class Singleton<T> where T : class {
            static T instance;
            public static T GetInstance(params object[] parameters) {
            var tempParams = new List<object>();
            tempParams.Add(new LockToken());
            tempParams.AddRange(parameters);  
                          if (instance == null) { instance = (T)Activator.CreateInstance(typeof(T), tempParams.ToArray()); }
                    return instance; 
            }

            public static bool HasInstance => instance != null;
             
            }
        

        /// <summary>
        /// Blocks of Instantiation to the Omnicatz.AccessDenied Assembly allowing for greater control over instansiation
        /// </summary>
        public class LockToken {
            internal LockToken() {
            }

        public class LockTokenIsNullException :    ApplicationException
        {
            public string message = "";
            public override string Message
            {
                get
                {
                    return message;
                }
            }
            public LockTokenIsNullException(Type type) {      
              message = $"{type} may only be instantiated with the Omnicatz.AccessDenied.Singleton or Singleton<{type}> class";
            }
        }

        public static void Enforce<T>(LockToken source)
        {
            if (source == null) {
                throw new LockTokenIsNullException(typeof(T));
                    }
        }
    }
    }
