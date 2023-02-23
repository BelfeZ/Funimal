using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Move/Create new move")]
public class MoveBase : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private MonsterBase.MonsterType type;
    [SerializeField] private int power;
    [SerializeField] private int accuracy;
    [SerializeField] private int spCost;
    [SerializeField] private bool isBuff;
    [SerializeField] private bool isAtkBuff;
    [SerializeField] private int atkGain;
    [SerializeField] private bool isDefBuff;
    [SerializeField] private int defGain;
    [SerializeField] private int turn;
    [SerializeField] private SoundManager.SoundName sound;

    public string Name
    {
        get { return name; }
    }
    public MonsterBase.MonsterType Type
    {
        get { return type; }
    }
    public int Power
    {
        get { return power; }
    }
    public int Accuracy
    {
        get { return accuracy; }
    }
    public int SpCost
    {
        get { return spCost; }
    }

    public bool IsBuff
    {
        get { return isBuff; }
    }
    
    public bool IsAtkBuff
    {
        get { return isAtkBuff; }
    }
    
    public bool IsDefBuff
    {
        get { return isDefBuff; }
    }

    public int AtkGain
    {
        get { return atkGain; }
    }
    
    public int DefGain
    {
        get { return defGain; }
    }
    
    public int Turn
    {
        get { return turn; }
    }

    public SoundManager.SoundName Sound
    {
        get { return sound; }
    }
    
}
