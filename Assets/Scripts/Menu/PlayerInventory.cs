using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerInventory : MonoBehaviour
{
    public bool swordOne = false;
    [SerializeField] private int swordOneAtk = 25;
    public bool swordTwo = false;
    [SerializeField] private int swordTwoAtk = 50;
    public bool swordThree = false;
    [SerializeField] private int swordThreeAtk = 75;
    public bool swordFour = false;
    [SerializeField] private int swordFourAtk = 100;
    public bool swordFive = false;
    [SerializeField] private int swordFiveAtk = 125;
    public int swordOneActive = 0;
    public int swordTwoActive = 0;
    public int swordThreeActive = 0;
    public int swordFourActive = 0;
    public int swordFiveActive = 0;
    
    public bool shieldOne = false;
    [SerializeField] private int shieldOneDef;
    public bool shieldTwo = false;
    [SerializeField] private int shieldTwoDef;
    public bool shieldThree = false;
    [SerializeField] private int shieldThreeDef;
    public bool shieldFour = false;
    [SerializeField] private int shieldFourDef;
    public bool shieldFive = false;
    [SerializeField] private int shieldFiveDef;
    public int shieldOneActive = 0;
    public int shieldTwoActive = 0;
    public int shieldThreeActive = 0;
    public int shieldFourActive = 0;
    public int shieldFiveActive = 0;
    
    public bool legOne = false;
    [SerializeField] private int legOneSpeed;
    public bool legTwo = false;
    [SerializeField] private int legTwoSpeed;
    public bool legThree = false;
    [SerializeField] private int legThreeSpeed;
    public bool legFour = false;
    [SerializeField] private int legFourSpeed;
    public bool legFive = false;
    [SerializeField] private int legFiveSpeed;
    public int legOneActive = 0;
    public int legTwoActive = 0;
    public int legThreeActive = 0;
    public int legFourActive = 0;
    public int legFiveActive = 0;

    public bool artifactOne = false;
    public bool artifactTwo = false;
    public bool artifactThree = false;
    public bool artifactFour = false;
    public bool artifactFive = false;
    public bool artifactSix = false;

    public int hpPotion = 3;
    public int mpPotion = 2;
    public int attackBoots = 1;
    public int fullPotion = 1;
    public int coin = 100;
    public TMP_Text hpPotionText;
    public TMP_Text mpPotionText;
    public TMP_Text fullPotionText;
    public TMP_Text atkBootsText;
    public TMP_Text hpPotionText2;
    public TMP_Text mpPotionText2;
    public TMP_Text fullPotionText2;
    public TMP_Text atkBootsText2;
    public TMP_Text coinText;
    public string weaponName = "";
    public string shieldName = "";
    public string legName = "";
    public string artifactName = "";
    public TMP_Text atkText;
    public TMP_Text defText;
    public TMP_Text spdText;
    public TMP_Text typeText;
    [SerializeField] private Transform weaponSlotTrans;
    [SerializeField] private Transform swordOneTrans;
    [SerializeField] private Transform swordTwoTrans;
    [SerializeField] private Transform swordThreeTrans;
    [SerializeField] private Transform swordFourTrans;
    [SerializeField] private Transform swordFiveTrans;
    [SerializeField] private Transform swordOneTransPos;
    [SerializeField] private Transform swordTwoTransPos;
    [SerializeField] private Transform swordThreeTransPos;
    [SerializeField] private Transform swordFourTransPos;
    [SerializeField] private Transform swordFiveTransPos;
    
    [SerializeField] private Transform shieldSlotTrans;
    [SerializeField] private Transform shieldOneTrans;
    [SerializeField] private Transform shieldTwoTrans;
    [SerializeField] private Transform shieldThreeTrans;
    [SerializeField] private Transform shieldFourTrans;
    [SerializeField] private Transform shieldFiveTrans;
    [SerializeField] private Transform shieldOneTransPos;
    [SerializeField] private Transform shieldTwoTransPos;
    [SerializeField] private Transform shieldThreeTransPos;
    [SerializeField] private Transform shieldFourTransPos;
    [SerializeField] private Transform shieldFiveTransPos;
    
    [SerializeField] private Transform legSlotTrans;
    [SerializeField] private Transform legOneTrans;
    [SerializeField] private Transform legTwoTrans;
    [SerializeField] private Transform legThreeTrans;
    [SerializeField] private Transform legFourTrans;
    [SerializeField] private Transform legFiveTrans;
    [SerializeField] private Transform legOneTransPos;
    [SerializeField] private Transform legTwoTransPos;
    [SerializeField] private Transform legThreeTransPos;
    [SerializeField] private Transform legFourTransPos;
    [SerializeField] private Transform legFiveTransPos;

    [SerializeField] private Transform artifactSlotTrans;
    [SerializeField] private Transform artifactOneTrans;
    [SerializeField] private Transform artifactTwoTrans;
    [SerializeField] private Transform artifactThreeTrans;
    [SerializeField] private Transform artifactFourTrans;
    [SerializeField] private Transform artifactFiveTrans;
    [SerializeField] private Transform artifactSixTrans;
    [SerializeField] private Transform artifactOneTransPos;
    [SerializeField] private Transform artifactTwoTransPos;
    [SerializeField] private Transform artifactThreeTransPos;
    [SerializeField] private Transform artifactFourTransPos;
    [SerializeField] private Transform artifactFiveTransPos;
    [SerializeField] private Transform artifactSixTransPos;
    [SerializeField] private MonsterBase _monsterBase;

    private PlayerController _playerController;
    //[SerializeField] private TMP_Text baseAtk; use for check atk base

    private void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        UpdateCoinText();
        SwordHave();
        ShieldHave();
        LegHave();
        ArtifactHave();
        SwordActive();
        ShieldActive();
        LegActive();
        UpdateAtkBootsText();
        UpdateFullPotionText();
        UpdateHpPotionText();
        UpdateMpPotionText();
    }

    public void UpdateHpPotion(int currentHpPotion)
    {
        hpPotion += currentHpPotion;
    }
    
    public void UpdateMpPotion(int currentMpPotion)
    {
        mpPotion += currentMpPotion;
    }
    
    public void UpdateFullPotion(int currentFullPotion)
    {
        fullPotion += currentFullPotion;
    }
    
    public void UpdateAtkBoots(int currentAtkBoots)
    {
        attackBoots += currentAtkBoots;
    }
    private void UpdateHpPotionText()
    {
        hpPotionText.text = "" + hpPotion;
        hpPotionText2.text = "" + hpPotion;
    }
    
    private void UpdateMpPotionText()
    {
        mpPotionText.text = "" + mpPotion;
        mpPotionText2.text = "" + mpPotion;
    }

    private void UpdateFullPotionText()
    {
        fullPotionText.text = "" + fullPotion;
        fullPotionText2.text = "" + mpPotion;
    }
    
    private void UpdateAtkBootsText()
    {
        atkBootsText.text = "" + attackBoots;
        atkBootsText2.text = "" + attackBoots;
    }

    private void SwordActive()
    {
        switch (swordOneActive)
        {
            case 2:
                atkText.text = "ATK +" + swordOneAtk;
                _monsterBase.Attack += swordOneAtk;
                swordOneActive = 0;
                break;
            case 1:
                
                _monsterBase.Attack -= swordOneAtk;
                swordOneActive = 0;
                break;
        }

        switch (swordTwoActive)
        {
            case 2:
                atkText.text = "ATK +" + swordTwoAtk;
                _monsterBase.Attack += swordTwoAtk;
                swordTwoActive = 0;
                break;
            case 1:
                
                _monsterBase.Attack -= swordTwoAtk;
                swordTwoActive = 0;
                break;
        }

        switch (swordThreeActive)
        {
            case 2:
                atkText.text = "ATK +" + swordThreeAtk;
                _monsterBase.Attack += swordThreeAtk;
                swordThreeActive = 0;
                break;
            case 1:
                
                _monsterBase.Attack -= swordThreeAtk;
                swordThreeActive = 0;
                break;
        }
        
        switch (swordFourActive)
        {
            case 2:
                atkText.text = "ATK +" + swordFourAtk;
                _monsterBase.Attack += swordFourAtk;
                swordFourActive = 0;
                break;
            case 1:
                
                _monsterBase.Attack -= swordFourAtk;
                swordFourActive = 0;
                break;
        }
        
        switch (swordFiveActive)
        {
            case 2:
                atkText.text = "ATK +" + swordFiveAtk;
                _monsterBase.Attack += swordFiveAtk;
                swordFiveActive = 0;
                break;
            case 1:
                
                _monsterBase.Attack -= swordFiveAtk;
                swordFiveActive = 0;
                break;
        }
    }
    
    private void ShieldActive()
    {
        switch (shieldOneActive)
        {
            case 2:
                defText.text = "DEF +" + shieldOneDef;
                _monsterBase.Defence += shieldOneDef;
                shieldOneActive = 0;
                break;
            case 1:
                
                _monsterBase.Defence -= shieldOneDef;
                shieldOneActive = 0;
                break;
        }

        switch (shieldTwoActive)
        {
            case 2:
                defText.text = "DEF +" + shieldTwoDef;
                _monsterBase.Defence += shieldTwoDef;
                shieldTwoActive = 0;
                break;
            case 1:
                
                _monsterBase.Defence -= shieldTwoDef;
                shieldTwoActive = 0;
                break;
        }

        switch (shieldThreeActive)
        {
            case 2:
                defText.text = "DEF +" + shieldThreeDef;
                _monsterBase.Defence += shieldThreeDef;
                shieldThreeActive = 0;
                break;
            case 1:
                
                _monsterBase.Defence -= shieldThreeDef;
                shieldThreeActive = 0;
                break;
        }
        
        switch (shieldFourActive)
        {
            case 2:
                defText.text = "DEF +" + shieldFourDef;
                _monsterBase.Defence += shieldFourDef;
                shieldFourActive = 0;
                break;
            case 1:
                
                _monsterBase.Defence -= shieldFourDef;
                shieldFourActive = 0;
                break;
        }
        
        switch (shieldFiveActive)
        {
            case 2:
                defText.text = "DEF +" + shieldFiveDef;
                _monsterBase.Defence += shieldFiveDef;
                shieldFiveActive = 0;
                break;
            case 1:
                
                _monsterBase.Defence -= shieldFiveDef;
                shieldFiveActive = 0;
                break;
        }
    }
    
    private void LegActive()
    {
        switch (legOneActive)
        {
            case 2:
                spdText.text = "SPD +" + legOneSpeed;
                _monsterBase.Speed += legOneSpeed;
                legOneActive = 0;
                _playerController.moveSpeed += 4f;
                break;
            case 1:
                
                _monsterBase.Speed -= legOneSpeed;
                legOneActive = 0;
                _playerController.moveSpeed -= 4f;
                break;
        }

        switch (legTwoActive)
        {
            case 2:
                spdText.text = "SPD +" + legTwoSpeed;
                _monsterBase.Speed += legTwoSpeed;
                legTwoActive = 0;
                _playerController.moveSpeed += 6f;
                break;
            case 1:
                
                _monsterBase.Speed -= legTwoSpeed;
                legTwoActive = 0;
                _playerController.moveSpeed -= 6f;
                break;
        }

        switch (legThreeActive)
        {
            case 2:
                spdText.text = "SPD +" + legThreeSpeed;
                _monsterBase.Speed += legThreeSpeed;
                legThreeActive = 0;
                _playerController.moveSpeed += 8f;
                break;
            case 1:
                
                _monsterBase.Speed -= legThreeSpeed;
                legThreeActive = 0;
                _playerController.moveSpeed -= 8f;
                break;
        }
        
        switch (legFourActive)
        {
            case 2:
                spdText.text = "SPD +" + legFourSpeed;
                _monsterBase.Speed += legFourSpeed;
                legFourActive = 0;
                _playerController.moveSpeed += 10f;
                break;
            case 1:
                
                _monsterBase.Speed -= legFourSpeed;
                legFourActive = 0;
                _playerController.moveSpeed -= 10f;
                break;
        }
        
        switch (legFiveActive)
        {
            case 2:
                spdText.text = "SPD +" + legFiveSpeed;
                _monsterBase.Speed += legFiveSpeed;
                legFiveActive = 0;
                _playerController.moveSpeed += 12f;
                break;
            case 1:
                
                _monsterBase.Speed -= legFiveSpeed;
                legFiveActive = 0;
                _playerController.moveSpeed -= 12f;
                break;
        }
    }
    private void SwordHave()
    {
        if (swordOne == true)
        {
            swordOneTrans.position = swordOneTransPos.position;
        }
        
        if (swordTwo == true)
        {
            swordTwoTrans.position = swordTwoTransPos.position;
        }
        
        if (swordThree == true)
        {
            swordThreeTrans.position = swordThreeTransPos.position;
        }
        
        if (swordFour == true)
        {
            swordFourTrans.position = swordFourTransPos.position;
        }
        
        if (swordFive == true)
        {
            swordFiveTrans.position = swordFiveTransPos.position;
        }
    }
    
    private void ShieldHave()
    {
        if (shieldOne == true)
        {
            shieldOneTrans.position = shieldOneTransPos.position;
        }
        
        if (shieldTwo == true)
        {
            shieldTwoTrans.position = shieldTwoTransPos.position;
        }
        
        if (shieldThree == true)
        {
            shieldThreeTrans.position = shieldThreeTransPos.position;
        }
        
        if (shieldFour == true)
        {
            shieldFourTrans.position = shieldFourTransPos.position;
        }
        
        if (shieldFive == true)
        {
            shieldFiveTrans.position = shieldFiveTransPos.position;
        }
    }
    
    private void LegHave()
    {
        if (legOne == true)
        {
            legOneTrans.position = legOneTransPos.position;
        }
        
        if (legTwo == true)
        {
            legTwoTrans.position = legTwoTransPos.position;
        }
        
        if (legThree == true)
        {
            legThreeTrans.position = legThreeTransPos.position;
        }
        
        if (legFour == true)
        {
            legFourTrans.position = legFourTransPos.position;
        }
        
        if (legFive == true)
        {
            legFiveTrans.position = legFiveTransPos.position;
        }
    }

    private void ArtifactHave()
    {
        if (artifactOne == true)
        {
            artifactOneTrans.position = artifactOneTransPos.position;
        }
        
        if (artifactTwo == true)
        {
            artifactTwoTrans.position = artifactTwoTransPos.position;
        }
        
        if (artifactThree == true)
        {
            artifactThreeTrans.position = artifactThreeTransPos.position;
        }
        
        if (artifactFour == true)
        {
            artifactFourTrans.position = artifactFourTransPos.position;
        }
        
        if (artifactFive == true)
        {
            artifactFiveTrans.position = artifactFiveTransPos.position;
        }
        
        if (artifactSix == true)
        {
            artifactSixTrans.position = artifactSixTransPos.position;
        }
        
    }

    public void SelectSwordOne()
    {
        if (swordOne)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (weaponName)
            {
                case "SwordTwo":
                    swordTwoTrans.position = swordTwoTransPos.position;
                    swordOneTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordOne";
                    swordOneActive = 2;
                    swordTwoActive = 1;
                    swordTwo = true;
                    swordOne = false;
                    break;
                case "SwordThree":
                    swordThreeTrans.position = swordThreeTransPos.position;
                    swordOneTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordOne";
                    swordOneActive = 2;
                    swordThreeActive = 1;
                    swordThree = true;
                    swordOne = false;
                    break;
                case "SwordFour":
                    swordFourTrans.position = swordFourTransPos.position;
                    swordOneTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordOne";
                    swordOneActive = 2;
                    swordFourActive = 1;
                    swordFour = true;
                    swordOne = false;
                    break;
                case "SwordFive":
                    swordFiveTrans.position = swordFiveTransPos.position;
                    swordOneTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordOne";
                    swordOneActive = 2;
                    swordFiveActive = 1;
                    swordFive = true;
                    swordOne = false;
                    break;
                default:
                    swordOneTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordOne";
                    swordOne = false;
                    swordOneActive = 2;
                    Debug.Log("No sword");
                    break;
            }
        }
    }
    
    public void SelectSwordTwo()
    {
        if (swordTwo)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (weaponName)
            {
                case "SwordOne":
                    swordOneTrans.position = swordOneTransPos.position;
                    swordTwoTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordTwo";
                    swordTwoActive = 2;
                    swordOneActive = 1;
                    swordOne = true;
                    swordTwo = false;
                    break;
                case "SwordThree":
                    swordThreeTrans.position = swordThreeTransPos.position;
                    swordTwoTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordTwo";
                    swordTwoActive = 2;
                    swordThreeActive = 1;
                    swordThree = true;
                    swordTwo = false;
                    break;
                case "SwordFour":
                    swordFourTrans.position = swordFourTransPos.position;
                    swordTwoTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordTwo";
                    swordTwoActive = 2;
                    swordFourActive = 1;
                    swordFour = true;
                    swordTwo = false;
                    break;
                case "SwordFive":
                    swordFiveTrans.position = swordFiveTransPos.position;
                    swordTwoTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordTwo";
                    swordTwoActive = 2;
                    swordFiveActive = 1;
                    swordFive = true;
                    swordTwo = false;
                    break;
                default:
                    swordTwoTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordTwo";
                    swordTwoActive = 2;
                    swordTwo = false;
                    Debug.Log("No sword");
                    break;
            }
        }
    }
    
    public void SelectSwordThree()
    {
        if (swordThree)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (weaponName)
            {
                case "SwordOne":
                    swordOneTrans.position = swordOneTransPos.position;
                    swordThreeTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordThree";
                    swordThreeActive = 2;
                    swordOneActive = 1;
                    swordOne = true;
                    swordThree = false;
                    break;
                case "SwordTwo":
                    swordTwoTrans.position = swordTwoTransPos.position;
                    swordThreeTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordThree";
                    swordThreeActive = 2;
                    swordTwoActive = 1;
                    swordTwo = true;
                    swordThree = false;
                    break;
                case "SwordFour":
                    swordFourTrans.position = swordFourTransPos.position;
                    swordThreeTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordThree";
                    swordThreeActive = 2;
                    swordFourActive = 1;
                    swordFour = true;
                    swordThree = false;
                    break;
                case "SwordFive":
                    swordFiveTrans.position = swordFiveTransPos.position;
                    swordThreeTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordThree";
                    swordThreeActive = 2;
                    swordFiveActive = 1;
                    swordFive = true;
                    swordThree = false;
                    break;
                default:
                    swordThreeTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordThree";
                    swordThreeActive = 2;
                    swordThree = false;
                    Debug.Log("No sword");
                    break;
            }
        }
    }
    
    public void SelectSwordFour()
    {
        if (swordFour)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (weaponName)
            {
                case "SwordOne":
                    swordOneTrans.position = swordOneTransPos.position;
                    swordFourTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordFour";
                    swordFourActive = 2;
                    swordOneActive = 1;
                    swordOne = true;
                    swordFour = false;
                    break;
                case "SwordTwo":
                    swordTwoTrans.position = swordTwoTransPos.position;
                    swordFourTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordFour";
                    swordFourActive = 2;
                    swordTwoActive = 1;
                    swordTwo = true;
                    swordFour = false;
                    break;
                case "SwordThree":
                    swordThreeTrans.position = swordThreeTransPos.position;
                    swordFourTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordFour";
                    swordFourActive = 2;
                    swordThreeActive = 1;
                    swordThree = true;
                    swordFour = false;
                    break;
                case "SwordFive":
                    swordFiveTrans.position = swordFiveTransPos.position;
                    swordFourTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordFour";
                    swordFourActive = 2;
                    swordFiveActive = 1;
                    swordFive = true;
                    swordFour = false;
                    break;
                default:
                    swordFourTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordFour";
                    swordFourActive = 2;
                    swordFour = false;
                    Debug.Log("No sword");
                    break;
            }
        }
    }
    
    public void SelectSwordFive()
    {
        if (swordFive)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (weaponName)
            {
                case "SwordOne":
                    swordOneTrans.position = swordOneTransPos.position;
                    swordFiveTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordFive";
                    swordFiveActive = 2;
                    swordOneActive = 1;
                    swordOne = true;
                    swordFive = false;
                    break;
                case "SwordTwo":
                    swordTwoTrans.position = swordTwoTransPos.position;
                    swordFiveTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordFive";
                    swordFiveActive = 2;
                    swordTwoActive = 1;
                    swordTwo = true;
                    swordFive = false;
                    break;
                case "SwordThree":
                    swordThreeTrans.position = swordThreeTransPos.position;
                    swordFiveTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordFive";
                    swordFiveActive = 2;
                    swordThreeActive = 1;
                    swordThree = true;
                    swordFive = false;
                    break;
                case "SwordFour":
                    swordFourTrans.position = swordFourTransPos.position;
                    swordFiveTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordFive";
                    swordFiveActive = 2;
                    swordFourActive = 1;
                    swordFour = true;
                    swordFive = false;
                    break;
                default:
                    swordFiveTrans.position = weaponSlotTrans.position;
                    weaponName = "SwordFive";
                    swordFiveActive = 2;
                    swordFive = false;
                    Debug.Log("No sword");
                    break;
            }
        }
    }
    
    public void SelectShieldOne()
    {
        if (shieldOne)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (shieldName)
            {
                case "ShieldTwo":
                    shieldTwoTrans.position = shieldTwoTransPos.position;
                    shieldOneTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldOne";
                    shieldOneActive = 2;
                    shieldTwoActive = 1;
                    shieldTwo = true;
                    shieldOne = false;
                    break;
                case "ShieldThree":
                    shieldThreeTrans.position = shieldThreeTransPos.position;
                    shieldOneTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldOne";
                    shieldOneActive = 2;
                    shieldThreeActive = 1;
                    shieldThree = true;
                    shieldOne = false;
                    break;
                case "ShieldFour":
                    shieldFourTrans.position = shieldFourTransPos.position;
                    shieldOneTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldOne";
                    shieldOneActive = 2;
                    shieldFourActive = 1;
                    shieldFour = true;
                    shieldOne = false;
                    break;
                case "ShieldFive":
                    shieldFiveTrans.position = shieldFiveTransPos.position;
                    shieldOneTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldOne";
                    shieldOneActive = 2;
                    shieldFiveActive = 1;
                    shieldFive = true;
                    shieldOne = false;
                    break;
                default:
                    shieldOneTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldOne";
                    shieldOneActive = 2;
                    shieldOne = false;
                    Debug.Log("No shield");
                    break;
            }
        }
    }
    
    public void SelectShieldTwo()
    {
        if (shieldTwo)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (shieldName)
            {
                case "ShieldOne":
                    shieldOneTrans.position = shieldOneTransPos.position;
                    shieldTwoTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldTwo";
                    shieldTwoActive = 2;
                    shieldOneActive = 1;
                    shieldOne = true;
                    shieldTwo = false;
                    break;
                case "ShieldThree":
                    shieldThreeTrans.position = shieldThreeTransPos.position;
                    shieldTwoTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldTwo";
                    shieldTwoActive = 2;
                    shieldThreeActive = 1;
                    shieldThree = true;
                    shieldTwo = false;
                    break;
                case "ShieldFour":
                    shieldFourTrans.position = shieldFourTransPos.position;
                    shieldTwoTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldTwo";
                    shieldTwoActive = 2;
                    shieldFourActive = 1;
                    shieldFour = true;
                    shieldTwo = false;
                    break;
                case "ShieldFive":
                    shieldFiveTrans.position = shieldFiveTransPos.position;
                    shieldTwoTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldTwo";
                    shieldTwoActive = 2;
                    shieldFiveActive = 1;
                    shieldFive = true;
                    shieldTwo = false;
                    break;
                default:
                    shieldTwoTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldTwo";
                    shieldTwoActive = 2;
                    shieldTwo = false;
                    Debug.Log("No shield");
                    break;
            }
        }
    }
    
    public void SelectShieldThree()
    {
        if (shieldThree)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (shieldName)
            {
                case "ShieldTwo":
                    shieldTwoTrans.position = shieldTwoTransPos.position;
                    shieldThreeTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldThree";
                    shieldThreeActive = 2;
                    shieldTwoActive = 1;
                    shieldTwo = true;
                    shieldThree = false;
                    break;
                case "ShieldOne":
                    shieldOneTrans.position = shieldOneTransPos.position;
                    shieldThreeTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldThree";
                    shieldThreeActive = 2;
                    shieldOneActive = 1;
                    shieldOne = true;
                    shieldThree = false;
                    break;
                case "ShieldFour":
                    shieldFourTrans.position = shieldFourTransPos.position;
                    shieldThreeTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldThree";
                    shieldThreeActive = 2;
                    shieldFourActive = 1;
                    shieldFour = true;
                    shieldThree = false;
                    break;
                case "ShieldFive":
                    shieldFiveTrans.position = shieldFiveTransPos.position;
                    shieldThreeTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldThree";
                    shieldThreeActive = 2;
                    shieldFiveActive = 1;
                    shieldFive = true;
                    shieldThree = false;
                    break;
                default:
                    shieldThreeTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldThree";
                    shieldThreeActive = 2;
                    shieldThree = false;
                    Debug.Log("No shield");
                    break;
            }
        }
    }
    
    public void SelectShieldFour()
    {
        if (shieldFour)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (shieldName)
            {
                case "ShieldTwo":
                    shieldTwoTrans.position = shieldTwoTransPos.position;
                    shieldFourTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldFour";
                    shieldFourActive = 2;
                    shieldTwoActive = 1;
                    shieldTwo = true;
                    shieldFour = false;
                    break;
                case "ShieldThree":
                    shieldThreeTrans.position = shieldThreeTransPos.position;
                    shieldFourTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldFour";
                    shieldFourActive = 2;
                    shieldThreeActive = 1;
                    shieldThree = true;
                    shieldFour = false;
                    break;
                case "ShieldOne":
                    shieldOneTrans.position = shieldOneTransPos.position;
                    shieldFourTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldFour";
                    shieldFourActive = 2;
                    shieldOneActive = 1;
                    shieldOne = true;
                    shieldFour = false;
                    break;
                case "ShieldFive":
                    shieldFiveTrans.position = shieldFiveTransPos.position;
                    shieldFourTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldFour";
                    shieldFourActive = 2;
                    shieldFiveActive = 1;
                    shieldFive = true;
                    shieldFour = false;
                    break;
                default:
                    shieldFourTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldFour";
                    shieldFourActive = 2;
                    shieldFour = false;
                    Debug.Log("No shield");
                    break;
            }
        }
    }
    
    public void SelectShieldFive()
    {
        if (shieldFive)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (shieldName)
            {
                case "ShieldTwo":
                    shieldTwoTrans.position = shieldTwoTransPos.position;
                    shieldFiveTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldFive";
                    shieldFiveActive = 2;
                    shieldTwoActive = 1;
                    shieldTwo = true;
                    shieldFive = false;
                    break;
                case "ShieldThree":
                    shieldThreeTrans.position = shieldThreeTransPos.position;
                    shieldFiveTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldFive";
                    shieldFiveActive = 2;
                    shieldThreeActive = 1;
                    shieldThree = true;
                    shieldFive = false;
                    break;
                case "ShieldFour":
                    shieldFourTrans.position = shieldFourTransPos.position;
                    shieldFiveTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldFive";
                    shieldFiveActive = 2;
                    shieldFourActive = 1;
                    shieldFour = true;
                    shieldFive = false;
                    break;
                case "ShieldOne":
                    shieldOneTrans.position = shieldOneTransPos.position;
                    shieldFiveTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldFive";
                    shieldFiveActive = 2;
                    shieldOneActive = 1;
                    shieldOne = true;
                    shieldFive = false;
                    break;
                default:
                    shieldFiveTrans.position = shieldSlotTrans.position;
                    shieldName = "ShieldFive";
                    shieldFiveActive = 2;
                    shieldFive = false;
                    Debug.Log("No shield");
                    break;
            }
        }
    }
    
    public void SelectLegOne()
    {
        if (legOne)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (legName)
            {
                case "LegTwo":
                    legTwoTrans.position = legTwoTransPos.position;
                    legOneTrans.position = legSlotTrans.position;
                    legName = "LegOne";
                    legOneActive = 2;
                    legTwoActive = 1;
                    legTwo = true;
                    legOne = false;
                    break;
                case "LegThree":
                    legThreeTrans.position = legThreeTransPos.position;
                    legOneTrans.position = legSlotTrans.position;
                    legName = "LegOne";
                    legOneActive = 2;
                    legThreeActive = 1;
                    legThree = true;
                    legOne = false;
                    break;
                case "LegFour":
                    legFourTrans.position = legFourTransPos.position;
                    legOneTrans.position = legSlotTrans.position;
                    legName = "LegOne";
                    legOneActive = 2;
                    legFourActive = 1;
                    legFour = true;
                    legOne = false;
                    break;
                case "LegFive":
                    legFiveTrans.position = legFiveTransPos.position;
                    legOneTrans.position = legSlotTrans.position;
                    legName = "LegOne";
                    legOneActive = 2;
                    legFiveActive = 1;
                    legFive = true;
                    legOne = false;
                    break;
                default:
                    legOneTrans.position = legSlotTrans.position;
                    legName = "LegOne";
                    legOneActive = 2;
                    legOne = false;
                    Debug.Log("No Leg");
                    break;
            }
        }
    }
    
    public void SelectLegTwo()
    {
        if (legTwo)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (legName)
            {
                case "LegOne":
                    legOneTrans.position = legOneTransPos.position;
                    legTwoTrans.position = legSlotTrans.position;
                    legName = "LegTwo";
                    legTwoActive = 2;
                    legOneActive = 1;
                    legOne = true;
                    legTwo = false;
                    break;
                case "LegThree":
                    legThreeTrans.position = legThreeTransPos.position;
                    legTwoTrans.position = legSlotTrans.position;
                    legName = "LegTwo";
                    legTwoActive = 2;
                    legThreeActive = 1;
                    legThree = true;
                    legTwo = false;
                    break;
                case "LegFour":
                    legFourTrans.position = legFourTransPos.position;
                    legTwoTrans.position = legSlotTrans.position;
                    legName = "LegTwo";
                    legTwoActive = 2;
                    legFourActive = 1;
                    legFour = true;
                    legTwo = false;
                    break;
                case "LegFive":
                    legFiveTrans.position = legFiveTransPos.position;
                    legTwoTrans.position = legSlotTrans.position;
                    legName = "LegTwo";
                    legTwoActive = 2;
                    legFiveActive = 1;
                    legFive = true;
                    legTwo = false;
                    break;
                default:
                    legTwoTrans.position = legSlotTrans.position;
                    legName = "LegTwo";
                    legTwoActive = 2;
                    legTwo = false;
                    Debug.Log("No Leg");
                    break;
            }
        }
    }
    
    public void SelectLegThree()
    {
        if (legThree)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (legName)
            {
                case "LegOne":
                    legOneTrans.position = legOneTransPos.position;
                    legThreeTrans.position = legSlotTrans.position;
                    legName = "LegThree";
                    legThreeActive = 2;
                    legOneActive = 1;
                    legOne = true;
                    legThree = false;
                    break;
                case "LegTwo":
                    legTwoTrans.position = legTwoTransPos.position;
                    legThreeTrans.position = legSlotTrans.position;
                    legName = "LegThree";
                    legThreeActive = 2;
                    legTwoActive = 1;
                    legTwo = true;
                    legThree = false;
                    break;
                case "LegFour":
                    legFourTrans.position = legFourTransPos.position;
                    legThreeTrans.position = legSlotTrans.position;
                    legName = "LegThree";
                    legThreeActive = 2;
                    legFourActive = 1;
                    legFour = true;
                    legThree = false;
                    break;
                case "LegFive":
                    legFiveTrans.position = legFiveTransPos.position;
                    legThreeTrans.position = legSlotTrans.position;
                    legName = "LegThree";
                    legThreeActive = 2;
                    legFiveActive = 1;
                    legFive = true;
                    legThree = false;
                    break;
                default:
                    legThreeTrans.position = legSlotTrans.position;
                    legName = "LegThree";
                    legThreeActive = 2;
                    legThree = false;
                    Debug.Log("No Leg");
                    break;
            }
        }
    }
    
    public void SelectLegFour()
    {
        if (legFour)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (legName)
            {
                case "LegOne":
                    legOneTrans.position = legOneTransPos.position;
                    legFourTrans.position = legSlotTrans.position;
                    legName = "LegFour";
                    legFourActive = 2;
                    legOneActive = 1;
                    legOne = true;
                    legFour = false;
                    break;
                case "LegTwo":
                    legTwoTrans.position = legTwoTransPos.position;
                    legFourTrans.position = legSlotTrans.position;
                    legName = "LegFour";
                    legFourActive = 2;
                    legTwoActive = 1;
                    legTwo = true;
                    legFour = false;
                    break;
                case "LegThree":
                    legThreeTrans.position = legThreeTransPos.position;
                    legFourTrans.position = legSlotTrans.position;
                    legName = "LegFour";
                    legFourActive = 2;
                    legThreeActive = 1;
                    legThree = true;
                    legFour = false;
                    break;
                case "LegFive":
                    legFiveTrans.position = legFiveTransPos.position;
                    legFourTrans.position = legSlotTrans.position;
                    legName = "LegFour";
                    legFourActive = 2;
                    legFiveActive = 1;
                    legFive = true;
                    legFour = false;
                    break;
                default:
                    legFourTrans.position = legSlotTrans.position;
                    legName = "LegFour";
                    legFourActive = 2;
                    legFour = false;
                    Debug.Log("No Leg");
                    break;
            }
        }
    }
    
    public void SelectLegFive()
    {
        if (legFive)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (legName)
            {
                case "LegOne":
                    legOneTrans.position = legOneTransPos.position;
                    legFiveTrans.position = legSlotTrans.position;
                    legName = "LegFive";
                    legFiveActive = 2;
                    legOneActive = 1;
                    legOne = true;
                    legFive = false;
                    break;
                case "LegTwo":
                    legTwoTrans.position = legTwoTransPos.position;
                    legFiveTrans.position = legSlotTrans.position;
                    legName = "LegFive";
                    legFiveActive = 2;
                    legTwoActive = 1;
                    legTwo = true;
                    legFive = false;
                    break;
                case "LegThree":
                    legThreeTrans.position = legThreeTransPos.position;
                    legFiveTrans.position = legSlotTrans.position;
                    legName = "LegFive";
                    legFiveActive = 2;
                    legThreeActive = 1;
                    legThree = true;
                    legFive = false;
                    break;
                case "LegFour":
                    legFourTrans.position = legFourTransPos.position;
                    legFiveTrans.position = legSlotTrans.position;
                    legName = "LegFive";
                    legFiveActive = 2;
                    legFourActive = 1;
                    legFour = true;
                    legFive = false;
                    break;
                default:
                    legFiveTrans.position = legSlotTrans.position;
                    legName = "LegFive";
                    legFiveActive = 2;
                    legFive = false;
                    Debug.Log("No Leg");
                    break;
            }
        }
    }

    
    
    public void SelectArtifactOne()
    {
        if (artifactOne)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (artifactName)
            {
                case  "ArtifactTwo":
                    artifactTwoTrans.position = artifactTwoTransPos.position;
                    artifactOneTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactOne";
                    artifactTwo = true;
                    artifactOne = false;
                    typeText.text = "FIRE";
                    _monsterBase.Type = MonsterBase.MonsterType.Fire;
                    break;
                case  "ArtifactThree":
                    artifactThreeTrans.position = artifactThreeTransPos.position;
                    artifactOneTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactOne";
                    artifactThree = true;
                    artifactOne = false;
                    typeText.text = "FIRE";
                    _monsterBase.Type = MonsterBase.MonsterType.Fire;
                    break;
                case  "ArtifactFour":
                    artifactFourTrans.position = artifactFourTransPos.position;
                    artifactOneTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactOne";
                    artifactFour = true;
                    artifactOne = false;
                    typeText.text = "FIRE";
                    _monsterBase.Type = MonsterBase.MonsterType.Fire;
                    break;
                case  "ArtifactFive":
                    artifactFiveTrans.position = artifactFiveTransPos.position;
                    artifactOneTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactOne";
                    artifactFive = true;
                    artifactOne = false;
                    typeText.text = "FIRE";
                    _monsterBase.Type = MonsterBase.MonsterType.Fire;
                    break;
                case  "ArtifactSix":
                    artifactSixTrans.position = artifactSixTransPos.position;
                    artifactOneTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactOne";
                    artifactSix = true;
                    artifactOne = false;
                    typeText.text = "FIRE";
                    _monsterBase.Type = MonsterBase.MonsterType.Fire;
                    break;
                default:
                    artifactOneTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactOne";
                    artifactOne = false;
                    typeText.text = "FIRE";
                    _monsterBase.Type = MonsterBase.MonsterType.Fire;
                    break;
                    
            }
        }
    }
    
    public void SelectArtifactTwo()
    {
        if (artifactTwo)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (artifactName)
            {
                case  "ArtifactOne":
                    artifactOneTrans.position = artifactOneTransPos.position;
                    artifactTwoTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactTwo";
                    artifactOne = true;
                    artifactTwo = false;
                    typeText.text = "WATER";
                    _monsterBase.Type = MonsterBase.MonsterType.Water;
                    break;
                case  "ArtifactThree":
                    artifactThreeTrans.position = artifactThreeTransPos.position;
                    artifactTwoTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactTwo";
                    artifactThree = true;
                    artifactTwo = false;
                    typeText.text = "WATER";
                    _monsterBase.Type = MonsterBase.MonsterType.Water;
                    break;
                case  "ArtifactFour":
                    artifactFourTrans.position = artifactFourTransPos.position;
                    artifactTwoTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactTwo";
                    artifactFour = true;
                    artifactTwo = false;
                    typeText.text = "WATER";
                    _monsterBase.Type = MonsterBase.MonsterType.Water;
                    break;
                case  "ArtifactFive":
                    artifactFiveTrans.position = artifactFiveTransPos.position;
                    artifactTwoTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactTwo";
                    artifactFive = true;
                    artifactTwo = false;
                    typeText.text = "WATER";
                    _monsterBase.Type = MonsterBase.MonsterType.Water;
                    break;
                case  "ArtifactSix":
                    artifactSixTrans.position = artifactSixTransPos.position;
                    artifactTwoTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactTwo";
                    artifactSix = true;
                    artifactTwo = false;
                    typeText.text = "WATER";
                    _monsterBase.Type = MonsterBase.MonsterType.Water;
                    break;
                default:
                    artifactTwoTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactTwo";
                    artifactTwo = false;
                    typeText.text = "WATER";
                    _monsterBase.Type = MonsterBase.MonsterType.Water;
                    break;
                    
            }
        }
    }
    
    public void SelectArtifactThree()
    {
        if (artifactThree)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (artifactName)
            {
                case  "ArtifactOne":
                    artifactOneTrans.position = artifactOneTransPos.position;
                    artifactThreeTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactThree";
                    artifactOne = true;
                    artifactThree = false;
                    typeText.text = "EARTH";
                    _monsterBase.Type = MonsterBase.MonsterType.Earth;
                    break;
                case  "ArtifactTwo":
                    artifactTwoTrans.position = artifactTwoTransPos.position;
                    artifactThreeTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactThree";
                    artifactTwo = true;
                    artifactThree = false;
                    typeText.text = "EARTH";
                    _monsterBase.Type = MonsterBase.MonsterType.Earth;
                    break;
                case  "ArtifactFour":
                    artifactFourTrans.position = artifactFourTransPos.position;
                    artifactThreeTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactThree";
                    artifactFour = true;
                    artifactThree = false;
                    typeText.text = "EARTH";
                    _monsterBase.Type = MonsterBase.MonsterType.Earth;
                    break;
                case  "ArtifactFive":
                    artifactFiveTrans.position = artifactFiveTransPos.position;
                    artifactThreeTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactThree";
                    artifactFive = true;
                    artifactThree = false;
                    typeText.text = "EARTH";
                    _monsterBase.Type = MonsterBase.MonsterType.Earth;
                    break;
                case  "ArtifactSix":
                    artifactSixTrans.position = artifactSixTransPos.position;
                    artifactThreeTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactThree";
                    artifactSix = true;
                    artifactThree = false;
                    typeText.text = "EARTH";
                    _monsterBase.Type = MonsterBase.MonsterType.Earth;
                    break;
                default:
                    artifactThreeTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactThree";
                    artifactThree = false;
                    typeText.text = "EARTH";
                    _monsterBase.Type = MonsterBase.MonsterType.Earth;
                    break;
                    
            }
        }
    }
    
    public void SelectArtifactFour()
    {
        if (artifactFour)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (artifactName)
            {
                case  "ArtifactOne":
                    artifactOneTrans.position = artifactOneTransPos.position;
                    artifactFourTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactFour";
                    artifactOne = true;
                    artifactFour = false;
                    typeText.text = "ELECTRIC";
                    _monsterBase.Type = MonsterBase.MonsterType.Electric;
                    break;
                case  "ArtifactTwo":
                    artifactTwoTrans.position = artifactTwoTransPos.position;
                    artifactFourTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactFour";
                    artifactTwo = true;
                    artifactFour = false;
                    typeText.text = "ELECTRIC";
                    _monsterBase.Type = MonsterBase.MonsterType.Electric;
                    break;
                case  "ArtifactThree":
                    artifactThreeTrans.position = artifactThreeTransPos.position;
                    artifactFourTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactFour";
                    artifactThree = true;
                    artifactFour = false;
                    typeText.text = "ELECTRIC";
                    _monsterBase.Type = MonsterBase.MonsterType.Electric;
                    break;
                case  "ArtifactFive":
                    artifactFiveTrans.position = artifactFiveTransPos.position;
                    artifactFourTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactFour";
                    artifactFive = true;
                    artifactFour = false;
                    typeText.text = "ELECTRIC";
                    _monsterBase.Type = MonsterBase.MonsterType.Electric;
                    break;
                case  "ArtifactSix":
                    artifactSixTrans.position = artifactSixTransPos.position;
                    artifactFourTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactFour";
                    artifactSix = true;
                    artifactFour = false;
                    typeText.text = "ELECTRIC";
                    _monsterBase.Type = MonsterBase.MonsterType.Electric;
                    break;
                default:
                    artifactFourTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactFour";
                    artifactFour = false;
                    typeText.text = "ELECTRIC";
                    _monsterBase.Type = MonsterBase.MonsterType.Electric;
                    break;
                    
            }
        }
    }
    
    public void SelectArtifactFive()
    {
        if (artifactFive)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (artifactName)
            {
                case  "ArtifactOne":
                    artifactOneTrans.position = artifactOneTransPos.position;
                    artifactFiveTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactFive";
                    artifactOne = true;
                    artifactFive = false;
                    typeText.text = "DARK";
                    _monsterBase.Type = MonsterBase.MonsterType.Dark;
                    break;
                case  "ArtifactTwo":
                    artifactTwoTrans.position = artifactTwoTransPos.position;
                    artifactFiveTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactFive";
                    artifactTwo = true;
                    artifactFive = false;
                    typeText.text = "DARK";
                    _monsterBase.Type = MonsterBase.MonsterType.Dark;
                    break;
                case  "ArtifactThree":
                    artifactThreeTrans.position = artifactThreeTransPos.position;
                    artifactFiveTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactFive";
                    artifactThree = true;
                    artifactFive = false;
                    typeText.text = "DARK";
                    _monsterBase.Type = MonsterBase.MonsterType.Dark;
                    break;
                case  "ArtifactFour":
                    artifactFourTrans.position = artifactFourTransPos.position;
                    artifactFiveTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactFive";
                    artifactFour = true;
                    artifactFive = false;
                    typeText.text = "DARK";
                    _monsterBase.Type = MonsterBase.MonsterType.Dark;
                    break;
                case  "ArtifactSix":
                    artifactSixTrans.position = artifactSixTransPos.position;
                    artifactFiveTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactFive";
                    artifactSix = true;
                    artifactFive = false;
                    typeText.text = "DARK";
                    _monsterBase.Type = MonsterBase.MonsterType.Dark;
                    break;
                default:
                    artifactFiveTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactFive";
                    artifactFive = false;
                    typeText.text = "DARK";
                    _monsterBase.Type = MonsterBase.MonsterType.Dark;
                    break;
                    
            }
        }
    }
    
    public void SelectArtifactSix()
    {
        if (artifactSix)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (artifactName)
            {
                case  "ArtifactOne":
                    artifactOneTrans.position = artifactOneTransPos.position;
                    artifactSixTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactSix";
                    artifactOne = true;
                    artifactSix = false;
                    typeText.text = "LIGHT";
                    _monsterBase.Type = MonsterBase.MonsterType.Light;
                    break;
                case  "ArtifactTwo":
                    artifactTwoTrans.position = artifactTwoTransPos.position;
                    artifactSixTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactSix";
                    artifactTwo = true;
                    artifactSix = false;
                    typeText.text = "LIGHT";
                    _monsterBase.Type = MonsterBase.MonsterType.Light;
                    break;
                case  "ArtifactThree":
                    artifactThreeTrans.position = artifactThreeTransPos.position;
                    artifactSixTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactSix";
                    artifactThree = true;
                    artifactSix = false;
                    typeText.text = "LIGHT";
                    _monsterBase.Type = MonsterBase.MonsterType.Light;
                    break;
                case  "ArtifactFour":
                    artifactFourTrans.position = artifactFourTransPos.position;
                    artifactSixTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactSix";
                    artifactFour = true;
                    artifactSix = false;
                    typeText.text = "LIGHT";
                    _monsterBase.Type = MonsterBase.MonsterType.Light;
                    break;
                case  "ArtifactFive":
                    artifactFiveTrans.position = artifactFiveTransPos.position;
                    artifactSixTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactSix";
                    artifactFive = true;
                    artifactSix = false;
                    typeText.text = "LIGHT";
                    _monsterBase.Type = MonsterBase.MonsterType.Light;
                    break;
                default:
                    artifactSixTrans.position = artifactSlotTrans.position;
                    artifactName = "ArtifactSix";
                    artifactSix = false;
                    typeText.text = "LIGHT";
                    _monsterBase.Type = MonsterBase.MonsterType.Light;
                    break;
                    
            }
        }
    }
    public void UnEquipArtifact()
        {
            if (artifactName != "")
            {
                SoundManager.instace.Play(SoundManager.SoundName.Equip);
                switch (artifactName)
                {
                    case "ArtifactOne":
                        artifactOneTrans.position = artifactOneTransPos.position;
                        artifactName = "";
                        artifactOne = true;
                        typeText.text = "NORMAL";
                        _monsterBase.Type = MonsterBase.MonsterType.Normal;
                        break;
                    case "ArtifactTwo":
                        artifactTwoTrans.position = artifactTwoTransPos.position;
                        artifactName = "";
                        artifactTwo = true;
                        typeText.text = "NORMAL";
                        _monsterBase.Type = MonsterBase.MonsterType.Normal;
                        break;
                    case "ArtifactThree":
                        artifactThreeTrans.position = artifactThreeTransPos.position;
                        artifactName = "";
                        artifactThree = true;
                        typeText.text = "NORMAL";
                        _monsterBase.Type = MonsterBase.MonsterType.Normal;
                        break;
                    case "ArtifactFour":
                        artifactFourTrans.position = artifactFourTransPos.position;
                        artifactName = "";
                        artifactFour = true;
                        typeText.text = "NORMAL";
                        _monsterBase.Type = MonsterBase.MonsterType.Normal;
                        break;
                    case "ArtifactFive":
                        artifactFiveTrans.position = artifactFiveTransPos.position;
                        artifactName = "";
                        artifactFive = true;
                        typeText.text = "NORMAL";
                        _monsterBase.Type = MonsterBase.MonsterType.Normal;
                        break;
                    case "ArtifactSix":
                        artifactSixTrans.position = artifactSixTransPos.position;
                        artifactName = "";
                        artifactSix = true;
                        typeText.text = "NORMAL";
                        _monsterBase.Type = MonsterBase.MonsterType.Normal;
                        break;
                }
            }
        }

    public void UnEquipSword()
    {
        if (weaponName != "")
        {
            atkText.text = "";
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (weaponName)
            {
                case "SwordOne":
                    swordOneTrans.position = swordOneTransPos.position;
                    weaponName = "";
                    swordOneActive = 1;
                    swordOne = true;
                    break;
                case "SwordTwo":
                    swordTwoTrans.position = swordTwoTransPos.position;
                    weaponName = "";
                    swordTwoActive = 1;
                    swordTwo = true;
                    break;
                case "SwordThree":
                    swordThreeTrans.position = swordThreeTransPos.position;
                    weaponName = "";
                    swordThreeActive = 1;
                    swordThree = true;
                    break;
                case "SwordFour":
                    swordFourTrans.position = swordFourTransPos.position;
                    weaponName = "";
                    swordFourActive = 1;
                    swordFour = true;
                    break;
                case "SwordFive":
                    swordFiveTrans.position = swordFiveTransPos.position;
                    weaponName = "";
                    swordFiveActive = 1;
                    swordFive = true;
                    break;
                
            }
        }
    }
    
    public void UnEquipShield()
    {
        if (shieldName != "")
        {
            defText.text = "";
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (shieldName)
            {
                case "ShieldOne":
                    shieldOneTrans.position = shieldOneTransPos.position;
                    shieldName = "";
                    shieldOneActive = 1;
                    shieldOne = true;
                    break;
                case "ShieldTwo":
                    shieldTwoTrans.position = shieldTwoTransPos.position;
                    shieldName = "";
                    shieldTwoActive = 1;
                    shieldTwo = true;
                    break;
                case "ShieldThree":
                    shieldThreeTrans.position = shieldThreeTransPos.position;
                    shieldName = "";
                    shieldThreeActive = 1;
                    shieldThree = true;
                    break;
                case "ShieldFour":
                    shieldFourTrans.position = shieldFourTransPos.position;
                    shieldName = "";
                    shieldFourActive = 1;
                    shieldFour = true;
                    break;
                case "ShieldFive":
                    shieldFiveTrans.position = shieldFiveTransPos.position;
                    shieldName = "";
                    shieldFiveActive = 1;
                    shieldFive = true;
                    break;
                
            }
        }
    }
    
    public void UnEquipLeg()
    {
        if (legName != "")
        {
            spdText.text = "";
            SoundManager.instace.Play(SoundManager.SoundName.Equip);
            switch (legName)
            {
                case "LegOne":
                    legOneTrans.position = legOneTransPos.position;
                    legName = "";
                    legOneActive = 1;
                    legOne = true;
                    break;
                case "LegTwo":
                    legTwoTrans.position = legTwoTransPos.position;
                    legName = "";
                    legTwoActive = 1;
                    legTwo = true;
                    break;
                case "LegThree":
                    legThreeTrans.position = legThreeTransPos.position;
                    legName = "";
                    legThreeActive = 1;
                    legThree = true;
                    break;
                case "LegFour":
                    legFourTrans.position = legFourTransPos.position;
                    legName = "";
                    legFourActive = 1;
                    legFour = true;
                    break;
                case "LegFive":
                    legFiveTrans.position = legFiveTransPos.position;
                    legName = "";
                    legFiveActive = 1;
                    legFive = true;
                    break;
                
            }
        }
    }

    public void UpdateCoin(int coinIncome)
    {
        coin += coinIncome;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinText.text = "YOUR COIN: " + coin;
    }
}
