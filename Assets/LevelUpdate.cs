using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpdate : MonoBehaviour
{
    public static int levelSwordPlayer = 1;
    public static int levelMagePlayer = 1;
    public int levelSword;
    public int levelMage;

    private BattleUnit mageUnit;
    private BattleUnit swordUnit;
    private bool dontDestroy = true;
    private void Awake()
    {
        swordUnit = GameObject.Find("Player1Unit").GetComponent<BattleUnit>();
        mageUnit = GameObject.Find("Player2Unit").GetComponent<BattleUnit>();
        swordUnit.level = levelSwordPlayer;
        mageUnit.level = levelMagePlayer;
        
    }

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        levelSword = levelSwordPlayer;
        levelMage = levelMagePlayer;
        
    }

    public void levelUp()
    {
        levelSwordPlayer = swordUnit.level;
        levelMagePlayer = mageUnit.level;
    }
}
