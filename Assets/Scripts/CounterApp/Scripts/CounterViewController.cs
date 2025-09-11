using System;
using UnityEngine;
using UnityEngine.UI;
using FrameworkDesign;

namespace CounterApp
{
    public class CounterViewController : MonoBehaviour
    {
        private void Start()
        {
            CounterModel.Count.OnValueChanged += OnCountChanged;

            transform.Find("BtnAdd").GetComponent<Button>().
                onClick.AddListener(() =>
                {
                    CounterModel.Count.Value++;
                });

            transform.Find("BtnSub").GetComponent<Button>().
                onClick.AddListener(() =>
                {
                    CounterModel.Count.Value--;
                });

            OnCountChanged(CounterModel.Count.Value);
        }

        private void OnCountChanged(int newValue)
        {
            transform.Find("CountText").GetComponent<Text>().text = newValue.ToString();    
        }

        private void OnDestroy()
        {
            CounterModel.Count.OnValueChanged -= OnCountChanged;
        }

    }

    public static class CounterModel
    {
        public static BindableProperty<int> Count = new BindableProperty<int>() { Value = 0 };
    }

    public class OnCountChangedEvent : Event<OnCountChangedEvent>
    {

    }
}
