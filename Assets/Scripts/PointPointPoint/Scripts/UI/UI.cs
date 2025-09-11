using UnityEngine;

namespace FrameworkDesign.Example
{
    public class UI : MonoBehaviour
    {
        private void Start()
        {
            GamePassEvent.Register(OnGamePass);
        }

        private void OnGamePass()
        {
            transform.Find("GamePassPanel").gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            GamePassEvent.UnRegister(OnGamePass);
        }
    }
}