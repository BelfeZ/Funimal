using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{

    public DialougeTrigger trigger;
    public DialougeManager dialougeManager;
    //public GameObject blackScreen;
    public bool blackScreenActive;
    public bool oneTimeDialogue;
    public bool oneTimeActive;
    public bool blackScreenRun;
    public bool destroyObject;
    public bool destroyRun;
    public GameObject _gameObject;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            
            if (oneTimeDialogue)
            {
                oneTimeActive = true;
            }

            if (blackScreenActive)
            {
                blackScreenRun = true;
            }

            if (destroyObject)
            {
                destroyRun = true;
            }
            
            trigger.StartDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (oneTimeActive)
        {
            oneTimeActive = false;
        }
        dialougeManager.backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
        DialougeManager.isActive = false;
        dialougeManager.blackScreen.LeanScale(Vector3.zero, 0.1f).setEaseInOutExpo();
    }
}