using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private SoundManager _soundManager;
    private AllMenu _allMenu;

    private void Start()
    {
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        _allMenu = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AllMenu>();
    }

    public void PlayGame()
    {
        Cursor.visible = false;
        SoundManager.instace.Play(SoundManager.SoundName.UiClick);
        SceneManager.LoadScene("MainStage");
        
        _allMenu.notMainMenu = true;
        
    }

    public void ExitGame()
    {
        SoundManager.instace.Play(SoundManager.SoundName.UiClick);
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void BackMainMenu()
    {
        Time.timeScale = 1f;
        SoundManager.instace.Play(SoundManager.SoundName.UiClick);
        SceneManager.LoadScene("MainMenu");
        _allMenu.notMainMenu = false;
        _allMenu.menu.SetActive(false);
        _allMenu.equip.SetActive(false);
        _allMenu.inventory.SetActive(false);
        _allMenu.status.SetActive(false);
        _allMenu.weapon.SetActive(false);
        _allMenu.artifact.SetActive(false);
        _allMenu.makeSure.SetActive(false);
        _allMenu.setting.SetActive(false);
        _allMenu.menuActive = false;
    }
    
}
