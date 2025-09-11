using UnityEngine;
using UnityEngine.UI;

namespace CounterApp
{
    public class CounterViewController : MonoBehaviour
    {
        private void Start()
        {
            transform.Find("BtnAdd").GetComponent<Button>().
                onClick.AddListener(() =>
                {
                    CounterModel.Count++;

                    UpdateView();
                });

            transform.Find("BtnSub").GetComponent<Button>().
                onClick.AddListener(() =>
                {
                    CounterModel.Count--;

                    UpdateView();
                });

            UpdateView();
        }

        void UpdateView()
        {
            transform.Find("CountText").GetComponent<Text>().text = CounterModel.Count.ToString();
        }
    }

    public static class CounterModel
    {
        public static int Count = 0;
    }
}
