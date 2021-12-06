using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMonster : MonoBehaviour
{
    public int pid;
    [Range(1,100)] public int level = 1;
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
    [Header("Combat")]
    public DebugMonster target;

    private void Start()
    {
        if (ability == null)
        {
            ability = species.abilities[0];
        }
        
        RefreshStats();
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

    private void OnMouseDown()
    {
        int _damage = 0;
        target.currentHealth -= _damage;
    }
}
