using System.Collections;
using System.Collections.Generic;
using _Project.Code.Architecture;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace _Project.Code.Core
{
    public class LevelFinish : MonoBehaviour
    {
        [Inject] private CoroutineRunner _coroutineRunner;
        [Inject] private ISceneLoader _sceneLoader;
        [Inject] private LoadingCurtain _loadingCurtain;
    
        private bool _isTriggered;

        public void Trgger()
        {
            if (_isTriggered) return;
            
            _coroutineRunner.StartCoroutine(SwitchScene());            
            
            _isTriggered = true;
        }
        
        private IEnumerator SwitchScene()
        {
            yield return _loadingCurtain.Show();
            yield return _sceneLoader.LoadAsync(SceneID.Gameplay3D);
            yield return _loadingCurtain.Hide();
        }
    }
}