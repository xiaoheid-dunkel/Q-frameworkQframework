using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public interface IAchievementSystem : ISystem
    {

    }

    public class AchievementItem
    {
        public string Name { get; set; }
        public Func<bool> CheckComplete {  get; set; }
        public bool Unlocked { get; set; }
    }

    public class AchievementSystem : AbstractSystem, IAchievementSystem
    {
        private List<AchievementItem> mitems= new List<AchievementItem>();
        private bool mMissed = false;

        protected override void OnInit()
        {
            this.RegisterEvent<OnMissEvent>(e =>
            {
                mMissed = true;
            });

            this.RegisterEvent<GameStartEvent>(e =>
            {
                mMissed = false;
            });

            mitems.Add(new AchievementItem()
            {
                Name = "百分成就",
                CheckComplete = () => this.GetModel<IGameModel>().BeseScore.Value > 100
            });

            mitems.Add(new AchievementItem()
            {
                Name = "手残",
                CheckComplete = () => this.GetModel<IGameModel>().Score.Value < 0
            });

            mitems.Add(new AchievementItem()
            {
                Name = "零失误成就",
                CheckComplete = () => !mMissed
            });

            mitems.Add(new AchievementItem()
            {
                Name = "零失误成就",
                CheckComplete = () => mitems.Count(item => item.Unlocked) >= 3
            });

            this.RegisterEvent<GamePassEvent>(async e =>
            {
                await Task.Delay(TimeSpan.FromSeconds(0.1f));
                foreach (var achievementItem in mitems)
                {
                    if (!achievementItem.Unlocked && achievementItem.CheckComplete())
                    {
                        achievementItem.Unlocked = true;

                        Debug.Log(achievementItem.Name);
                    }
                }
            });
        }
    }
}
