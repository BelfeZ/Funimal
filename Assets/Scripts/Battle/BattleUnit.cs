using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] private MonsterBase _base;
    public int level;
    //[SerializeField] private int minlevel;
    //[SerializeField] private int maxlevel;
    public BattleHud Hud { set; get; }
    public Monster monster { get; set; }

    private StatusText _statusText;
    private StatusTextMage _statusTextMage;

    private void Start()
    {
        //_statusText = GameObject.FindGameObjectWithTag("GameManager").GetComponent<StatusText>();
        // = GameObject.FindGameObjectWithTag("GameManager").GetComponent<StatusTextMage>();
    }

    public void Setup()
    {
        monster = new Monster(_base, level);
        GetComponent<Image>().sprite = monster.Base.Sprite;
    }

    public void MonsterSetup(Monster randomedMonster)
    {
        monster = randomedMonster;
        //int x = Random.Range(minlevel, maxlevel);
        //monster = new Monster(_base, x);
        GetComponent<Image>().sprite = monster.Base.Sprite;
    }
    public void SaveLevel()
    {
        level++;
    }
}