using FrameworkDesign;
using UnityEngine;

namespace CounterApp
{
    public class AddCountCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<ICounterModel>().Count.Value++;

        }
    }
}