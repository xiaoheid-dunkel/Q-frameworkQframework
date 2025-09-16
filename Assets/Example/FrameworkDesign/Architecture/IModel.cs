using UnityEngine;

namespace FrameworkDesign
{
    public interface IModel : IBelongToArchitecture
    {
        void Init();
    }
}