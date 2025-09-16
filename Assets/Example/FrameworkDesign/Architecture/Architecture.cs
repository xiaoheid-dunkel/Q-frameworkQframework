using System;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign
{
    public interface IArchitecture
    {
        void RegisterModel<T>(T instance) where T : IModel;

        void RegisterUtility<T>(T instance);

        T GetUtility<T>() where T : class;
    }

    public abstract class Architecture<T> : IArchitecture where T : Architecture<T>, new()
    {
        private bool mInited = false;

        private List<IModel> mModels = new List<IModel>();

        public void RegisterModel<T>(T instance) where T : IModel
        {
            instance.Architecture = this;
            mContainer.Register<T>(instance);

            if (mInited)
            {
                instance.Init();
            }
            else
            {
                mModels.Add(instance);
            }
        }

        #region 类似于单列模式 仅在内部访问
        public static Action<T> OnRegisterPatch = architecture => { };

        private static T mArchitecture = null;

        static void MakeSureArchitecture()
        {
            if(mArchitecture == null)
            {
                mArchitecture = new T();
                mArchitecture.Init();

                OnRegisterPatch?.Invoke(mArchitecture);

                foreach (var architectureModel in mArchitecture.mModels)
                {
                   architectureModel.Init();
                }

                mArchitecture.mModels.Clear();
                mArchitecture.mInited = true;
            }
        }
        #endregion

        private IOCContainer mContainer = new IOCContainer();

        protected abstract void Init();

        public static void Register<T> (T instance)
        {
            MakeSureArchitecture();
            mArchitecture.mContainer.Register<T>(instance);
        }

        public void RegisterUtility<T>(T instance)
        {
            mContainer.Register<T>(instance);
        }

        public T GetUtility<T>() where T : class
        {
            return mContainer.Get<T>();
        }

        public static T Get<T>() where T : class
        {
            MakeSureArchitecture();
            return mArchitecture.mContainer.Get<T>();
        }

    }

}