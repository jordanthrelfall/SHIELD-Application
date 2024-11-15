using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyFlow : MonoBehaviour
{
    public GameObject pvToBattery;
    public GameObject batteryToInverter;
    public GameObject gridToHouse;
    public GameObject batteryToDC;
    public GameObject lamp_inverter;
    public GameObject lamp_grid;

    public MessageHandler message;

    // Update is called once per frame
    public void UpdateEnergyFlow()
    {
        switch (message.powerSource)
        {
            case "PV / Battery":
                pvToBattery.SetActive(false);
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
            case "Battery":
                gridToHouse.SetActive(false);
                pvToBattery.SetActive(false);
                batteryToInverter.SetActive(false);
                break;
            default:
                gridToHouse.SetActive(false);
                pvToBattery.SetActive(false);
                batteryToInverter.SetActive(false);
                break;
        }
        
        if (message.load == "DC")
        {
            lamp_inverter.SetActive(false);
            lamp_grid.SetActive(false);
            batteryToDC.SetActive(true);
        }
        else if (message.load == "AC")
        {
            batteryToDC.SetActive(false);
            if (message.powerSource == "PV / Battery / Inverter"
                || message.powerSource == "Battery / Inverter")
            {
                lamp_inverter.SetActive(true);
                lamp_grid.SetActive(false);

            }
            else
            {
                lamp_grid.SetActive(true);
                lamp_inverter.SetActive(false);
            }
        }
        else
        {
            batteryToDC.SetActive(true);
            if (message.powerSource == "PV / Battery / Inverter"
                || message.powerSource == "Battery / Inverter")
            {
                lamp_inverter.SetActive(true);
                lamp_grid.SetActive(false);

            }
            else
            {
                lamp_grid.SetActive(true);
                lamp_inverter.SetActive(false);
            }
        }
    }
}
