using System;
using UnityEngine;
using UnityEngine.Audio;

namespace DefaultNamespace
{
    [Serializable]
    public class Sound
    {
        public SoundManager.SoundName soundName;
        public AudioClip clip;
        [Range(0f,1f)]public float volume;
        public AudioMixerGroup AudioMixerGroup;
        public bool loop;
        [HideInInspector]public AudioSource audioSource;
    }
}