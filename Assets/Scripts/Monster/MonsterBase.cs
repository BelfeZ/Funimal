using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Monster/Create new monster")]
public class MonsterBase : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private Sprite sprite;
    [SerializeField] private bool isBoss;
    [SerializeField] private bool isPlayer1;
    [SerializeField] private bool isPlayer2;
    [SerializeField] private bool isAlive;
    [SerializeField] private MonsterType type;
    [SerializeField] private int maxHp;
    [SerializeField] private int currentHp;
    [SerializeField] private int maxSp;
    [SerializeField] private int currentSp;
    [SerializeField] private int attack;
    [SerializeField] private int defence;
    [SerializeField] private int expYield;
    [SerializeField] private int speed;
    [SerializeField] private List<LearnableMove> learnableMoves;
    [SerializeField] private int moneyDrop;
    
    [SerializeField] private int savedLevel;
    [SerializeField] private int savedHp;
    [SerializeField] private int savedSp;
    [SerializeField] private int savedExp;

    public int GetExpForLevel(int level)
    {
        int maxExp = level * level * level;
        return maxExp;
    }

    public string Name
    {
        get { return name; }
    }

    public Sprite Sprite
    {
        get { return sprite; }
    }

    public MonsterType Type
    {
        get { return type; }

        set => type = value;
    }

    public bool IsBoss
    {
        get { return isBoss; }
    }

    public bool IsPlayer1
    {
        get { return isPlayer1; }
    }

    public bool IsPlayer2
    {
        get { return isPlayer2; }
    }

    public bool IsAlive
    {
        get { return isAlive; }
        set { this.isAlive = value; }
    }

    public int MaxHp
    {
        get { return maxHp; }

        set => maxHp = value;
    }

    public int CurrentHp
    {
        get { return currentHp; }

        set => currentHp = value;
    }

    public int MaxSp
    {
        get { return maxSp; }

        set => maxSp = value;
    }

    public int CurrentSp
    {
        get { return currentSp; }

        set => currentSp = value;
    }

    public int Attack
    {
        get { return attack; }

        set => attack = value;
    }

    public int Defence
    {
        get { return defence; }

        set => defence = value;
    }

    public int Speed
    {
        get { return speed; }

        set => speed = value;
    }
    
    public int SavedLevel
    {
        get { return savedLevel; }

        set => savedLevel = value;
    }

    public int SavedHp
    {
        get { return savedHp; }

        set => savedSp = value;
    }

    public int SavedSp
    {
        get { return savedSp; }

        set => savedSp = value;
    }

    public int SavedExp
    {
        get { return savedExp; }

        set => savedExp = value;
    }

    public List<LearnableMove> LearnableMoves
    {
        get { return learnableMoves; }
    }

    public int MoneyDrop
    {
        get { return moneyDrop; }
    }

    public int ExpYield => expYield;

    [System.Serializable]
    public class LearnableMove
    {
        [SerializeField] private MoveBase moveBase;
        [SerializeField] int level;

        public MoveBase Base
        {
            get { return moveBase; }
        }

        public int Level
        {
            get { return level; }
        }
    }
    public enum MonsterType
    {
        Fire,
        Water,
        Earth,
        Electric,
        Dark,
        Light,
        Normal
    }
}
