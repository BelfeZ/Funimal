using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AllMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject equip;
    public GameObject inventory;
    public GameObject status;
    public GameObject weapon;
    public GameObject artifact;
    public GameObject makeSure;
    public GameObject setting;
    private PlayerInventory _playerInventory;
    private SoundManager _soundManager;
    [SerializeField] private MonsterBase swordMan;
    [SerializeField] private MonsterBase mage;

    [SerializeField] private GameObject swordManStatus;
    [SerializeField] private GameObject mageStatus;
    [SerializeField] private GameObject block;

    [SerializeField] private GameObject swordManInventory;
    [SerializeField] private GameObject mageInventory;
    private bool swordStatusOn = true;
    private bool mageStatusOn = false;
    private bool swordInventory = true;
    private bool magePlayerInventory = false;
    public bool notMainMenu = false;

    public int playerPlay;
    public bool menuActive = false;
    public bool findBattle;

    [SerializeField] private BattleSystem _battleSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerInventory = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<PlayerInventory>();
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        menu.SetActive(false);
        equip.SetActive(false);
        inventory.SetActive(false);
        status.SetActive(false);
        weapon.SetActive(false);
        artifact.SetActive(false);
        makeSure.SetActive(false);
        setting.SetActive(false);
        mageInventory.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        Menu();

    }
    
    public void UnBlock()
    {
        block.SetActive(false);
    }

    public void Block()
    {
        block.SetActive(true);
    }

    private void Menu()
    {
        if (notMainMenu)
        {
            if (menuActive == false)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Cursor.visible = true;
                    menu.SetActive(true);
                    menuActive = true;
                    Time.timeScale = 0f;
                    SoundManager.instace.Play(SoundManager.SoundName.Menu);
                }
            }
            else if (menuActive == true)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Cursor.visible = false;

                    menuActive = false;

                    menu.SetActive(false);

                    status.SetActive(false);

                    inventory.SetActive(false);

                    equip.SetActive(false);

                    weapon.SetActive(false);

                    artifact.SetActive(false);

                    makeSure.SetActive(false);

                    setting.SetActive(false);

                    Time.timeScale = 1.0f;

                    SoundManager.instace.Play(SoundManager.SoundName.Menu);
                }
            }
        }
    }

    public void InventoryButton()
    {
        inventory.SetActive(true);
        menu.SetActive(false);
        makeSure.SetActive(false);
        setting.SetActive(false);
        SoundManager.instace.Play(SoundManager.SoundName.ButtonClick);
    }
    
    public void EquipmentButton()
    {
        equip.SetActive(true);
        menu.SetActive(false);
        makeSure.SetActive(false);
        setting.SetActive(false);
        SoundManager.instace.Play(SoundManager.SoundName.ButtonClick);
    }
    
    public void StatusButton()
    {
        status.SetActive(true);
        menu.SetActive(false);
        makeSure.SetActive(false);
        setting.SetActive(false);
        SoundManager.instace.Play(SoundManager.SoundName.ButtonClick);
    }

    public void WeaponButton()
    {
        weapon.SetActive(true);
        equip.SetActive(false);
        SoundManager.instace.Play(SoundManager.SoundName.ButtonClick);
    }

    public void ArtifactButton()
    {
        artifact.SetActive(true);
        equip.SetActive(false);
        SoundManager.instace.Play(SoundManager.SoundName.ButtonClick);
    }

    public void SettingButton()
    {
        setting.SetActive(true);
        makeSure.SetActive(false);
        SoundManager.instace.Play(SoundManager.SoundName.ButtonClick);
    }

    public void BackSetting()
    {
        setting.SetActive(false);
        SoundManager.instace.Play(SoundManager.SoundName.ButtonClick2);
    }

    public void MenuBackButton()
    {
        menu.SetActive(true);
        
        status.SetActive(false);
                
        inventory.SetActive(false);
                
        equip.SetActive(false);

        weapon.SetActive(false);

        artifact.SetActive(false);
        
        SoundManager.instace.Play(SoundManager.SoundName.ButtonClick2);
    }

    public void HpPotionUse()
    {
        if (_playerInventory.hpPotion > 0)
        {
            switch (playerPlay)
            {
                case 1 when swordMan.CurrentHp < swordMan.MaxHp && swordMan.IsAlive:
                {
                    _playerInventory.hpPotion -= 1;
                    swordMan.CurrentHp += 50;
                    SoundManager.instace.Play(SoundManager.SoundName.UseItem);

                    if (swordMan.CurrentHp > swordMan.MaxHp)
                    {
                        swordMan.CurrentHp = swordMan.MaxHp;
                    }

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
                case 2 when mage.CurrentHp < mage.MaxHp && mage.IsAlive:
                {
                    _playerInventory.hpPotion -= 1;
                    mage.CurrentHp += 50;
                    SoundManager.instace.Play(SoundManager.SoundName.UseItem);

                    if (mage.CurrentHp > mage.MaxHp)
                    {
                        mage.CurrentHp = mage.MaxHp;
                    }

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
                default:
                    SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                    break;
            }
        }
        else if (_playerInventory.hpPotion <= 0)
        {
            SoundManager.instace.Play(SoundManager.SoundName.NoItem);
        }
        
    }
    
    public void MpPotionUse()
    {
        if (_playerInventory.mpPotion > 0)
        {
            switch (playerPlay)
            {
                case 1 when swordMan.CurrentSp < swordMan.MaxSp && swordMan.IsAlive:
                {
                    _playerInventory.mpPotion -= 1;
                    swordMan.CurrentSp += 20;
                    SoundManager.instace.Play(SoundManager.SoundName.UseItem);
                    Debug.Log("+MP");
                    if (swordMan.CurrentSp > swordMan.MaxSp)
                    {
                        swordMan.CurrentSp = swordMan.MaxSp;
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
                case 2 when mage.CurrentSp < mage.MaxSp && mage.IsAlive:
                {
                    _playerInventory.mpPotion -= 1;
                    mage.CurrentSp += 20;
                    SoundManager.instace.Play(SoundManager.SoundName.UseItem);
                    Debug.Log("+MP");
                    if (mage.CurrentSp > mage.MaxSp)
                    {
                        mage.CurrentSp = mage.MaxSp;
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
                default:
                    SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                    break;
            }
        }
        else if (_playerInventory.mpPotion <= 0)
        {
            SoundManager.instace.Play(SoundManager.SoundName.NoItem);
        }
    }
    
    public void FullPotionUse()
    {
        if (_playerInventory.fullPotion > 0)
        {
            switch (playerPlay)
            {
                case 1 when swordMan.CurrentHp < swordMan.MaxHp && swordMan.IsAlive:
                    _playerInventory.fullPotion -= 1;
                    swordMan.CurrentHp = swordMan.MaxHp;
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
                case 2 when mage.CurrentHp < mage.MaxHp && mage.IsAlive:
                    _playerInventory.fullPotion -= 1;
                    mage.CurrentHp = mage.MaxHp;
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
                default:
                    SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                    break;
            }
        }
        else if (_playerInventory.fullPotion <= 0)
        {
            SoundManager.instace.Play(SoundManager.SoundName.NoItem);
        }
    }
    
    
    

    public void MainMenuBack()
    {
        SoundManager.instace.Play(SoundManager.SoundName.ButtonClick);
        makeSure.SetActive(true);
        setting.SetActive(false);
        
    }

    public void NoBack()
    {
        SoundManager.instace.Play(SoundManager.SoundName.ButtonClick);
        makeSure.SetActive(false);
    }

    public void ChangeStatus()
    {
        if (swordStatusOn)
        {
            swordManStatus.SetActive(false);
            mageStatus.SetActive(true);
            swordStatusOn = false;
            mageStatusOn = true;
        }
        else if (mageStatusOn)
        {
            mageStatus.SetActive(false);
            swordManStatus.SetActive(true);
            swordStatusOn = true;
            mageStatusOn = false;
        }
    }

    public void ChangeInventoryPlayer()
    {
        if (swordInventory)
        {
            playerPlay = 2;
            swordManInventory.SetActive(false);
            mageInventory.SetActive(true);
            swordInventory = false;
            magePlayerInventory = true;
        }
        else if (magePlayerInventory)
        {
            playerPlay = 1;
            mageInventory.SetActive(false);
            swordManInventory.SetActive(true);
            magePlayerInventory = false;
            swordInventory = true;
            
        }
    }

    
    

    
}
