using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster Ability", menuName = "Monster/Ability")]
public class MonsterAbility : ScriptableObject
{
    public string abilityName;
    [TextArea(5, 5)] public string abilityDescription;
}
