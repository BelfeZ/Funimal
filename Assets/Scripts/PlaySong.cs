using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySong : MonoBehaviour
{
    private SoundManager _soundManager;
    void Start()
    {
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        
        SoundManager.instace.Play(SoundManager.SoundName.MainMenu);
    }
    
}
