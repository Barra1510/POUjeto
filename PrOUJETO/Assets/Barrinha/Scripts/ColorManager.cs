using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    [SerializeField] Gradient colorHealth;
    [SerializeField] Image[] fill;
    [SerializeField] Slider[] slider;
    [SerializeField] StatusManager status;

    void Update()
    {
        slider[0].value = status.health;
        slider[1].value = status.energy;
        slider[2].value = status.hunger;
        fill[0].color = colorHealth.Evaluate(slider[0].value);
        fill[1].color = colorHealth.Evaluate(slider[1].value);
        fill[2].color = colorHealth.Evaluate(slider[2].value);
    }
}
