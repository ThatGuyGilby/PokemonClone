using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterData
{
    [Header("Monster Data")]
    public bool validForBattle;
    public int pid;
    [Range(1, 100)] public int level = 1;
    public MonsterSpecies species;
    public string item;
    public MonsterAbility ability;
    [Space(5)]
    [Header("Stats")]
    public Stat health;
    public Stat attack;
    public Stat defence;
    public Stat specialAttack;
    public Stat specialDefence;
    public Stat speed;
    [Space(5)]
    [Header("Runtime Stats")]
    public int maxHealth;
    public int currentHealth;
    public int currentAttack;
    public int currentDefence;
    public int currentSpecialAttack;
    public int currentSpecialDefence;
    public int currentSpeed;
    [Space(5)]
    [Header("Moves")]
    public RuntimeMonsterMove[] moves;

    public MonsterData(MonsterSpecies _species, int _level)
    {
        validForBattle = true;
        pid = UnityEngine.Random.Range(int.MinValue, int.MaxValue);

        var _previousState = UnityEngine.Random.state;
        UnityEngine.Random.InitState(pid);

        species = _species;
        level = _level;

        if (ability == null)
        {
            ability = species.abilities[UnityEngine.Random.Range(0, species.abilities.Count)];
        }

        health = new Stat(UnityEngine.Random.Range(0,31));
        attack = new Stat(UnityEngine.Random.Range(0, 31));
        defence = new Stat(UnityEngine.Random.Range(0, 31));
        specialAttack = new Stat(UnityEngine.Random.Range(0, 31));
        specialDefence = new Stat(UnityEngine.Random.Range(0, 31));
        speed = new Stat(UnityEngine.Random.Range(0, 31));

        UnityEngine.Random.state = _previousState;

        PopulateMoves();

        RefreshStats();
        Heal();
    }

    public MonsterData(MonsterData _data)
    {
        validForBattle = true;
        pid = _data.pid;

        species = _data.species;
        level = _data.level;

        if (ability == null)
        {
            ability = _data.ability;
        }

        health = new Stat(_data.health);
        attack = new Stat(_data.attack);
        defence = new Stat(_data.defence);
        specialAttack = new Stat(_data.specialAttack);
        specialDefence = new Stat(_data.specialDefence);
        speed = new Stat(_data.speed);

        PopulateMoves();

        RefreshStats();
        Heal();
    }

    public MonsterData()
    {
        validForBattle = false;
    }

    public void Heal()
    {
        currentHealth = maxHealth;
    }

    public void RefreshStats()
    {
        maxHealth = health.GetValue(species.health, level, 10 + level);

        currentAttack = attack.GetValue(species.attack, level);
        currentDefence = defence.GetValue(species.defence, level);
        currentSpecialAttack = specialAttack.GetValue(species.specialAttack, level);
        currentSpecialDefence = specialDefence.GetValue(species.specialDefence, level);
        currentSpeed = speed.GetValue(species.speed, level);
    }

    public void Initialize()
    {
        pid = UnityEngine.Random.Range(int.MinValue, int.MaxValue);

        var _previousState = UnityEngine.Random.state;
        UnityEngine.Random.InitState(pid);

        if (ability == null)
        {
            ability = species.abilities[UnityEngine.Random.Range(0, species.abilities.Count)];
        }

        health = new Stat(UnityEngine.Random.Range(0, 31));
        attack = new Stat(UnityEngine.Random.Range(0, 31));
        defence = new Stat(UnityEngine.Random.Range(0, 31));
        specialAttack = new Stat(UnityEngine.Random.Range(0, 31));
        specialDefence = new Stat(UnityEngine.Random.Range(0, 31));
        speed = new Stat(UnityEngine.Random.Range(0, 31));

        UnityEngine.Random.state = _previousState;

        RefreshStats();
        Heal();
    }

    public bool TakeDamage(int _damage)
    {
        currentHealth -= _damage;

        if (currentHealth <= 0)
        {
            validForBattle = false;
        }

        return false;
    }

    private void PopulateMoves()
    {
        moves = new RuntimeMonsterMove[4];

        for (int i = 0; i < species.moves.Count; i++)
        {
            if (i < 4)
            {
                moves[i] = new RuntimeMonsterMove(species.moves[i]);
            }
        }
    }

    public float GetEffectiveness(MonsterType _typeToCheck)
    {
        float _multiplier = 1.0f;

        foreach (MonsterType _type in species.types)
        {
            foreach (MonsterType _typee in _type.weaknesses)
            {
                if (_typee == _typeToCheck) _multiplier *= 2f;
            }

            foreach (MonsterType _typee in _type.resistances)
            {
                if (_typee == _typeToCheck) _multiplier *= 0.5f;
            }
        }

        foreach (MonsterType _type in species.types)
        {
            foreach (MonsterType _typee in _type.immunities)
            {
                if (_typee == _typeToCheck) _multiplier *= 0;
            }
        }

        return _multiplier;
    }
}

public class SerializedMonsterData
{

}