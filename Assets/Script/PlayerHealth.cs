using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Progress;

public class PlayerHealth : MonoBehaviour
{
    public Image bar;
    public Gradient gradient;
    public Slider slider;

    public void MaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        bar.color = gradient.Evaluate(1f);
    }
    public void currentHealth(int health)
    {
        slider.value = health;
        bar.color = gradient.Evaluate(slider.normalizedValue);  
    }
}