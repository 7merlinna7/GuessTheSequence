using Assets._Project.Develop.Runtime.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using System.Collections;

namespace Assets._Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenueBootstrap : SceneBootstrap
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