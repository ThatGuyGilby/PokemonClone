using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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

    public MonsterData monster;
    public GameObject[] disableInBattle;

    private void Start()
    {
        monster = new MonsterData(monster.species, monster.level);
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
        foreach (GameObject _object in disableInBattle)
        {
            _object.SetActive(true);
        }
    }
}
