using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive : MonoBehaviour
{
    [SerializeField] private RectTransform reviveBox;
    [SerializeField] private MonsterBase swordMan;
    [SerializeField] private MonsterBase mage;
    private PlayerInventory _playerInventory;
    private SoundManager _soundManager;

    private void Awake()
    {
        reviveBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
    }

    void Start()
    {
        _playerInventory = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<PlayerInventory>();
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Cursor.visible = true;
            reviveBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            reviveBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            Cursor.visible = false;
        }
        
    }

    public void ConfirmRevive()
    {
        if (swordMan.IsAlive == false && _playerInventory.coin >= 100 || mage.IsAlive == false && _playerInventory.coin >= 100)
        {
            SoundManager.instace.Play(SoundManager.SoundName.BuffAtk);
            _playerInventory.coin -= 100;
            if (swordMan.IsAlive == false)
            {
                swordMan.IsAlive = true;
                swordMan.CurrentHp = swordMan.MaxHp;
                swordMan.CurrentSp = swordMan.MaxSp;
                reviveBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }
            else if (mage.IsAlive == false)
            {
                mage.IsAlive = true;
                mage.CurrentHp = mage.MaxHp;
                mage.CurrentSp = mage.MaxSp;
                reviveBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }

        }
        else
        {
            SoundManager.instace.Play(SoundManager.SoundName.NoItem);
        }
    }

    public void CancelRevive()
    {
        Cursor.visible = false;
        reviveBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
    }
}
