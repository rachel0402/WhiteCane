using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    private string sceneName;

    public void SceneLoadActive()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void GetSceneName(string sceneNameValue)
    {
        sceneName = sceneNameValue;
    }
}
