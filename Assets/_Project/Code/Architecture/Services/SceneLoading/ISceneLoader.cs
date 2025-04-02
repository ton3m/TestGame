using System.Collections;
using UnityEngine.SceneManagement;

namespace _Project.Code.Architecture
{
    public interface ISceneLoader
    {
        IEnumerator LoadAsync(SceneID sceneID, LoadSceneMode loadSceneMode = LoadSceneMode.Single);
        IEnumerator UnloadAsync(SceneID sceneID);
    }
}