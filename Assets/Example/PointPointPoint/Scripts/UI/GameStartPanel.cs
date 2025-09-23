using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example
{
    public class GameStartPanel : MonoBehaviour,IController
    {
        public GameObject Enemies;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            transform.Find("BtnGameStart").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    gameObject.SetActive(false);

                    this.SendCommand<GameStartCommand>();
                });
        }

        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }
        // is called before the first execution of Update

        // Update is called once per frame
        
        void Update()
        {
            
        }
    }

}
