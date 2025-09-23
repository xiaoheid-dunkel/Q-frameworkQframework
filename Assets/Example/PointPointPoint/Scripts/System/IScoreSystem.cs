using UnityEngine;

namespace FrameworkDesign.Example
{
    public interface IScoreSystem : ISystem
    {

    }

    public class ScoreSystem : AbstractSystem, IScoreSystem
    {
        protected override void OnInit()
        {
            var gameModel = this.GetModel<IGameModel>();

            // 监听事件
            this.RegisterEvent<GamePassEvent>(e =>
            {
                Debug.Log("Score:" + gameModel.Score.Value);
                Debug.Log("BestScore:" + gameModel.BeseScore.Value);

                if (gameModel.Score.Value > gameModel.BeseScore.Value)
                {
                    Debug.Log("新纪录");
                    gameModel.BeseScore.Value = gameModel.Score.Value;
                }
            });

            this.RegisterEvent<OnKillEnemyEvent>(e =>
            {
                gameModel.Score.Value += 10;
                Debug.Log("得分:10");
                Debug.Log("当前分数:" + gameModel.Score.Value);


            });

            this.RegisterEvent<OnMissEvent>(e =>
            {
                gameModel.Score.Value -= 5;
                Debug.Log("得分:-5");
                Debug.Log("当前分数:" + gameModel.Score.Value);
            });
        }
    }
}