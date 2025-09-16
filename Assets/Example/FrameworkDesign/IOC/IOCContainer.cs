using System;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign
{
    public class BluetoothManager
    {
        public void Connect()
        {
            Debug.Log("1");
        }
    }

    public class IOCExample : MonoBehaviour
    {
        private void Start()
        {
            var container = new IOCContainer();
            container.Register(new BluetoothManager());
            
        }
    }


    public class IOCContainer
    {
        public Dictionary<Type, object> mInstances = new Dictionary<Type, object>();

        public void Register<T>(T instance)
        {
            var key = typeof(T);

            if (mInstances.ContainsKey(key))
            {
                mInstances[key] = instance;
            }
            else
            {
                mInstances.Add(key, instance);
            }
        }

        public T Get<T>() where T : class
        {
            var key = typeof(T);

            object retObj;

            if(mInstances.TryGetValue(key, out retObj))
            {
                return retObj as T;
            }

            return null;
        }
    }
}
