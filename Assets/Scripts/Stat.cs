using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [Range(0, 31)] public int geneticValue;
    [Range(0, 65)] public int investedValue;

    public int GetValue(int _base, int _level, int _minimum = 5)
    {
        int _value = 0;
        float _nature = 1.0f;

        _value = (int)((Mathf.FloorToInt(0.01f * (2f * _base + geneticValue + investedValue) * _level) + (float)_minimum) * _nature);

        return _value;
    }
}