using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example
{
    public class GameStartPanel : MonoBehaviour
    {
        public GameObject Enemies;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            transform.Find("BtnGameStart").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    gameObject.SetActive(false);

                    new GameStartCommand().Execute();
                });
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
