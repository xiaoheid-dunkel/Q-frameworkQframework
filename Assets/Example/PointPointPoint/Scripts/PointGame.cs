using UnityEngine;

namespace FrameworkDesign.Example
{
    public class PointGame : Architecture<PointGame>
    {
        protected override void Init()
        {
            Debug.Log("PointGameInit");

            Register<IScoreSystem>(new ScoreSystem());

            Register<IGameModel>(new GameModel());

            Register<IStorage>(new PlayerPrefsStorage());

        }
    }

}