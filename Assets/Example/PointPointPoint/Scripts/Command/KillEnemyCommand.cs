namespace FrameworkDesign.Example
{
    public class KillEnemyCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = GetArchitecture().GetModel<IGameModel>();

            gameModel.KillCount.Value++;

            if(gameModel.KillCount.Value == 10)
            {
                GamePassEvent.Trigger();
            }
        }
    }

}