using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager :  SingletonMonoBehaviour<GameManager>
{

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        EventManager.Instance.TriggerEvent("OnSceneLoaded", sceneName);
    }
    
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        EventManager.Instance.TriggerEvent("OnGameQuit");
    }
    
}
