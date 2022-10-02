using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager 
{
    public const string Splash = "Splash";
    public const string Home = "Home";
    public const string GameScene = "GameScene";

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}
