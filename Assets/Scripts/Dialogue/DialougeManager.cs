using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;


public class DialougeManager : MonoBehaviour
{
   public Image actorImage;
   public TMP_Text actorName;
   public TMP_Text messageText;
   public RectTransform backgroundBox;
   private bool blackScreenActive = false;
   public GameObject blackScreen;
   public bool blackScreenRun;


   public Npc[] Npcs;
   Message[] currentMessages;
   Actor[] currentActors;
   int activeMessage = 0;
   public static bool isActive = false;
   
   
   public void OpenDialougue(Message[] messages, Actor[] actors)
   {
      for (int i = 0; i < Npcs.Length; i++)
      {
         if (Npcs[i].blackScreenRun)
         {
            blackScreen.LeanScale(Vector3.one, 0.1f).setEaseInOutExpo();
         }
      }
      SoundManager.instace.Play(SoundManager.SoundName.DialougePop);
      
      currentMessages = messages;
      currentActors = actors;
      activeMessage = 0;
      isActive = true;
      Debug.Log("Started conversation! Loaded messages:" + messages.Length);
      DisplayMessage();
      backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();;
      
   }

   private void DisplayMessage()
   {
      
      Message messageToDisplay = currentMessages[activeMessage];
      messageText.text = messageToDisplay.message;
      messageText.text = ThaiFontAdjuster.Adjust(messageToDisplay.message);

      Actor actorToDisplay = currentActors[messageToDisplay.actorId];
      actorName.text = actorToDisplay.name;
      actorImage.sprite = actorToDisplay.Sprite;
      
      AnimateTextColor();
   }

   public void NextMessage()
   {
      activeMessage++;
      if (activeMessage < currentMessages.Length)
      {
         SoundManager.instace.Play(SoundManager.SoundName.DialougeNext);
         DisplayMessage();
      }
      else
      {
         Debug.Log("Comversation ended");
         backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
         blackScreen.LeanScale(Vector3.zero, 0.1f).setEaseInOutExpo();
         isActive = false;
         
         for (int i = 0; i < Npcs.Length; i++)
         {
            if (Npcs[i].blackScreenRun == true)
            {
               Npcs[i].blackScreenRun = false;
            }
         }
         
         for (int i = 0; i < Npcs.Length; i++)
         {
            if (Npcs[i].destroyRun == true)
            {
               Npcs[i].destroyRun = false;
               Npcs[i]._gameObject.SetActive(false);
            }
         }
         
         for (int i = 0 ; i < Npcs.Length; i++)
         {
            if (Npcs[i].oneTimeActive != false)
            {
               Npcs[i].oneTimeActive = false;
               Destroy(Npcs[i].gameObject);
               break;
            }
         }
      }
   }

   void AnimateTextColor()
   {
      LeanTween.textAlpha(messageText.rectTransform, 0, 0);
      LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
   }

   

   private void Start()
   {
      backgroundBox.transform.localScale = Vector3.zero;
      blackScreen.transform.localScale = Vector3.zero;
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
      {
         NextMessage();
      }
   }
}
