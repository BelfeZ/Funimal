using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{
    private GameObject _blackScreen;
    public Message[] messages;
    public Actor[] actors;
    

    

    public void StartDialogue()
    {
        FindObjectOfType<DialougeManager>().OpenDialougue(messages,actors);
    }
}

[System.Serializable]
public class Message
{
    public int actorId;
    public string message;
}
    
[System.Serializable]
public class Actor
{
    public string name;
    public Sprite Sprite;
}

