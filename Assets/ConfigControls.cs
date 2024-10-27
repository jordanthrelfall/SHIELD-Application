using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigControls : MonoBehaviour
{
    public GameObject controls;
    public GameObject config;
    
    public void ShowConfigButton()
    {
        controls.SetActive(false);
        config.SetActive(true);
    }

    public void ShowControls()
    {
        config.SetActive(false);
        controls.SetActive(true);
    }
}
