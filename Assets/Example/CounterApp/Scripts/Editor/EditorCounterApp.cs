using FrameworkDesign;
using UnityEditor;
using UnityEngine;

namespace CounterApp
{
    public class EditorCounterApp : EditorWindow,IController
    {
        [MenuItem("EditorCounterApp/Open")]
        static void Open()
        {
            CounterApp.OnRegisterPatch += (architecture) =>
            {
                architecture.RegisterUtility<IStorage>(new EditorPrefsStorage());
            };
            var editorCounterApp = GetWindow<EditorCounterApp>();
            editorCounterApp.name = nameof(EditorCounterApp);
            editorCounterApp.position = new Rect(100, 100, 400, 600);
            editorCounterApp.Show();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("+"))
            {
                GetArchitecture().SendCommand<AddCountCommand>();
            }

            GUILayout.Label(CounterApp.Get<ICounterModel>().Count.Value.ToString());

            if(GUILayout.Button("-"))
            {
                GetArchitecture().SendCommand<SubCountCommand>();
            }
        }

        public IArchitecture GetArchitecture()
        {
            return CounterApp.Interface;
        }
    }
}