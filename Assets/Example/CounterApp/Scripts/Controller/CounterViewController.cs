using System;
using UnityEngine;
using UnityEngine.UI;
using FrameworkDesign;

namespace CounterApp
{
    public class CounterViewController : MonoBehaviour,IController
    {
        private ICounterModel mCounterModel;
        private void Start()
        {
            mCounterModel = GetArchitecture().GetModel<ICounterModel>();

            mCounterModel.Count.OnValueChanged += OnCountChanged;

            transform.Find("BtnAdd").GetComponent<Button>().
                onClick.AddListener(() =>
                {
                    GetArchitecture().SendCommand<AddCountCommand>();
                });

            transform.Find("BtnSub").GetComponent<Button>().
                onClick.AddListener(() =>
                {
                    GetArchitecture().SendCommand<SubCountCommand>();
                });

            OnCountChanged(mCounterModel.Count.Value);
        }

        private void OnCountChanged(int newValue)
        {
            transform.Find("CountText").GetComponent<Text>().text = newValue.ToString();    
        }

        private void OnDestroy()
        {
            mCounterModel.Count.OnValueChanged -= OnCountChanged;

            mCounterModel = null;
        }
        
        public IArchitecture GetArchitecture()
        {
            return CounterApp.Interface;
        }

    }

    public interface ICounterModel : IModel
    {
        BindableProperty<int> Count { get; }
    }

    public class CounterModel : AbstractModel, ICounterModel
    {
        protected override void OnInit()
        {
            var storage = GetArchitecture().GetUtility<IStorage>();

            Count.Value = storage.LoadInt("COUNTER_COUNT", 0);

            Count.OnValueChanged += count =>
            {
                storage.SaveInt("COUNTER_COUNT", count);
            };
        }

        public BindableProperty<int> Count { get; } = new BindableProperty<int>() { Value = 0 };
    }

    public class OnCountChangedEvent : Event<OnCountChangedEvent>
    {

    }
}
