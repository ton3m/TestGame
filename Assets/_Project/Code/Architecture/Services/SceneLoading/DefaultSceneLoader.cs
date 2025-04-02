using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Code.Architecture
{
    public class DefaultSceneLoader : ISceneLoader
    {
        public IEnumerator LoadAsync(SceneID sceneID, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            AsyncOperation waitLoading = SceneManager.LoadSceneAsync(sceneID.ToString(), loadSceneMode);

            while(waitLoading.isDone == false)
                yield return null;
        }

        public IEnumerator UnloadAsync(SceneID sceneID)
        {
            AsyncOperation waitLoading = SceneManager.UnloadSceneAsync(sceneID.ToString());

            while (waitLoading.isDone == false)
                yield return null;
        }
    }
}