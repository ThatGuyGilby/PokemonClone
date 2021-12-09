using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning($"{gameObject.name} destroyed as there is already an instance assigned.");
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion Singleton

    public MonsterData monster;
    public MonsterData[] monsters;
    public MonsterParty party;
    public GameObject[] disableInBattle;

    private void Start()
    {
        monster = new MonsterData(monster.species, monster.level);

        for (int i = 0; i < monsters.Length; i++)
        {
            monsters[i] = new MonsterData(monsters[i].species, monsters[i].level);
        }

        party = new MonsterParty(monsters);
    }

    public void StartBattle()
    {
        foreach (GameObject _object in disableInBattle)
        {
            _object.SetActive(false);
        }

        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    public void EndBattle()
    {
        SceneManager.UnloadSceneAsync(1);

        foreach (GameObject _object in disableInBattle)
        {
            _object.SetActive(true);
        }
    }
}
