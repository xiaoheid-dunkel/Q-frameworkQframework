using UnityEngine;
using FrameworkDesign;
using CounterApp;

namespace CounterApp
{
    public class CounterApp :Architecture<CounterApp>
    {
        protected override void Init()
        {
            // 1. 先注册工具
            RegisterUtility<IStorage>(new PlayerPrefsStorage());

            // 2. 再注册模型
            RegisterModel<ICounterModel>(new CounterModel());

            // 3. 最后注册系统
            RegisterSystem<IAchievementSystem>(new AchievementSystem());
        }
    }

}