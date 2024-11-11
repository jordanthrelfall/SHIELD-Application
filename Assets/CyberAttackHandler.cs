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
    public AudioSource audio;

    private int count;

    void Start()
    {
        count = 1000;
    }
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

            if (count == 60)
            {
                reset.cyberUpdatePacketAndSend();
                count = 0;
            }

            if (!audio.isPlaying)
            {
                audio.Play();
            }

            count++;   
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
                audio.Stop();
            }      
        }      
    }

    public void ResumeConfig()
    {
        networking.rasp.cyberattack = "inactive";
    }
}
