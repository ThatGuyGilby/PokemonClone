using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public static BattleSystem Instance;

    public GameObject battleMonsterPrefab;
    public MoveButtonUI[] moveButtons;

    public BattleMonster playerMonster;
    public BattleMonster enemyMonster;

    public BattleGUI playerMonsterGUI;
    public BattleGUI enemyMonsterGUI;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning($"{gameObject.name} destroyed as there is already an instance assigned.");
            Destroy(gameObject);
        }

        Instance = this;
    }

    private void Start()
    {
        StartBattle();
    }

    public void StartBattle()
    {
        //  spawn player GO
        GameObject _yourMonsterGO = Instantiate(battleMonsterPrefab, playerBattleStation);
        playerMonster = _yourMonsterGO.GetComponent<BattleMonster>();
        playerMonster.SetData(GameManager.Instance.monster, GameManager.Instance.monster.species.backSprite);
        playerMonsterGUI.SetData(GameManager.Instance.monster);

        //  spawn enemy GO
        GameObject _enemyMonsterGO = Instantiate(battleMonsterPrefab, enemyBattleStation);
        enemyMonster = _enemyMonsterGO.GetComponent<BattleMonster>();

        MonsterData _enemyMonsterData = new MonsterData(GameManager.Instance.monster.species, 5);
        enemyMonster.SetData(_enemyMonsterData, _enemyMonsterData.species.frontSprite);
        enemyMonsterGUI.SetData(_enemyMonsterData);

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
}
