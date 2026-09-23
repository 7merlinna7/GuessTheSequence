using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._Project.Develop.Runtime.Utilities.SceneManagment
{
    public class SceneLoaderService 
    {
        public IEnumerator LoadeAcync(string sceneName,LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            AsyncOperation wait = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);

            yield return new WaitWhile(()=> wait.isDone == false);
        }

        public IEnumerator UnLoadeAcync(string sceneName)
        {
            AsyncOperation wait = SceneManager.UnloadSceneAsync(sceneName);

            yield return new WaitWhile(() => wait.isDone == false);
        }
    }
}