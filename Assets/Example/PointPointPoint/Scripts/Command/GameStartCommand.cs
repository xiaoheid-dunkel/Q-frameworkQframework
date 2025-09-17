namespace FrameworkDesign.Example
{
    public class GameStartCommand : AbstractCommand,ICommand
    {
        protected override void OnExecute()
        {
            GameStartEvent.Trigger();
        }
    }

}