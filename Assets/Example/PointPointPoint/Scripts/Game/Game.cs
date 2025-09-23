using UnityEngine;

namespace FrameworkDesign.Example
{
    public class Game : MonoBehaviour,IController
    {
        private void Start()
        {
            this.RegisterEvent<GameStartEvent>(OnGameStart);
            //this.RegisterEvent<OnKillEnemyEvent>(OnKill);
        }

        private void OnGameStart(GameStartEvent e)
        {
            transform.Find("Enemies").gameObject.SetActive(true);   
        }

        //private void OnKill(OnKillEnemyEvent e)
        //{
        //    Debug.Log("OnKillEnemyEvent");
        //}

        private void OnDestroy()
        {
            this.UnRegisterEvent<GameStartEvent>(OnGameStart);
            //this.UnRegisterEvent<OnKillEnemyEvent>(OnKill);
        }

        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }
    }
}