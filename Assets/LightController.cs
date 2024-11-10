using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject dc_light;
    public GameObject ac_batterylight;
    public GameObject ac_gridlight;
    public MessageHandler load;


    // Update is called once per frame
    public void UpdateLights()
    {
        if (load.load == "AC")
        {
            if (load.powerSource == "PV / Battery / Inverter"
                || load.powerSource == "Battery / Inverter")
            {
                ac_batterylight.SetActive(true);
                ac_gridlight.SetActive(false);

            }
            else
            {
                ac_gridlight.SetActive(true);
                ac_batterylight.SetActive(false);
            }

            dc_light.SetActive(false);
        }
        else if (load.load == "DC")
        {
            ac_batterylight.SetActive(false);
            ac_gridlight.SetActive(false);
            dc_light.SetActive(true);
        }
        else
        {

            if (load.powerSource == "PV / Battery / Inverter"
                || load.powerSource == "Battery / Inverter")
            {
                ac_batterylight.SetActive(true);
                ac_gridlight.SetActive(false);

            }
            else
            {
                ac_gridlight.SetActive(true);
                ac_batterylight.SetActive(false);
            }
            dc_light.SetActive(true);
        }
    }
}
