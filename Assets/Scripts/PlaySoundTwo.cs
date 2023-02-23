using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundTwo : MonoBehaviour
{
    private SoundManager _soundManager;
    public bool soundPlay;
    void Start()
    {
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        
        
    }

    private void Update()
    {
        if (DialougeManager.isActive == true)
        {
            return;
        }
        
        if (!soundPlay)
        {
            SoundManager.instace.Play(SoundManager.SoundName.ThemeSong);
            soundPlay = true;
        }
        
        
    }
}
