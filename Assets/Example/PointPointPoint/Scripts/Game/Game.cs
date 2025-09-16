using UnityEngine;

namespace FrameworkDesign.Example
{
    public class Game : MonoBehaviour
    {
        private void Start()
        {
            GameStartEvent.Register(OnGameStart);
        }

        private void OnGameStart()
        {
            transform.Find("Enemies").gameObject.SetActive(true);   
        }

        private void OnDestroy()
        {
            GameStartEvent.UnRegister(OnGameStart);
        }
    }
}