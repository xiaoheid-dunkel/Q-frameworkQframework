using UnityEngine;

namespace FrameworkDesign.Example
{
    public class Enemy : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Destroy(gameObject);

            KilledOneEnemyEvent.Trigger();

            Debug.Log(GameModel.KillCount);
  
        }
    }
}