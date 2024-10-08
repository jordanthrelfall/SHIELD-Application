using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class ShieldControls : MonoBehaviour
{
    public ToggleGroup todToggleGroup;
    public ToggleGroup ldToggleGroup;
    public ToggleGroup pwrToggleGroup;
    public string tod;
    public string ld;
    private string pwr;

    // Start is called before the first frame update
    void Start()
    {
        ResetController();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ResetController()
    {
        todToggleGroup.gameObject.SetActive(true);
        ldToggleGroup.gameObject.SetActive(false);
        pwrToggleGroup.gameObject.SetActive(false);
    }

    public void updateTod()
    {
        Toggle todActiveToggle = todToggleGroup.ActiveToggles().FirstOrDefault();
        tod = todActiveToggle.name;
        todToggleGroup.gameObject.SetActive(false);
        ldToggleGroup.gameObject.SetActive(true);
        pwrToggleGroup.gameObject.SetActive(false);
    }

    public void updateLd()
    {
        Toggle ldActiveToggle = ldToggleGroup.ActiveToggles().FirstOrDefault();
        ld = ldActiveToggle.name;
        todToggleGroup.gameObject.SetActive(false);
        ldToggleGroup.gameObject.SetActive(false);
        pwrToggleGroup.gameObject.SetActive(true);

        Debug.Log("let's see!");
        if ((tod == "Day") && (ld == "DC"))
        {
            GameObject child = pwrToggleGroup.transform.Find("DayDC").gameObject;
            child.SetActive(true);
        }
        else if ((tod == "Day") && (ld == "AC"))
        {
            GameObject child = pwrToggleGroup.transform.Find("DayAC").gameObject;
            child.SetActive(true);
        }
        else if ((tod == "Day") && (ld == "AC/DC"))
        {
            GameObject child = pwrToggleGroup.transform.Find("DayDCAC").gameObject;
            child.SetActive(true);
        }
        if ((tod == "Night") && (ld == "DC"))
        {
            GameObject child = pwrToggleGroup.transform.Find("NightDC").gameObject;
            child.SetActive(true);
        }
        else if ((tod == "Night") && (ld == "AC"))
        {
            GameObject child = pwrToggleGroup.transform.Find("NightAC").gameObject;
            child.SetActive(true);
        }
        else if ((tod == "Night") && (ld == "AC/DC"))
        {
            GameObject child = pwrToggleGroup.transform.Find("NightDCAC").gameObject;
            child.SetActive(true);
        }
    }
}
