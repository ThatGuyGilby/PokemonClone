using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveButtonUI : MonoBehaviour
{
    public TMP_Text moveName;
    public TMP_Text moveType;
    public TMP_Text moveUses;

    RuntimeMonsterMove move;
    BattleSystem battleSystem;

    private void Start()
    {
        battleSystem = BattleSystem.Instance;
    }

    public void SetMove(RuntimeMonsterMove _move)
    {
        moveName.text = _move.move.moveName;
        moveType.text = _move.move.moveType.typeName;
        moveUses.text = $"{_move.uses} / {_move.maxUses}";

        move = _move;
    }

    public void UpdateUses()
    {
        moveUses.text = $"{move.uses} / {move.maxUses}";
    }

    public void Clique()
    {
        if (move == null || move.uses <= 0) return;

        if (battleSystem == null)
        {
            battleSystem = BattleSystem.Instance;

            if (battleSystem == null)
            {
                return;
            }
        }

        foreach (RuntimeMonsterMove _move in battleSystem.playerMonster.data.moves)
        {
            if (_move == move)
            {
                _move.uses--;

                UpdateUses();

                Debug.Log($"{battleSystem.playerMonster.data.species.speciesName} used {move.move.moveName}!");
            }
        }
    }
}
