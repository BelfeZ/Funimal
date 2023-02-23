using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleHud : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text spText;
    [SerializeField] private HPBar hpBar;
    [SerializeField] private bool isPlayer;

    private Monster _monster;
    public void SetData(Monster monster)
    {
        _monster = monster;
        nameText.text = _monster.Base.Name;
        SetLevel();
        if (isPlayer)
        {
            spText.text = _monster.SP + " SP";
        }
        hpBar.SetHP((float) _monster.HP / _monster.MaxHp);
    }

    public void UpdateHP(Monster monster)
    {
        hpBar.SetHP((float) monster.HP / monster.MaxHp);
    }

    public void UpdateSP(Monster monster)
    {
        spText.text = monster.SP + " SP";
    }

    public void SetLevel()
    {
        //float normalizedExp = GetNormalizedExp();
        levelText.text = "Lv. " + _monster.level;
    }

    float GetNormalizedExp()
    {
        int currLevelExp = _monster.Base.GetExpForLevel(_monster.level);
        int nextLevelExp = _monster.Base.GetExpForLevel(_monster.level + 1);

        float normalizedExp = (float) (_monster.Exp - currLevelExp) / (nextLevelExp - currLevelExp);
        return Mathf.Clamp01 (normalizedExp);
    }
}
