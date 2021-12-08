using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterParty
{
    public MonsterData[] members;

    public MonsterParty()
    {
        members = new MonsterData[6];

        for (int i = 0; i < members.Length; i++)
        {
            members[i] = new MonsterData();
        }
    }

    public MonsterParty(MonsterData _data)
    {
        members = new MonsterData[6];

        for (int i = 0; i < members.Length; i++)
        {
            members[i] = new MonsterData();
        }

        members[0] = _data;
    }

    public MonsterParty(MonsterData[] _data)
    {
        members = new MonsterData[6];

        for (int i = 0; i < members.Length; i++)
        {
            members[i] = new MonsterData();
        }

        for (int i = 0; i < Mathf.Min(members.Length, _data.Length); i++)
        {
            members[i] = _data[i];
        }
    }
}
