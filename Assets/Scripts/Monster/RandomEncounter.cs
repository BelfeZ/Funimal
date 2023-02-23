using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomEncounter : MonoBehaviour
{
    [SerializeField] private List<MonsterEncounterRecord> monsters;

    private void Start()
    {
        int totalChance = 0;
        foreach (var record in monsters)
        {
            record.chanceLower = totalChance;
            record.chanceUpper = totalChance + record.chancePercentage;

            totalChance = totalChance + record.chancePercentage;
        }
    }

    [System.Serializable]
    public class MonsterEncounterRecord
    {
        public MonsterBase monster;
        public Vector2Int levelRange;
        public int chancePercentage;

        public int chanceLower { get; set; }
        public int chanceUpper { get; set; }
    }

    public Monster GetRandomMonster()
    {
        int randVal = Random.Range(1, 101);
        var monsterRecord = monsters.First(p => randVal >= p.chanceLower && randVal <= p.chanceUpper);

        var levelRange = monsterRecord.levelRange;
        int level = levelRange.y == 0 ? levelRange.x : Random.Range(levelRange.x, levelRange.y + 1);

        var monster = new Monster(monsterRecord.monster, level);
        monster.Init();
        return monster;
    }
}
