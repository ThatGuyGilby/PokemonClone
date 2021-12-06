using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster Species", menuName = "Monster/Species")]
public class MonsterSpecies : ScriptableObject
{
    public string speciesName;
    public List<MonsterType> types;
    public List<MonsterAbility> abilities;
    public MonsterAbility hiddenAbility;
    [Space(5)]
    [Header("Base Stats")]
    public int health;
    public int attack;
    public int defence;
    public int specialAttack;
    public int specialDefence;
    public int speed;
    [Space(5)]
    [Header("Moves")]
    public List<MonsterMove> moves;
}
