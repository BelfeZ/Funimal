using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusTextMage : MonoBehaviour
{
    [SerializeField] private TMP_Text level;
    [SerializeField] private TMP_Text type;
    [SerializeField] private TMP_Text hp;
    [SerializeField] private TMP_Text maxHp;
    [SerializeField] private TMP_Text sp;
    [SerializeField] private TMP_Text maxSp;
    [SerializeField] private TMP_Text atk;
    [SerializeField] private TMP_Text def;
    [SerializeField] private TMP_Text spd;
    [SerializeField] private MonsterBase _monsterBase;

    private LevelUpdate _levelUpdate;
    private void FixedUpdate()
    {
        _levelUpdate = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelUpdate>();
    }

    private void Update()
    {
        level.text = "" + _levelUpdate.levelMage;
        type.text = "TYPE: " + _monsterBase.Type;
        hp.text = "" + _monsterBase.CurrentHp;
        maxHp.text = "/" + _monsterBase.MaxHp;
        sp.text = "" + _monsterBase.CurrentSp;
        maxSp.text = "/" + _monsterBase.MaxSp;
        atk.text = "ATK: " + _monsterBase.Attack;
        def.text = "DEF: " + _monsterBase.Defence;
        spd.text = "SPD: " + _monsterBase.Speed;
    }
}
