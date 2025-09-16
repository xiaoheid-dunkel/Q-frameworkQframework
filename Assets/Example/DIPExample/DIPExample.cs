//using UnityEditor;
//using UnityEngine;

//namespace FrameworkDesign.Example
//{
//    public class DIPExample : MonoBehaviour
//    {
//        public interface IStorage
//        {
//            void SaveString(string key, string value);
//            string LoadString(string key, string dafaultValue = "");
//        }

//        public class  PlayerPrefsStorage : IStorage
//        { 
//            public void SaveString(string key, string value)
//            {
//                PlayerPrefs.SetString(key, value);
//            }

//            public string LoadString(string key, string defaultValue = "")
//            {
//                return PlayerPrefs.GetString(key, defaultValue);
//            }
//        }

//        public class EditorPrefsStorage : IStorage
//        {
//            public void SaveString(string key, string value)
//            {
//#if UNITY_EDITOR
//                EditorPrefs.SetString(key, value);
//#endif
//            }

//            public string LoadString(string key, string defaultValue = "")
//            {
//#if UNITY_EDITOR
//                return EditorPrefs.GetString(key, defaultValue);
//#else
//                return "";
//#endif
//            }
//        }

//        private void Start()
//        {
//            Debug.Log("DIPExample Start");

//            var container = new IOCContainer();

//            container.Register<IStorage>(new PlayerPrefsStorage());

//            var storage = container.Get<IStorage>();

//            storage.SaveString("name", "‘À–– ±¥¢¥Ê");

//            Debug.Log(storage.LoadString("name"));

//            container.Register<IStorage>(new EditorPrefsStorage());

//            storage = container.Get<IStorage>();

//            Debug.Log(storage.LoadString("name"));
//        }
//    }

//}