using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMonster : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public MonsterData data;

    public void SetData(MonsterData _data, Sprite _sprite)
    {
        data = _data;
        spriteRenderer.sprite = _sprite;
    }
}
