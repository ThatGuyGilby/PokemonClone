using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster Type", menuName = "Monster/Type")]
public class MonsterType : ScriptableObject
{
    public string typeName;

    public List<MonsterType> weaknesses;
    public List<MonsterType> resistances;
    public List<MonsterType> immunities;
}
