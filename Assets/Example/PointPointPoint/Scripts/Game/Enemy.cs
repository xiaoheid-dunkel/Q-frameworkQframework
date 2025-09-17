using UnityEngine;

namespace FrameworkDesign.Example
{
    public class Enemy : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Destroy(gameObject);

            GetArchitecture().SendCommand<KillEnemyCommand>();
  
        }

        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }
    }
}