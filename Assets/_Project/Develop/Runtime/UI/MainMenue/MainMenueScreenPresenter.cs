using Assets._Project.Develop.Runtime.UI.Core;

namespace Assets._Project.Develop.Runtime.UI.MainMenue
{
    public class MainMenueScreenPresenter : IPresenter
    {
        MainMenueScreenView _screen;

        public MainMenueScreenPresenter(MainMenueScreenView screen)
        {
            _screen = screen;
        }

        public void Initialize()
        {

        }

        public void Dispose()
        {
            
        }

    }
}