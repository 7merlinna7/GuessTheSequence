using Assets._Project.Develop.Runtime.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using System.Collections;

namespace Assets._Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private MainMenu _mainMenu;
        private PurchaseResetStatisticChecker _purchaseChecker;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenueContextRegistrations.Process(_container);
        }

        public override IEnumerator Initialize()
        {
            _mainMenu = _container.Resolve<MainMenu>();
            _purchaseChecker = _container.Resolve<PurchaseResetStatisticChecker>();

            yield break;
        }

        public override void Run()
        {
            _mainMenu.Start();
            _purchaseChecker.Start();
        }
    }
}