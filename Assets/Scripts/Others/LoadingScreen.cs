using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public GameObject loadingScene;
    public Image loadingBarFill;
    private SoundManager _soundManager;
    private bool loadingSceneSuccess = false;
    //private AllMenu _allMenu;

    private void Start()
    {
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        //_allMenu = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AllMenu>();

    }

    public void LoadScene(int sceneId)
    {
        loadingScene.SetActive(true);
        SoundManager.instace.Play(SoundManager.SoundName.UiClick);
        StartCoroutine(LoadSceneAsync(sceneId));

    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBarFill.fillAmount = progressValue;
            yield return new WaitForSeconds(3f);
        }
        
    }

    
}
