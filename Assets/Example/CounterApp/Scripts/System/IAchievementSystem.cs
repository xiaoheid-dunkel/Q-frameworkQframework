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
            var counterModel = GetArchitecture().GetModel<ICounterModel>();

            counterModel.Count.OnValueChanged += newCount =>
            {
                if (newCount >= 10)
                {
                    Debug.Log("Achievement Unlocked: Count reached 10!");
                }
            };
        }
    }

}