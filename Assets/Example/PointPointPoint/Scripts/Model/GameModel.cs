using UnityEngine.InputSystem.HID;

namespace FrameworkDesign.Example
{
    public interface IGameModel : IModel
    {
        BindableProperty<int> KillCount { get; }
        BindableProperty<int> Gold {  get; }
        BindableProperty<int> Score { get; }
        BindableProperty<int> BeseScore { get; }

        BindableProperty<int> Life { get; }
    }


    public class GameModel : AbstractModel, IGameModel
    {
        public BindableProperty<int> KillCount { get; } = new BindableProperty<int>() { Value = 0 };
        public BindableProperty<int> Gold { get; } = new BindableProperty<int>() { Value = 0 };
        public BindableProperty<int> Score { get; } = new BindableProperty<int>() { Value = 0 };
        public BindableProperty<int> BeseScore { get; } = new BindableProperty<int>() { Value = 0 };
        public BindableProperty<int> Life { get; } = new BindableProperty<int> { Value = 3 };

        protected override void OnInit()
        {
            var storage = this.GetUtility<IStorage>();

            BeseScore.Value = storage.LoadInt(nameof(BeseScore), 0);
            BeseScore.RegisterOnValueChanged(v => storage.SaveInt(nameof(BeseScore), v));

            Life.Value = storage.LoadInt(nameof(Life), 3);
            Life.RegisterOnValueChanged(v => storage.SaveInt(nameof(Life), v));

            Gold.Value = storage.LoadInt(nameof(Gold), 0);
            Gold.RegisterOnValueChanged((v) => storage.SaveInt(nameof(Gold), v)); 
        }
    }
}