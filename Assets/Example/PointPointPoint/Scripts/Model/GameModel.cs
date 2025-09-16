namespace FrameworkDesign.Example
{
    public interface IGameModel
    {
        BindableProperty<int> KillCount { get; }
        BindableProperty<int> Gold {  get; }
        BindableProperty<int> Score { get; }
        BindableProperty<int> BaseScore { get; }
    }


    public class GameModel : IGameModel
    {
        public BindableProperty<int> KillCount { get; } = new BindableProperty<int>() { Value = 0 };
        public BindableProperty<int> Gold { get; } = new BindableProperty<int>() { Value = 0 };
        public BindableProperty<int> Score { get; } = new BindableProperty<int>() { Value = 0 };
        public BindableProperty<int> BaseScore { get; } = new BindableProperty<int>() { Value = 0 };
    }
}