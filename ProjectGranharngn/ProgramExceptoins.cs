using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ProjectGranharngn
{
    interface ISinglton<T> {
        T Instance { get; }
    }
    class Singleton<T> where T : class {

        private static T instance;

        protected Singleton() {
        }
        private static T CreateInstance() {
            ConstructorInfo cInfo = typeof(T).GetConstructor(BindingFlags.Instance|BindingFlags.NonPublic,null,new Type[0], new ParameterModifier[0]);
            return (T)cInfo.Invoke(null);
        }
        public static T Instance {
            get {
                if (instance == null)
                {
                    instance = CreateInstance();
                    return instance;
                }
                else throw new SingletonException();
            }
        }
    }

    class SingletonException: ApplicationException
    {
        public SingletonException() :this("The object was created in somwhere. Please use the provided static variable or methods"){}
        public SingletonException(string message) : base(message) { }
        //public SingletonException(string message, Exception inner) : base(message, inner) { }
    }
}
