using System;
using System.Reflection;
using UnityEngine.Rendering;

namespace FrameworkDesign
{
    public class Singleton<T> where T : class
    {
        public static T Instance
        {
            get
            {
                if(mInstance == null)
                {
                    var ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);

                    var ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);

                    if(ctor == null)
                    {
                        throw new Exception("Non-Public Constructor() not found in" + typeof(T));
                    }

                    mInstance = ctor.Invoke(null) as T;
                }

                return mInstance;
            }
        }

        private static T mInstance;
    }
}