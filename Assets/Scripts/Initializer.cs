using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initializer : MonoBehaviour
{
    private const string LOADING_SCREEN_NAME = "GameManager";

    private static bool loadAgian = false;
    private void Awake()
    {
        if (!loadAgian)
        {
            loadAgian = true;
            Scene loadingScreenScene = SceneManager.GetSceneByName(LOADING_SCREEN_NAME);
            if (loadingScreenScene == null  || !loadingScreenScene.isLoaded)
            {
                SceneManager.LoadScene(LOADING_SCREEN_NAME, LoadSceneMode.Additive);
            }
        }
        
    }
}
