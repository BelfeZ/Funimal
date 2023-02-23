using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Monster
{
    public MonsterBase Base { set; get; }
    //public BattleHud Hud { set; get; }
    public int level { set; get; }
    public int HP { get; set; }
    public int SP { get; set; }
    public int ATK { get; set; }
    public int DEF { get; set; }
    public int Exp { get; set; }

    public List<Move> Moves { get; set; }
    
    private int setFirstBattleForPlayer = 0;

    public void Init()
    {
        HP = MaxHp;

        Moves = new List<Move>();
        foreach (var move in Base.LearnableMoves)
        {
            if (move.Level <= Level)
            {
                Moves.Add(new Move(move.Base));
            }

            if (Moves.Count >= 4)
            {
                break;
            }
        }
    }

    public Monster(MonsterBase mBase, int mLevel)
    {
        Base = mBase;
        level = mLevel;
        ATK = Attack;
        DEF = Defence;
        HP = CurrentHP;
        SP = CurrentSP;
        Moves = new List<Move>();
        foreach (var move in Base.LearnableMoves)
        {
            if (move.Level <= level)
            {
                Moves.Add(new Move(move.Base));
            }
        }
    }
    
    public int Attack
    {
        get { return Mathf.FloorToInt(Base.Attack+(level*5)); }
    }
    public int Defence
    {
        get { return Mathf.FloorToInt(Base.Defence+(level*5)); }
    }
    /*public int Speed
    {
        get { return Mathf.FloorToInt(Base.Speed+(Level*5)); }
    }*/
    public int MaxHp
    {
        get { return Mathf.FloorToInt(Base.MaxHp+(level*5)); }
    }
    public int MaxSp
    {
        get { return Mathf.FloorToInt(Base.MaxSp+(level*5));}
    }

    public int CurrentHP
    {
        get { return Mathf.FloorToInt(Base.CurrentHp+(level*5)); }
    }

    public int CurrentSP
    {
        get { return Mathf.FloorToInt(Base.CurrentSp+(level*5)); }
    }

    public int Level
    {
        get { return level; }
    }

    public bool CheckForLevelUp()
    {
        if (Exp > Base.GetExpForLevel(level + 1))
        {
            ++level;
            return true;
        }
        return false;
    }
    public bool UsableSkill(Move skill)
    {
        if (SP < skill.Base.SpCost)
        {
            return false;
        }
        SP -= skill.Base.SpCost;
        return true;
    }

    public void RegenSP()
    {
        if (SP + 3 <= MaxSp)
        {
            SP += 3; 
        }
        else
        {
            SP = MaxSp;
        }
    }

    public void SavePlayerHP(MonsterBase player)
    {
        player.CurrentHp = HP-(level*5);
        player.CurrentSp = SP-(level*5);
        if (SP <= 0)
        {
            SP = 0;
        }
    }
    
    public void GetBuffed(Move skill, int order)
    {
        int[,] t = new int[20,4];
        if (skill.Base.IsAtkBuff && skill.Base.IsDefBuff == false)
        {
            t[order,1] = skill.Base.Turn;
            ATK += skill.Base.AtkGain;
        }
        else if (skill.Base.IsDefBuff && skill.Base.IsAtkBuff == false)
        {
            t[order,2] = skill.Base.Turn;
            DEF += skill.Base.DefGain;
        }
        else if (skill.Base.IsAtkBuff && skill.Base.IsDefBuff)
        {
            t[order,3] = skill.Base.Turn;
            ATK += skill.Base.AtkGain;
            DEF += skill.Base.DefGain;
        }
    }

    public void ReturnStatus(int type, int value)
    {
        int[,] t = new int[20,4];
        if (type == 1)
        {
            ATK -= value;
        }
        else if (type == 2)
        {
            DEF -= value;
        }
        else if (type == 3)
        {
            ATK -= value;
            DEF -= value;
        }
    }

    public bool TakeSkillDamage(Move skill, Monster attacker)
    {
        float x = (5 * attacker.level) + attacker.Attack;
        float y;
        if (isSkillSuperEffective(skill))
        {
            y = (x + skill.Base.Power * 1.5f) - Defence;
        }
        else if (isSkillNotEffective(skill))
        {
            y = (x + skill.Base.Power * 0.5f) - Defence;
        }
        else
        {
            y = (x + skill.Base.Power) - Defence;
        }
        int damage = Mathf.FloorToInt(y);
        if (damage <= 0)
        {
            damage = 1;
        }
        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            return true;
        }
        return false;
    }

    public bool TakeNormalDamage(Monster attacker)
    {
        float x = (5 * attacker.level) + attacker.Attack;
        float y;
        if (isSuperEffective(attacker))
        {
            y = (x * 1.5f) - Defence;
        }
        else if (isNotEffective(attacker))
        {
            y = (x* 0.5f) - Defence;
        }
        else
        {
            y = x - Defence;
        }
        int damage = Mathf.FloorToInt(y);
        if (damage <= 0)
        {
            damage = 1;
        }
        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            return true;
        }
        return false;
    }
    
    public Move GetRandomMove()
    {
        int r = Random.Range(0, Moves.Count);
        return Moves[r];
    }
    
    public bool isHitted(int accuracy)
    {
        int r = Random.Range(0, 100);
        if (r <= accuracy)
        {
            return true;
        }
        return false;
    }

    public bool isSuperEffective(Monster attacker)
    {
        if (attacker.Base.Type == MonsterBase.MonsterType.Water && Base.Type == MonsterBase.MonsterType.Fire)
        {
            return true;
        }
        if (attacker.Base.Type == MonsterBase.MonsterType.Fire && Base.Type == MonsterBase.MonsterType.Earth)
        {
            return true;
        }
        if (attacker.Base.Type == MonsterBase.MonsterType.Earth && Base.Type == MonsterBase.MonsterType.Electric)
        {
            return true;
        }
        if (attacker.Base.Type == MonsterBase.MonsterType.Electric && Base.Type == MonsterBase.MonsterType.Water)
        {
            return true;
        }
        if (attacker.Base.Type == MonsterBase.MonsterType.Light && Base.Type == MonsterBase.MonsterType.Dark)
        {
            return true;
        }
        if (attacker.Base.Type == MonsterBase.MonsterType.Dark && Base.Type == MonsterBase.MonsterType.Light)
        {
            return true;
        }
        return false;
    }
    public bool isNotEffective(Monster attacker)
    {
        if (attacker.Base.Type == MonsterBase.MonsterType.Fire && Base.Type == MonsterBase.MonsterType.Water)
        {
            return true;
        }
        if (attacker.Base.Type == MonsterBase.MonsterType.Water && Base.Type == MonsterBase.MonsterType.Electric)
        {
            return true;
        }
        if (attacker.Base.Type == MonsterBase.MonsterType.Electric && Base.Type == MonsterBase.MonsterType.Earth)
        {
            return true;
        }
        if (attacker.Base.Type == MonsterBase.MonsterType.Earth && Base.Type == MonsterBase.MonsterType.Fire)
        {
            return true;
        }
        return false;
    }
    public bool isSkillSuperEffective(Move skill)
    {
        if (skill.Base.Type == MonsterBase.MonsterType.Water && Base.Type == MonsterBase.MonsterType.Fire)
        {
            return true;
        }
        if (skill.Base.Type == MonsterBase.MonsterType.Fire && Base.Type == MonsterBase.MonsterType.Earth)
        {
            return true;
        }
        if (skill.Base.Type == MonsterBase.MonsterType.Earth && Base.Type == MonsterBase.MonsterType.Electric)
        {
            return true;
        }
        if (skill.Base.Type == MonsterBase.MonsterType.Electric && Base.Type == MonsterBase.MonsterType.Water)
        {
            return true;
        }
        if (skill.Base.Type == MonsterBase.MonsterType.Light && Base.Type == MonsterBase.MonsterType.Dark)
        {
            return true;
        }
        if (skill.Base.Type == MonsterBase.MonsterType.Dark && Base.Type == MonsterBase.MonsterType.Light)
        {
            return true;
        }
        return false;
    }
    public bool isSkillNotEffective(Move skill)
    {
        if (skill.Base.Type == MonsterBase.MonsterType.Fire && Base.Type == MonsterBase.MonsterType.Water)
        {
            return true;
        }
        if (skill.Base.Type == MonsterBase.MonsterType.Water && Base.Type == MonsterBase.MonsterType.Electric)
        {
            return true;
        }
        if (skill.Base.Type == MonsterBase.MonsterType.Electric && Base.Type == MonsterBase.MonsterType.Earth)
        {
            return true;
        }
        if (skill.Base.Type == MonsterBase.MonsterType.Earth && Base.Type == MonsterBase.MonsterType.Fire)
        {
            return true;
        }
        return false;
    }
}
