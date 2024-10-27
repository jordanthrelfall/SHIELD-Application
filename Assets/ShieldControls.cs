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
    public Slider slider;
    public Button button;
    public Button ldButton;
    public string tod;
    public string ld;
    public MessageHandler message;
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
        button.gameObject.SetActive(false);
        ldButton.gameObject.SetActive(false);
    }

    public void updateTod()
    {
        Toggle todActiveToggle = todToggleGroup.ActiveToggles().FirstOrDefault();
        tod = todActiveToggle.name;
        if (slider.value == 1)
        {         
            todToggleGroup.gameObject.SetActive(false);
            ldToggleGroup.gameObject.SetActive(true);
            pwrToggleGroup.gameObject.SetActive(false);
            ldButton.gameObject.SetActive(true);
        }
        else
        {
            todToggleGroup.gameObject.SetActive(false);
            ldToggleGroup.gameObject.SetActive(true);
            pwrToggleGroup.gameObject.SetActive(false);
            button.gameObject.SetActive(true);
            ldButton.gameObject.SetActive(false);
        }
        message.timeOfDay = tod;
    }

    public void updateLd()
    {
        Toggle ldActiveToggle = ldToggleGroup.ActiveToggles().FirstOrDefault();
        ld = ldActiveToggle.name;
        todToggleGroup.gameObject.SetActive(false);
        ldToggleGroup.gameObject.SetActive(false);
        pwrToggleGroup.gameObject.SetActive(true);
        ldButton.gameObject.SetActive(false);
        button.gameObject.SetActive(true);
        message.load = ld;
        Debug.Log("let's see!");
        if ((tod == "Day") && (ld == "DC"))
        {
            GameObject child = pwrToggleGroup.transform.Find("DayDC").gameObject;
            child.SetActive(true);
            child = pwrToggleGroup.transform.Find("DayAC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("DayDCAC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("NightDC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("NightAC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("NightDCAC").gameObject;
            child.SetActive(false);
        }
        else if ((tod == "Day") && (ld == "AC"))
        {
            GameObject child = pwrToggleGroup.transform.Find("DayAC").gameObject;
            child.SetActive(true);
            child = pwrToggleGroup.transform.Find("DayDC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("DayDCAC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("NightDC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("NightAC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("NightDCAC").gameObject;
            child.SetActive(false);
        }
        else if ((tod == "Day") && (ld == "AC/DC"))
        {
            GameObject child = pwrToggleGroup.transform.Find("DayDCAC").gameObject;
            child.SetActive(true);
            child = pwrToggleGroup.transform.Find("DayDC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("DayAC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("NightDC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("NightAC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("NightDCAC").gameObject;
            child.SetActive(false);
        }
        if ((tod == "Night") && (ld == "DC"))
        {
            GameObject child = pwrToggleGroup.transform.Find("NightDC").gameObject;
            child.SetActive(true);
            child = pwrToggleGroup.transform.Find("DayDC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("DayAC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("DayDCAC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("NightAC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("NightDCAC").gameObject;
            child.SetActive(false);
        }
        else if ((tod == "Night") && (ld == "AC"))
        {
            GameObject child = pwrToggleGroup.transform.Find("NightAC").gameObject;
            child.SetActive(true);
            child = pwrToggleGroup.transform.Find("DayDC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("DayAC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("DayDCAC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("NightDC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("NightDCAC").gameObject;
            child.SetActive(false);
        }
        else if ((tod == "Night") && (ld == "AC/DC"))
        {
            GameObject child = pwrToggleGroup.transform.Find("NightDCAC").gameObject;
            child.SetActive(true);
            child = pwrToggleGroup.transform.Find("DayDC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("DayAC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("DayDCAC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("NightDC").gameObject;
            child.SetActive(false);
            child = pwrToggleGroup.transform.Find("NightAC").gameObject;
            child.SetActive(false);

        }
    }
}
