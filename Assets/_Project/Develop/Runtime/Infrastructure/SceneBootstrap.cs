using Assets._Project.Develop.Runtime.Infrastructure.DI;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Infrastructure
{
    public abstract class SceneBootstrap : MonoBehaviour
    {
        public abstract IEnumerator Initialize(DIContainer container);

        public abstract void Run();
    }
}