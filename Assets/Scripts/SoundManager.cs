using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;
        public static SoundManager instace;
        public enum SoundName
        {
            UiClick,
            ButtonClick,
            ButtonClick2,
            Menu,
            UseItem,
            NoItem,
            PickUp,
            Equip,
            MainMenu,
            ThemeSong,
            Buy,
            Shop,
            BattleSong,
            DialougePop,
            DialougeNext,
            clickBattle,
            BuffAtk,
            BuffDef,
            Debuff,
            Debuff2,
            normalAttack,
            mageAttack,
            heavyAttack,
            magicBolt,
            iceBolt,
            thunderBolt,
            Tackle,
            ChargeTackle,
            TripleSlash,
        }
    
        //How to use > SoundManager.instace.Play( SoundManager.SoundName.sound name); <//
        private void Awake()
        {
            if (instace == null)
            {
                instace = this;
            }
            else
            {
                Destroy( this );
                return;
            }
            //DontDestroyOnLoad( gameObject );
        }
        /*void Start()
        {
            //play BGM1
            Play(SoundName.BGM1);
        }*/
    
        public void Play(SoundName name)
        {
            Sound sound = GetSound(name);
            if (sound.audioSource == null)
            {
                sound.audioSource = gameObject.AddComponent<AudioSource>();

                sound.audioSource.outputAudioMixerGroup = sound.AudioMixerGroup;
                sound.audioSource.clip = sound.clip;
                sound.audioSource.volume = sound.volume;
                sound.audioSource.loop = sound.loop;
                
            }
            
            sound.audioSource.Play();
        }

        public void Stop(SoundName name)
        {
            Sound sound = GetSound(name);
            sound.audioSource.Stop();
        }
    
        private Sound GetSound( SoundName name)
        {
            return Array.Find(sounds, s => s.soundName == name);
        }
        
        
}

