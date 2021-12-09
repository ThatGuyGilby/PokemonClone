using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster Move", menuName = "Monster/Move")]
public class MonsterMove : ScriptableObject
{
    public string moveName;
    public MoveUseType moveUseType;
    [TextArea(5, 5)] public string moveDescription;
    public MonsterType moveType;
    public int attackPower;
    public int flatHealPercentage;
    public int accuracy;
    public int uses;
    public bool switchAfterUse;

    public GameObject enemyEffect;
    public GameObject userEffect;
}

public enum MoveUseType
{
    Physical,
    Special,
    Status,
    Healing
}