using System;
using System.Collections;
using CodeBase.Infrastructure.CoroutineAccess;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Loader
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;
        
        public SceneLoader(ICoroutineRunner coroutineRunner) => 
            _coroutineRunner = coroutineRunner;
        
        public void Load(string sceneName, Action onLoaded = null) => 
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));

        private IEnumerator LoadScene(string nextScene, Action onLoaded)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            while (!waitNextScene.isDone)
                yield return null;
            onLoaded?.Invoke();
        }
    }
}