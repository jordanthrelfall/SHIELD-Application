using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyFlow : MonoBehaviour
{
    public GameObject pvToBattery;
    public GameObject batteryToInverter;
    public GameObject gridToHouse;
    public GameObject lamp;

    public MessageHandler message;

    // Update is called once per frame
    public void UpdateEnergyFlow()
    {
        switch (message.powerSource)
        {
            case "PV / Battery":
                pvToBattery.SetActive(true);
                batteryToInverter.SetActive(false);
                gridToHouse.SetActive(false);
                break;
            case "PV / Battery / Inverter":
                pvToBattery.SetActive(true);
                batteryToInverter.SetActive(true);
                gridToHouse.SetActive(false);
                break;
            case "PV / Battery / Grid":
                pvToBattery.SetActive(true);
                gridToHouse.SetActive(true);
                batteryToInverter.SetActive(false);
                break;
            case "Battery / Inverter":
                batteryToInverter.SetActive(true);
                pvToBattery.SetActive(false);
                gridToHouse.SetActive(false);
                break;
            case "Grid":
                gridToHouse.SetActive(true);
                pvToBattery.SetActive(false);
                batteryToInverter.SetActive(false);
                break;
            case "Battery / Grid":
                gridToHouse.SetActive(true);
                pvToBattery.SetActive(false);
                batteryToInverter.SetActive(false);
                break;
            default:
                break;
        }
        
        if (message.load == "DC")
        {
            lamp.SetActive(false);
        }
        else
        {
            lamp.SetActive(true);
        }
    }
}
