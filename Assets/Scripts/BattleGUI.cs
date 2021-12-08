using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleGUI : MonoBehaviour
{
    public Slider healthSlider;
    public TMP_Text healthPercentage;
    public TMP_Text monsterName;
    public TMP_Text monsterLevel;

    MonsterData data;

    public void SetData(MonsterData _data)
    {
        data = _data;
        UpdateHealth();

        monsterName.text = _data.species.speciesName;
        monsterLevel.text = $"L{_data.level}";
    }

    public void UpdateHealth()
    {
        healthSlider.maxValue = data.maxHealth;
        healthSlider.value = data.currentHealth;
        healthPercentage.text = $"{Mathf.RoundToInt((float)data.currentHealth / (float)data.maxHealth * 100f)}%";
    }
}
