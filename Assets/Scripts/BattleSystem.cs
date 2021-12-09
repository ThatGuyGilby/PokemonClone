using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    #region Singleton
    public static BattleSystem Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning($"{gameObject.name} destroyed as there is already an instance assigned.");
            Destroy(gameObject);
        }

        Instance = this;
    }
    #endregion Singleton

    public GameObject battleMonsterPrefab;
    public MoveButtonUI[] moveButtons;

    public BattleMonster playerMonster;
    public BattleMonster enemyMonster;

    public BattleGUI playerMonsterGUI;
    public BattleGUI enemyMonsterGUI;

    public PartyDisplayGUI playerPartyGUI;
    public PartyDisplayGUI enemyPartyGUI;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    MonsterParty enemyParty;

    private void Start()
    {
        StartBattle();
    }

    public void StartBattle()
    {
        //  spawn player GO
        GameObject _yourMonsterGO = Instantiate(battleMonsterPrefab, playerBattleStation);
        playerMonster = _yourMonsterGO.GetComponent<BattleMonster>();
        playerMonster.SetData(GameManager.Instance.party.members[0], GameManager.Instance.party.members[0].species.backSprite);
        playerMonsterGUI.SetData(GameManager.Instance.party.members[0]);
        playerPartyGUI.SetParty(GameManager.Instance.party);

        //  spawn enemy GO
        GameObject _enemyMonsterGO = Instantiate(battleMonsterPrefab, enemyBattleStation);
        enemyMonster = _enemyMonsterGO.GetComponent<BattleMonster>();
        
        MonsterData _enemyMonsterData = new MonsterData(GameManager.Instance.party.members[0].species, 100);
        MonsterParty enemyParty = new MonsterParty(_enemyMonsterData);
        enemyMonster.SetData(_enemyMonsterData, _enemyMonsterData.species.frontSprite);
        enemyMonsterGUI.SetData(_enemyMonsterData);
        enemyPartyGUI.SetParty(enemyParty);

        if (playerMonster == null) return;

        for (int i = 0; i < moveButtons.Length; i++)
        {
            if (playerMonster.data.moves[i] != null)
            {
                moveButtons[i].gameObject.SetActive(true);
                moveButtons[i].SetMove(playerMonster.data.moves[i]);
            }
            else
            {
                moveButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void SetPlayerMove(RuntimeMonsterMove _move)
    {
        _move.uses--;

        switch(UseMove(_move.move, playerMonster.data, enemyMonster.data))
        {
            case 0:
                break;
            case 1:
                bool _hasMoreMonsters = false;

                //for (int i = 0; i < enemyParty.members.Length; i++)
                //{
                //    if (enemyParty.members[i].validForBattle)
                //    {
                //        _hasMoreMonsters = true;
                //    }
                //}

                if (_hasMoreMonsters)
                {
                    // switch here
                }
                else
                {
                    GameManager.Instance.EndBattle();
                }

                break;
        }

        UseMove(enemyMonster.data.moves[0].move, enemyMonster.data, playerMonster.data);

        foreach (MoveButtonUI _button in moveButtons)
        {
            _button.UpdateUses();
        }
    }

    public int UseMove(MonsterMove _move, MonsterData _user, MonsterData _target)
    {
        int _output = 0;
        float _accuracyCheck = Random.Range(0, 100);

        if (_accuracyCheck < _move.accuracy)
        {
            // if there is an attack power deal damage
            if (_move.attackPower != 0)
            {
                float _damage = CalculateDamage(_move, _user, _target);

                _target.currentHealth -= Mathf.RoundToInt(_damage);

                if (_target.currentHealth <= 0)
                {
                    _output = 1;
                }
            }

            // if  there is a flat heal percentage heal the user
            if (_move.flatHealPercentage != 0)
            {
                _user.currentHealth = Mathf.RoundToInt(Mathf.Min((float)_user.currentHealth + ((float)_user.maxHealth * (_move.flatHealPercentage / 100f)), _user.maxHealth));
            }
        }
        else
        {
            Debug.Log("Missed...");
        }

        UpdateGUI();

        // returns 1 if the unit was killed
        return _output;
    }

    private void UpdateGUI()
    {
        enemyMonsterGUI.UpdateHealth();
        playerMonsterGUI.UpdateHealth();
    }

    public float CalculateDamage(MonsterMove _move, MonsterData _attacker, MonsterData _defender)
    {
        float _level = _attacker.level; // the level of the attacking monster

        float _attackStat = 0; // the attack or special attack stat of the attacking monster
        float _defenceStat = 0; // the defence or special defence stat of the defending monster
        switch (_move.moveUseType)
        {
            case MoveUseType.Physical:
                _attackStat = _attacker.currentAttack;
                _defenceStat = _defender.currentDefence;
                break;
            case MoveUseType.Special:
                _attackStat = _attacker.currentSpecialAttack;
                _defenceStat = _defender.currentSpecialDefence;
                break;
        }

        float _attackPower = _move.attackPower; // the power of the move used

        float _stab = 1.0f; // the same type attack bonus of the attacking monster
        if (_attacker.species.types.Contains(_move.moveType))
        {
            _stab = 1.5f;
        }

        float _effectiveness = _defender.GetEffectiveness(_move.moveType);

        switch(_effectiveness)
        {
            case 4f:
                Debug.Log("Super Duper Effective");
                break;
            case 2f:
                Debug.Log("Super Effective");
                break;
            case 0.5f:
                Debug.Log("Not Very Effective");
                break;
            case 0.25f:
                Debug.Log("Really Not Very Effective");
                break;
            case 0:
                Debug.Log("That did nothing at all");
                break;
        }

        float _critical = 1.0f;

        float _randomness = Random.Range(0.85f, 1.0f);

        float _damage = ((((2f * _level / 5f + 2f) * _attackStat * _attackPower / _defenceStat) / 50f) + 2f) * _stab * _critical * _effectiveness * _randomness;

        return _damage;
    }
}
