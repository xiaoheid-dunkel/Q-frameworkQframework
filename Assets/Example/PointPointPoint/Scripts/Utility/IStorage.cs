using Unity.Collections;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public interface IStorage : IUtility
    {
        void SaveInt(string key, int value);

        int LoadInt(string key, int defaultValue = 0);
    }

    public class PlayerPrefsStorage : IStorage
    {
        public int LoadInt(string key, int defaultValue = 0)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }

        public void SaveInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }
    }

}