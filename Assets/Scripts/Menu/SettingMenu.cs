using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
        
    public void SetVolumeSong(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    
    public void SetVolumeUI(float volume)
    {
        audioMixer.SetFloat("UI", volume);
    }

    public void SetVolumeSFX(float volume)
    {
        audioMixer.SetFloat("sfx", volume);
    }
}
