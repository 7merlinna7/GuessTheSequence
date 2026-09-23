using Assets._Project.Develop.Runtime.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer _container;

        public override IEnumerator Initialize(DIContainer container)
        {
            _container = container;
            yield break;
        }

        public override void Run()
        {
            //start sceni
        }
    }
}