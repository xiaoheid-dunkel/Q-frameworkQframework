using FrameworkDesign;
using UnityEngine;

namespace CounterApp
{
    public interface IAchievementSystem : ISystem
    {

    }

    public class AchievementSystem : AbstractSystem, IAchievementSystem
    {
        protected override void OnInit()
        {
            Debug.Log("CounterApp.AchievemwentSystem");
            var counterModel = this.GetModel<ICounterModel>();

            counterModel.Count.mOnValueChanged += newCount =>
            {
                if (newCount >= 10)
                {
                    Debug.Log("Achievement Unlocked: Count reached 10!");
                }
            };
        }
    }

}