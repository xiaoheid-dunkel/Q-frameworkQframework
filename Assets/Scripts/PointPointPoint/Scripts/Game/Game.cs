using UnityEngine;

namespace FrameworkDesign.Example
{
    public class Game : MonoBehaviour
    {
        private void Start()
        {
            GameStartEvent.Register(OnGameStart);
            KilledOneEnemyEvent.Register(OnEnemyKilled);
        }

        private void OnGameStart()
        {
            transform.Find("Enemies").gameObject.SetActive(true);   
        }

        private void OnEnemyKilled()
        {
            GameModel.KillCount++;

            if(GameModel.KillCount == 10)
            {
                GamePassEvent.Trigger();
            }
        }

        private void OnDestroy()
        {
            GameStartEvent.UnRegister(OnGameStart);
            KilledOneEnemyEvent.UnRegister(OnEnemyKilled);
        }
    }
}