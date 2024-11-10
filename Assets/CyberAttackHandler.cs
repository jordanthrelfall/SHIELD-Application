using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberAttackHandler : MonoBehaviour
{
    public GameObject cyberattack;
    public GameObject cyberlights;
    public GameObject configcontrols;
    public GameObject pressconfig;
    public GameObject ems;
    public UpdatePacket reset;
    public Networking networking;
    public bool active = false;
    public GameObject education;

    // Update is called once per frame
    void Update()
    {
        if (networking.rasp.cyberattack == "active")
        {
            reset.TurnOffSources();
            cyberattack.SetActive(true);
            cyberlights.SetActive(true);
            configcontrols.SetActive(false);
            pressconfig.SetActive(false);
            ems.SetActive(false);
            active = true;
        }
        else
        {
            if (active == true)
            {
                cyberattack.SetActive(false);
                education.SetActive(false);
                pressconfig.SetActive(true);
                cyberlights.SetActive(false);
                ems.SetActive(true);
                active = false;
            }      
        }
    }

    public void ResumeConfig()
    {
        networking.rasp.cyberattack = "inactive";
    }
}
