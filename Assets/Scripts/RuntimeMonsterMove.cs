using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RuntimeMonsterMove
{
    public MonsterMove move;
    public int uses;
    public int maxUses;

    public RuntimeMonsterMove(MonsterMove _move)
    {
        move = _move;
        maxUses = _move.uses;
        uses = maxUses;
    }
}
