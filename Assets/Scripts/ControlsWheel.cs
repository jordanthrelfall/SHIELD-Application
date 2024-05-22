using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsWheel : MonoBehaviour
{
    public GameObject controls;

    // Update is called once per frame
    public void OnButtonClick()
    {
        if (controls.activeSelf)
        {
            controls.SetActive(false);
        }
        else
        {
            controls.SetActive(true);
        }
    }
}
