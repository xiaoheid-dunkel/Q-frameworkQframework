using FrameworkDesign;
using UnityEngine;

namespace CounterApp
{
    public class AddCountCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            GetArchitecture().GetModel<ICounterModel>().Count.Value++;

        }
    }
}