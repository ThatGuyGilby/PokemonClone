using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderGradiant : MonoBehaviour
{
    public List<SliderGradiantChange> changes;
    public Image fillImage;

    Slider slider;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
    }

    public void OnSliderChanged()
    {
        float _percentage = slider.value / slider.maxValue * 100;

        for (int i = 0; i < changes.Count; i++)
        {
            if (_percentage < changes[i].percentage)
            {
                fillImage.color = changes[i].color;
            }
        }
    }
}

[System.Serializable]
public class SliderGradiantChange
{
    public float percentage;
    public Color color;
}