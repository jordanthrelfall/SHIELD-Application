using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderChanger : MonoBehaviour
{
    public Slider slider;
    public void ToggleSliderValue()
    {
        Debug.Log("i am here");
        if (slider.value == 1)
        {
            slider.value = 0;
        }
        else
        {
            slider.value = 1;
        }
    }
}
