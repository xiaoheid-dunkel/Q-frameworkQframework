using UnityEngine;
using FrameworkDesign;
using CounterApp;

namespace CounterApp
{
    public class CounterApp :Architecture<CounterApp>
    {
        protected override void Init()
        {
            // 1. ��ע�Ṥ��
            RegisterUtility<IStorage>(new PlayerPrefsStorage());

            // 2. ��ע��ģ��
            RegisterModel<ICounterModel>(new CounterModel());

            // 3. ���ע��ϵͳ
            RegisterSystem<IAchievementSystem>(new AchievementSystem());
        }
    }

}