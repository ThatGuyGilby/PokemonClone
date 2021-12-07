using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMonster : MonoBehaviour
{
    public DebugMonster target;
    public MonsterData data;

    private void Start()
    {
        Initialize();
    }


    public void Initialize()
    {
        //data = new MonsterData(data);
        data = new MonsterData(data.species, data.level);
    }

    private void OnMouseDown()
    {
        int _damage = 100;
        target.data.currentHealth -= _damage;
    }
}
