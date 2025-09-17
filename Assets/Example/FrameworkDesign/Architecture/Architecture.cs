using System;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign
{
    public interface IArchitecture
    {
        void RegisterSystem<T>(T instance) where T : ISystem;

        void RegisterModel<T>(T instance) where T : IModel;

        void RegisterUtility<T>(T instance);

        T GetModel<T>() where T : class, IModel;

        T GetUtility<T>() where T : class;

        void SendCommand<T>() where T : ICommand, new();

        void SendCommand<T>(T command) where T : ICommand;
    }

    public abstract class Architecture<T> : IArchitecture where T : Architecture<T>, new()
    {
       
        private bool mInited = false;

        protected List<ISystem> mSystems = new List<ISystem>();

        public void RegisterSystem<T>(T instance) where T : ISystem
        {
            instance.SetArchitecture(this);
            mContainer.Register<T>(instance);

            if (mInited)
            {
                instance.Init();
            }
            else
            {
                mSystems.Add(instance);
            }
        }

        private List<IModel> mModels = new List<IModel>();

        public void RegisterModel<T>(T instance) where T : IModel
        {
            instance.SetArchitecture(this);
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

        private static T mArchitecture;

        public static IArchitecture Interface
        {
            get
            {
                if (mArchitecture == null)
                {
                    MakeSureArchitecture();
                }
                return mArchitecture;
            }
        }

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

                foreach (var architectureSystem in mArchitecture.mSystems)
                {
                    architectureSystem.Init();
                }

                mArchitecture.mSystems.Clear();

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

        public T GetModel<T>() where T : class, IModel
        {
            return mContainer.Get<T>();
        }

        public void SendCommand<T>() where T : ICommand, new()
        {
            T command = new T();
            command.SetArchitecture(this);
            command.Execute();
        }

        public void SendCommand<T>(T command) where T : ICommand
        {
            command.SetArchitecture(this);
            command.Execute();
        }

        public static T Get<T>() where T : class
        {
            MakeSureArchitecture();
            return mArchitecture.mContainer.Get<T>();
        }

    }

}