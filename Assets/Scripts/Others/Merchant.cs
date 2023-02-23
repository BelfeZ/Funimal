using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    [SerializeField] private RectTransform backGroundBox;
    [SerializeField] private TMP_Text yourCoinText;
    [SerializeField] private TMP_Text merchantText;
    [SerializeField] private string startMessage;
    [SerializeField] private string buyMessage;
    [SerializeField] private string noMoneyMessage;
    private int yourCoin;

    private PlayerInventory _playerInventory;
    private SoundManager _soundManager;
    [SerializeField] private GameObject swordOne;
    [SerializeField] private GameObject swordTwo;
    [SerializeField] private GameObject swordThree;
    [SerializeField] private GameObject swordFour;
    [SerializeField] private GameObject swordFive;
    
    [SerializeField] private GameObject shieldOne;
    [SerializeField] private GameObject shieldTwo;
    [SerializeField] private GameObject shieldThree;
    [SerializeField] private GameObject shieldFour;
    [SerializeField] private GameObject shieldFive;
    
    [SerializeField] private GameObject legOne;
    [SerializeField] private GameObject legTwo;
    [SerializeField] private GameObject legThree;
    [SerializeField] private GameObject legFour;
    [SerializeField] private GameObject legFive;

    private bool swordOneSell;
    private bool swordTwoSell;
    private bool swordThreeSell;
    private bool swordFourSell;
    private bool swordFiveSell;
    
    private bool shieldOneSell;
    private bool shieldTwoSell;
    private bool shieldThreeSell;
    private bool shieldFourSell;
    private bool shieldFiveSell;
    
    private bool legOneSell;
    private bool legTwoSell;
    private bool legThreeSell;
    private bool legFourSell;
    private bool legFiveSell;

    public bool allStartActive;

    private AllMenu _allMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!allStartActive)
        {
            _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
            _playerInventory = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<PlayerInventory>();
            _playerInventory = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<PlayerInventory>();
            _allMenu = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AllMenu>();
            backGroundBox.transform.localScale = Vector3.zero;
            allStartActive = true;
        }
        
        yourCoin = _playerInventory.coin;
        YourCoinText();
    }

    private void OpenShop()
    {
        SoundManager.instace.Play(SoundManager.SoundName.Shop);
        backGroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();;
        Cursor.visible = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            merchantText.text = "" + startMessage;
            OpenShop();
            _allMenu.notMainMenu = false;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            backGroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            Cursor.visible = false;
            _allMenu.notMainMenu = true;
        }
    }

    private void YourCoinText()
    {
        yourCoinText.text = "YOUR COIN: " + yourCoin;
    }

    public void BuyHpPotion()
    {
        _playerInventory.coin -= 10;
        
        if (_playerInventory.coin >= 0)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Buy);
            merchantText.text = "" + buyMessage;
            _playerInventory.hpPotion += 1;
        }
        else if (_playerInventory.coin < 0)
        {
            SoundManager.instace.Play(SoundManager.SoundName.NoItem);
            merchantText.text = "" + noMoneyMessage;
            _playerInventory.coin += 10;
        }
    }
    
    public void BuyMpPotion()
    {
        _playerInventory.coin -= 20;
        
        if (_playerInventory.coin >= 0)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Buy);
            merchantText.text = "" + buyMessage;
            _playerInventory.mpPotion += 1;
        }
        else if (_playerInventory.coin < 0)
        {
            SoundManager.instace.Play(SoundManager.SoundName.NoItem);
            merchantText.text = "" + noMoneyMessage;
            _playerInventory.coin += 20;
        }
    }
    
    public void BuyFullPotion()
    {
        _playerInventory.coin -= 50;
        
        if (_playerInventory.coin >= 0)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Buy);
            merchantText.text = "" + buyMessage;
            _playerInventory.fullPotion += 1;
        }
        else if (_playerInventory.coin < 0)
        {
            SoundManager.instace.Play(SoundManager.SoundName.NoItem);
            merchantText.text = "" + noMoneyMessage;
            _playerInventory.coin += 50;
        }
    }
    
    public void BuyAtkBoots()
    {
        _playerInventory.coin -= 100;
        
        if (_playerInventory.coin >= 0)
        {
            SoundManager.instace.Play(SoundManager.SoundName.Buy);
            merchantText.text = "" + buyMessage;
            _playerInventory.attackBoots += 1;
        }
        else if (_playerInventory.coin < 0)
        {
            SoundManager.instace.Play(SoundManager.SoundName.NoItem);
            merchantText.text = "" + noMoneyMessage;
            _playerInventory.coin += 100;
        }
    }
    
    public void BuySwordOne()
    {
        if (swordOneSell == false)
        {
            _playerInventory.coin -= 50;
            if (_playerInventory.coin >= 0)
            {
                swordOneSell = true;
                _playerInventory.swordOne = true;
                SoundManager.instace.Play(SoundManager.SoundName.Buy);
                merchantText.text = "" + buyMessage;
                swordOne.SetActive(false);
            }
            else if (_playerInventory.coin < 0)
            {
                _playerInventory.coin += 50;
                SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                merchantText.text = "" + noMoneyMessage;
            }
        }
    }
    
    public void BuySwordTwo()
    {
        if (swordTwoSell == false)
        {
            _playerInventory.coin -= 300;
            if (_playerInventory.coin >= 0)
            {
                swordTwoSell = true;
                _playerInventory.swordTwo = true;
                SoundManager.instace.Play(SoundManager.SoundName.Buy);
                merchantText.text = "" + buyMessage;
                swordTwo.SetActive(false);
            }
            else if (_playerInventory.coin < 0)
            {
                _playerInventory.coin += 300;
                SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                merchantText.text = "" + noMoneyMessage;
            }
        }
    }
    
    public void BuySwordThree()
    {
        if (swordThreeSell == false)
        {
            _playerInventory.coin -= 450;
            if (_playerInventory.coin >= 0)
            {
                swordThreeSell = true;
                _playerInventory.swordThree = true;
                SoundManager.instace.Play(SoundManager.SoundName.Buy);
                merchantText.text = "" + buyMessage;
                swordThree.SetActive(false);
            }
            else if (_playerInventory.coin < 0)
            {
                _playerInventory.coin += 450;
                SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                merchantText.text = "" + noMoneyMessage;
            }
        }
    }
    
    public void BuySwordFour()
    {
        if (swordFourSell == false)
        {
            _playerInventory.coin -= 750;
            if (_playerInventory.coin >= 0)
            {
                swordFourSell = true;
                _playerInventory.swordFour = true;
                SoundManager.instace.Play(SoundManager.SoundName.Buy);
                merchantText.text = "" + buyMessage;
                swordFour.SetActive(false);
            }
            else if (_playerInventory.coin < 0)
            {
                _playerInventory.coin += 750;
                SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                merchantText.text = "" + noMoneyMessage;
            }
        }
    }
    
    public void BuySwordFive()
    {
        if (swordFiveSell == false)
        {
            _playerInventory.coin -= 1250;
            if (_playerInventory.coin >= 0)
            {
                swordFiveSell = true;
                _playerInventory.swordFive = true;
                SoundManager.instace.Play(SoundManager.SoundName.Buy);
                merchantText.text = "" + buyMessage;
                swordFive.SetActive(false);
            }
            else if (_playerInventory.coin < 0)
            {
                _playerInventory.coin += 1250;
                SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                merchantText.text = "" + noMoneyMessage;
            }
        }
    }
    
    public void BuyShieldOne()
    {
        if (shieldOneSell == false)
        {
            _playerInventory.coin -= 45;
            if (_playerInventory.coin >= 0)
            {
                shieldOneSell = true;
                _playerInventory.shieldOne = true;
                SoundManager.instace.Play(SoundManager.SoundName.Buy);
                merchantText.text = "" + buyMessage;
                shieldOne.SetActive(false);
            }
            else if (_playerInventory.coin < 0)
            {
                _playerInventory.coin += 45;
                SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                merchantText.text = "" + noMoneyMessage;
            }
        }
    }
    
    public void BuyShieldTwo()
    {
        if (shieldTwoSell == false)
        {
            _playerInventory.coin -= 250;
            if (_playerInventory.coin >= 0)
            {
                shieldTwoSell = true;
                _playerInventory.shieldTwo = true;
                SoundManager.instace.Play(SoundManager.SoundName.Buy);
                merchantText.text = "" + buyMessage;
                shieldTwo.SetActive(false);
            }
            else if (_playerInventory.coin < 0)
            {
                _playerInventory.coin += 250;
                SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                merchantText.text = "" + noMoneyMessage;
            }
        }
    }
    
    public void BuyShieldThree()
    {
        if (shieldThreeSell == false)
        {
            _playerInventory.coin -= 420;
            if (_playerInventory.coin >= 0)
            {
                shieldThreeSell = true;
                _playerInventory.shieldThree = true;
                SoundManager.instace.Play(SoundManager.SoundName.Buy);
                merchantText.text = "" + buyMessage;
                shieldThree.SetActive(false);
            }
            else if (_playerInventory.coin < 0)
            {
                _playerInventory.coin += 420;
                SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                merchantText.text = "" + noMoneyMessage;
            }
        }
    }
    
    public void BuyShieldFour()
    {
        if (shieldFourSell == false)
        {
            _playerInventory.coin -= 725;
            if (_playerInventory.coin >= 0)
            {
                shieldFourSell = true;
                _playerInventory.shieldFour = true;
                SoundManager.instace.Play(SoundManager.SoundName.Buy);
                merchantText.text = "" + buyMessage;
                shieldFour.SetActive(false);
            }
            else if (_playerInventory.coin < 0)
            {
                _playerInventory.coin += 725;
                SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                merchantText.text = "" + noMoneyMessage;
            }
        }
    }
    
    public void BuyShieldFive()
    {
        if (shieldFiveSell == false)
        {
            _playerInventory.coin -= 1150;
            if (_playerInventory.coin >= 0)
            {
                shieldFiveSell = true;
                _playerInventory.shieldFive = true;
                SoundManager.instace.Play(SoundManager.SoundName.Buy);
                merchantText.text = "" + buyMessage;
                shieldFive.SetActive(false);
            }
            else if (_playerInventory.coin < 0)
            {
                _playerInventory.coin += 1150;
                SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                merchantText.text = "" + noMoneyMessage;
            }
        }
    }
    
    public void BuyLegOne()
    {
        if (legOneSell == false)
        {
            _playerInventory.coin -= 30;
            if (_playerInventory.coin >= 0)
            {
                legOneSell = true;
                _playerInventory.legOne = true;
                SoundManager.instace.Play(SoundManager.SoundName.Buy);
                merchantText.text = "" + buyMessage;
                legOne.SetActive(false);
            }
            else if (_playerInventory.coin < 0)
            {
                _playerInventory.coin += 30;
                SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                merchantText.text = "" + noMoneyMessage;
            }
        }
    }
    
    public void BuyLegTwo()
    {
        if (legTwoSell == false)
        {
            _playerInventory.coin -= 200;
            if (_playerInventory.coin >= 0)
            {
                legTwoSell = true;
                _playerInventory.legTwo = true;
                SoundManager.instace.Play(SoundManager.SoundName.Buy);
                merchantText.text = "" + buyMessage;
                legTwo.SetActive(false);
            }
            else if (_playerInventory.coin < 0)
            {
                _playerInventory.coin += 200;
                SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                merchantText.text = "" + noMoneyMessage;
            }
        }
    }
    
    public void BuyLegThree()
    {
        if (legThreeSell == false)
        {
            _playerInventory.coin -= 350;
            if (_playerInventory.coin >= 0)
            {
                legThreeSell = true;
                _playerInventory.legThree = true;
                SoundManager.instace.Play(SoundManager.SoundName.Buy);
                merchantText.text = "" + buyMessage;
                legThree.SetActive(false);
            }
            else if (_playerInventory.coin < 0)
            {
                _playerInventory.coin += 350;
                SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                merchantText.text = "" + noMoneyMessage;
            }
        }
    }
    
    public void BuyLegFour()
    {
        if (legFourSell == false)
        {
            _playerInventory.coin -= 650;
            if (_playerInventory.coin >= 0)
            {
                legFourSell = true;
                _playerInventory.legFour = true;
                SoundManager.instace.Play(SoundManager.SoundName.Buy);
                merchantText.text = "" + buyMessage;
                legFour.SetActive(false);
            }
            else if (_playerInventory.coin < 0)
            {
                _playerInventory.coin += 650;
                SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                merchantText.text = "" + noMoneyMessage;
            }
        }
    }
    
    public void BuyLegFive()
    {
        if (legFiveSell == false)
        {
            _playerInventory.coin -= 1000;
            if (_playerInventory.coin >= 0)
            {
                legFiveSell = true;
                _playerInventory.legFive = true;
                SoundManager.instace.Play(SoundManager.SoundName.Buy);
                merchantText.text = "" + buyMessage;
                legFive.SetActive(false);
            }
            else if (_playerInventory.coin < 0)
            {
                _playerInventory.coin += 1000;
                SoundManager.instace.Play(SoundManager.SoundName.NoItem);
                merchantText.text = "" + noMoneyMessage;
            }
        }
    }
}
