using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamevolume : MonoBehaviour
{
    public Slider slider;
    public static float volume;

    void Update()
    {
        AudioListener.volume = slider.value;
    }
}
