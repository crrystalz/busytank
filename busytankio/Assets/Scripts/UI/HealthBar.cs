using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    
    public Slider slider;
    public Gradient Color;
    public Image fill;
    public void SetMaxHP(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = Color.Evaluate(1f);
    }
    public void SetHP(int health)
    {
        slider.value = health;

        fill.color = Color.Evaluate(slider.normalizedValue);
    }
}
