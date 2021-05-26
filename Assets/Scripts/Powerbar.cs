using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerbar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxPower(int Power)
    {
        slider.maxValue = Power;
        slider.value = Power;
    }

    public void SetPower(int Power)
    {
        slider.value = Power;
    }
}
