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

    public void SetData(MonsterData _data)
    {
        healthSlider.maxValue = _data.maxHealth;
        healthSlider.value = _data.currentHealth;
        healthPercentage.text = $"{_data.currentHealth / _data.maxHealth * 100}%";

        monsterName.text = _data.species.speciesName;
        monsterLevel.text = $"L{_data.level}";
    }
}
