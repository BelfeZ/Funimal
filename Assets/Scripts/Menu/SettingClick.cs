using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingClick : MonoBehaviour
{
    private GameObject settingTrans;
    private SoundManager _soundManager;

    private void Start()
    {
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        settingTrans = GameObject.FindGameObjectWithTag("Setting").gameObject;
    }

    public void SettingButton()
    {
        SoundManager.instace.Play(SoundManager.SoundName.UiClick);
        settingTrans.SetActive(true);
    }

    public void BackSetting()
    {
        SoundManager.instace.Play(SoundManager.SoundName.UiClick);
        settingTrans.SetActive(false);
    }
}
