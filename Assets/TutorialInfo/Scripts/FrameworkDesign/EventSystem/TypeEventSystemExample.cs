using UnityEngine;
using FrameworkDesign;
using System.Runtime.CompilerServices;

namespace Example
{
    public class TypeEventSystemExample : MonoBehaviour
    {
        public struct EventA { }

        public struct EventB
        {
            public int ParamB;
        }

        public interface IEventGroup
        {

        }

        public struct EventC : IEventGroup
        {

        }

        public struct EventD : IEventGroup
        {

        }

        private ITypeEventSystem mTypeEventSystem = null;

        private void Start()
        {
            Debug.Log("Run");

            mTypeEventSystem = new TypeEventSystem();

            mTypeEventSystem.Register<EventA>(eA =>
            {
                Debug.Log("OnEventA");
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            mTypeEventSystem.Register<EventB>(OnEventB);

            mTypeEventSystem.Register<IEventGroup>(group =>
            {
                Debug.Log(group.GetType());
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void OnEventB(EventB e)
        {
            Debug.Log("OnEventB" + e.ParamB);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                mTypeEventSystem.Send<EventA>();
            }

            if(Input.GetMouseButtonDown(1))
            {
                mTypeEventSystem.Send<EventB>(new EventB()
                {
                    ParamB = 123
                });
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                mTypeEventSystem.Send<IEventGroup>(new EventC());
                mTypeEventSystem.Send<IEventGroup>(new EventD());
            }
        }

        private void OnDestroy()
        {
            mTypeEventSystem.UnRegister<EventB>(OnEventB);
            mTypeEventSystem = null;
        }
    }
}

