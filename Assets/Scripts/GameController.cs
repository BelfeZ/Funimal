using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {FreeRoam, Battle}
public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private BattleSystem _battleSystem;
    [SerializeField] private Camera worldCamera;
    private GameState state;
    private SoundManager _soundManager;
    private PlaySoundTwo _playSoundTwo;
    private GameObject inventoryCanvas;
    private GameObject gameManager;
    private bool allStartActive;
    //private GameObject block;
    private AllMenu _allMenu;
    private InventoryBattle _inventoryBattle;

    [SerializeField] private MonsterBase swordman;
    [SerializeField] private MonsterBase mage;
    private void Start()
    {
    }

    void StartBattle()
    {
        _inventoryBattle.battleOn = true;
        _inventoryBattle.battleScene.SetActive(true);
        _inventoryBattle.normalScene.SetActive(false);
        _allMenu.findBattle = true;
        _allMenu.UnBlock();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManager.SetActive(false);
        SoundManager.instace.Play(SoundManager.SoundName.BattleSong);
        
        state = GameState.Battle;
        _battleSystem.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);

        var wildMonster = FindObjectOfType<RandomEncounter>().GetComponent<RandomEncounter>().GetRandomMonster();
        _battleSystem.StartBattle(wildMonster);
    }

    void EndBattle(bool won)
    {
        if (_inventoryBattle._swordAtkBootsActived)
        {
            _inventoryBattle._swordAtkBootsActived = false;
            _inventoryBattle._swordAtkBootsActive = 2;
            swordman.Attack /= 2;
        }
        
        if (_inventoryBattle._mageAtkBootsActived)
        {
            _inventoryBattle._mageAtkBootsActived = false;
            _inventoryBattle._mageAtkBootsActive = 2;
            mage.Attack /= 2;
        }
        _inventoryBattle.battleOn = false;
        

        _inventoryBattle.battleScene.SetActive(false);
        _inventoryBattle.normalScene.SetActive(true);
        _allMenu.playerPlay = 1;
        _allMenu.findBattle = false;
        _allMenu.Block();
        //block.SetActive(true);
        gameManager.SetActive(true);
        SoundManager.instace.Stop(SoundManager.SoundName.BattleSong);
        _playSoundTwo.soundPlay = false;
        
        state = GameState.FreeRoam;
        _battleSystem.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
        
    }
    void Update()
    {
        if (!allStartActive)
        {
            //block = GameObject.FindGameObjectWithTag("Block");
            
            _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
            _playSoundTwo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlaySoundTwo>();
            _playerController.OnEncountered += StartBattle;
            _battleSystem.OnBattleOver += EndBattle;
            _allMenu = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AllMenu>();
            _inventoryBattle = GameObject.FindGameObjectWithTag("GameManager2").GetComponent<InventoryBattle>();
            allStartActive = true;
        }
        if (swordman.CurrentHp < 0)
        {
            swordman.CurrentHp = 0;
        }
        if (swordman.CurrentSp < 0)
        {
            swordman.CurrentSp = 0;
        }
        if (mage.CurrentHp < 0)
        {
            mage.CurrentHp = 0;
        }
        if (mage.CurrentSp < 0)
        {
            mage.CurrentSp = 0;
        }
        if (state == GameState.FreeRoam)
        {
            _playerController.HandleUpdate();
        }
        else if (state == GameState.Battle)
        {
            _battleSystem.HandleUpdate();
        }
    }
}
