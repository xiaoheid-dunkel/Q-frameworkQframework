using System;

namespace FrameworkDesign
{
    public interface ICommand : IBelongToArchitecture, ICanSetArchitecture,ICanGetSystem,ICanGetModel
        ,ICanGetUtility,ICanSendEvent,ICanSendCommand
    {
        void Execute();
    }

    public abstract class AbstractCommand : ICommand
    {
        private IArchitecture mArchitecture;
        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return mArchitecture;
        }
        void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
        {
            mArchitecture = architecture;
        }
        void ICommand.Execute()
        {
            OnExecute();
        }
        protected abstract void OnExecute();
    }
}