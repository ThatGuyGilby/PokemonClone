using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster Move", menuName = "Monster/Move")]
public class MonsterMove : ScriptableObject
{
    public string moveName;
    public DamageType moveDamageType;
    [TextArea(5, 5)] public string moveDescription;
    public MonsterType moveType;
    public int power;
    public int accuracy;
    public int uses;
}

public enum DamageType
{
    Physical,
    Special,
    Status,
    Healing
}