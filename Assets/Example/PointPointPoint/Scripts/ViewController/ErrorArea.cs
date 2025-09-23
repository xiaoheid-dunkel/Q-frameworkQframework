using UnityEngine;

namespace FrameworkDesign.Example
{
    public class ErrorArea : MonoBehaviour,IController
    {
        private void OnMouseDown()
        {
            Debug.Log("OnClick");
            this.SendCommand<MissCommand>();
        }

        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }
    }

}