using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBattle : MonoBehaviour
{
    [SerializeField] private GameObject inventoryTrans;
    [SerializeField] private GameObject backButtonTrans;

    private PlayerInventory _playerInventory;
    private SoundManager _soundManager;
    public int playerPlay;

    [SerializeField] private MonsterBase swordMan;
    [SerializeField] private MonsterBase mage;
    [SerializeField] private BattleSystem _battleSystem;
    public GameObject normalScene;
    public GameObject battleScene;

    private BattleUnit player1Unit;
    private BattleUnit player2Unit;
    private BattleHud player1Hud;
    private BattleHud player2Hud;

    public int _swordAtkBootsActive = 2;
    public bool _swordAtkBootsActived;
    public int _mageAtkBootsActive = 2;
    public bool _mageAtkBootsActived;

    [SerializeField] private GameObject SwordImage;
    [SerializeField] private GameObject MageImage;
    

    


    public bool battleOn = false;
    private bool find;

    private void Start()
    {
        _playerInventory = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<PlayerInventory>();
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        battleScene.SetActive(false);
        normalScene.SetActive(true);
        
    }

    private void Update()
    {
        
        
        if (battleOn)
        {
            if (!find)
            {
                player1Unit = GameObject.Find("Player1Unit").GetComponent<BattleUnit>();
                player2Unit = GameObject.Find("Player2Unit").GetComponent<BattleUnit>();
                player1Hud = GameObject.Find("Player1StatusBox").GetComponent<BattleHud>();
                player2Hud = GameObject.Find("Player2StatusBox").GetComponent<BattleHud>();
                find = false;
            }
            
            if (playerPlay == 1)
            {
                SwordImage.SetActive(true);
                MageImage.SetActive(false);
            }
            else if (playerPlay == 2)
            {
                MageImage.SetActive(true);
                SwordImage.SetActive(false);
            }
            
        }
        if (_swordAtkBootsActive == 0)
        {
            _swordAtkBootsActive = 2;
            _swordAtkBootsActived = false;
            swordMan.Attack /= 2;
        }
        
        if (_mageAtkBootsActive == 0)
        {
            _mageAtkBootsActive = 2;
            _mageAtkBootsActived = false;
            mage.Attack /= 2;
        }
    }

    public void BattleInventory()
    {
        Time.timeScale = 0f;
        backButtonTrans.SetActive(false);
        Cursor.visible = true;
        inventoryTrans.SetActive(true);
    }
    
    public void CloseBattleInventory()
    {
        Time.timeScale = 1f;
        backButtonTrans.SetActive(true);
        Cursor.visible = false;
        inventoryTrans.SetActive(false);
    }
    
    public void HpPotionUse()
    {
        if (battleOn)
        {
            if (_playerInventory.hpPotion > 0)
            {
                switch (playerPlay)
                {
                    case 1 when swordMan.CurrentHp < swordMan.MaxHp:
                    {
                        _playerInventory.hpPotion -= 1;
                        swordMan.CurrentHp += 50;
                        player1Unit.monster.HP += 50;
                        SoundManager.instace.Play(SoundManager.SoundName.UseItem);
                        player1Hud.UpdateHP(player1Unit.monster);
                        if (swordMan.CurrentHp > swordMan.MaxHp && player1Unit.monster.HP > player1Unit.monster.MaxHp)
                        {
                            swordMan.CurrentHp = swordMan.MaxHp;
                            player1Unit.monster.HP = player1Unit.monster.MaxHp;
                            player1Hud.UpdateHP(player1Unit.monster);
                        }
                        Debug.Log("+HP");
                        break;
                    }
                    case 1:
                    {
                        if (swordMan.CurrentHp >= swordMan.MaxHp)
                        {
                            SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                            Debug.Log("Can't heal");
                        }

                        break;
                    }
                    case 2 when mage.CurrentHp < mage.MaxHp:
                    {
                        _playerInventory.hpPotion -= 1;
                        mage.CurrentHp += 50;
                        player2Unit.monster.HP += 50;
                        SoundManager.instace.Play(SoundManager.SoundName.UseItem);
                        player2Hud.UpdateHP(player2Unit.monster);
                        if (mage.CurrentHp > mage.MaxHp && player2Unit.monster.HP > player2Unit.monster.MaxHp)
                        {
                            mage.CurrentHp = mage.MaxHp;
                            player2Unit.monster.HP = player2Unit.monster.MaxHp;
                            player2Hud.UpdateHP(player2Unit.monster);
                        }
                        Debug.Log("+HP");
                        break;
                    }
                    case 2:
                    {
                        if (mage.CurrentHp >= mage.MaxHp)
                        {
                            SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                            Debug.Log("Can't heal");
                        }

                        break;
                    }
                }
            }
            else if (_playerInventory.hpPotion <= 0)
            {
                SoundManager.instace.Play(SoundManager.SoundName.NoItem);
            }
        }
    }
    
    public void MpPotionUse()
    {
        if (battleOn)
        {
            if (_playerInventory.mpPotion > 0)
            {
                switch (playerPlay)
                {
                    case 1 when swordMan.CurrentSp < swordMan.MaxSp:
                    {
                        _playerInventory.mpPotion -= 1;
                        swordMan.CurrentSp += 20;
                        player1Unit.monster.SP += 20;
                        SoundManager.instace.Play(SoundManager.SoundName.UseItem);
                        Debug.Log("+MP");
                        player1Hud.UpdateSP(player1Unit.monster);
                        if (swordMan.CurrentSp > swordMan.MaxSp && player1Unit.monster.SP > player1Unit.monster.MaxSp)
                        {
                            swordMan.CurrentSp = swordMan.MaxSp;
                            player1Unit.monster.SP = player1Unit.monster.MaxSp;
                            player1Hud.UpdateSP(player1Unit.monster);

                        }

                        
                        break;
                    }
                    case 1:
                    {
                        if (swordMan.CurrentSp >= swordMan.MaxSp)
                        {
                            SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                        }

                        break;
                    }
                    case 2 when mage.CurrentSp < mage.MaxSp:
                    {
                        _playerInventory.mpPotion -= 1;
                        mage.CurrentSp += 20;
                        player2Unit.monster.SP += 20;
                        SoundManager.instace.Play(SoundManager.SoundName.UseItem);
                        Debug.Log("+MP");
                        player2Hud.UpdateSP(player2Unit.monster);
                        if (mage.CurrentSp > mage.MaxSp && player2Unit.monster.SP > player2Unit.monster.MaxSp)
                        {
                            mage.CurrentSp = mage.MaxSp;
                            player2Unit.monster.SP = player2Unit.monster.MaxSp;
                            player2Hud.UpdateSP(player2Unit.monster);
                        }
                        
                        
                        break;
                    }
                    case 2:
                    {
                        if (mage.CurrentSp >= mage.MaxSp)
                        {
                            SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                        }

                        break;
                    }
                }
            }
            else if (_playerInventory.mpPotion <= 0)
            {
                SoundManager.instace.Play(SoundManager.SoundName.NoItem);
            }
        }
    }
    
    public void FullPotionUse()
    {
        if (battleOn)
        {
            if (_playerInventory.fullPotion > 0)
            {
                switch (playerPlay)
                {
                    case 1 when swordMan.CurrentHp < swordMan.MaxHp:
                        _playerInventory.fullPotion -= 1;
                        swordMan.CurrentHp = swordMan.MaxHp;
                        player1Unit.monster.HP = player1Unit.monster.MaxHp;
                        player1Hud.UpdateHP(player1Unit.monster);
                        SoundManager.instace.Play(SoundManager.SoundName.UseItem);
                        break;
                    case 1:
                    {
                        if (swordMan.CurrentHp == swordMan.MaxHp)
                        {
                            SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                            Debug.Log("Can't heal");
                        }

                        break;
                    }
                    case 2 when mage.CurrentHp < mage.MaxHp:
                        _playerInventory.fullPotion -= 1;
                        mage.CurrentHp = mage.MaxHp;
                        player2Unit.monster.HP = player2Unit.monster.MaxHp;
                        player2Hud.UpdateHP(player2Unit.monster);
                        SoundManager.instace.Play(SoundManager.SoundName.UseItem);
                        break;
                    case 2:
                    {
                        if (mage.CurrentHp == mage.MaxHp)
                        {
                            SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                            Debug.Log("Can't heal");
                        }

                        break;
                    }
                }
            }
            else if (_playerInventory.fullPotion <= 0)
            {
                SoundManager.instace.Play(SoundManager.SoundName.NoItem);
            }
        }
    }
    
    public void AtkBootsUse()
    {
        if (battleOn)
        {
            if (_playerInventory.attackBoots > 0)
            {
                switch (playerPlay)
                {
                    case 1:
                    {
                        _playerInventory.attackBoots -= 1;
                        SoundManager.instace.Play(SoundManager.SoundName.UseItem);
                        
                        SwordManAtkBoots();

                        break;
                    }
                    case 2:
                    {
                        _playerInventory.attackBoots -= 1;
                        SoundManager.instace.Play(SoundManager.SoundName.UseItem);
                        
                        MageAtkBoots();

                        break;
                    }
                }
            }
            else if (_playerInventory.attackBoots <= 0)
            {
                SoundManager.instace.Play(SoundManager.SoundName.NoItem);
            }
        }
    }
    
    public void SwordManAtkBoots()
    {
        if (!_swordAtkBootsActived)
        {
            swordMan.Attack *= 2;
            _swordAtkBootsActived = true;
        }
        else if (_swordAtkBootsActived)
        {
            _swordAtkBootsActive = 2;
        }
        
    }
    
    public void MageAtkBoots()
    {
        if (!_mageAtkBootsActived)
        {
            mage.Attack *= 2;
            _mageAtkBootsActived = true;
        }
        else if (_mageAtkBootsActived)
        {
            _mageAtkBootsActive = 2;
        }
        
    }
}
