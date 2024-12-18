using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EMSHandler : MonoBehaviour
{
    public Networking networking;
    public EnergyFlow energyFlow;
    public LightController lights;
    public Slider slider;
    private int update = 0;

    // Update is called once per frame
    void Update()
    {
        if (slider.value == 0)
        {
            if (update == 0)
            {
                energyFlow.pvToBattery.SetActive(false);
                energyFlow.batteryToInverter.SetActive(false);
                energyFlow.gridToHouse.SetActive(false);
                energyFlow.lamp_inverter.SetActive(false);
                energyFlow.lamp_grid.SetActive(false);
                energyFlow.batteryToDC.SetActive(false);
                update = 1;
            }

            if (networking.rasp.solar_relay_state == "ON")
            {
                energyFlow.pvToBattery.SetActive(true);
            }
            else
            {
                energyFlow.pvToBattery.SetActive(false);
            }

            if (networking.rasp.battery_to_inv_relay_state == "ON")
            {
                energyFlow.batteryToInverter.SetActive(true);
                lights.ac_batterylight.SetActive(true);
                energyFlow.lamp_inverter.SetActive(true);
                energyFlow.lamp_grid.SetActive(false);
                lights.ac_gridlight.SetActive(false);
            }
            else
            {
                energyFlow.batteryToInverter.SetActive(false);
                lights.ac_batterylight.SetActive(false);
            }

            if (networking.rasp.grid_relay_state == "ON")
            {
                energyFlow.gridToHouse.SetActive(true);
                energyFlow.lamp_grid.SetActive(true);
                lights.ac_gridlight.SetActive(true);
                energyFlow.lamp_inverter.SetActive(false);
                lights.ac_batterylight.SetActive(false);
            }
            else
            {
                energyFlow.gridToHouse.SetActive(false); 
                energyFlow.lamp_grid.SetActive(false);
                lights.ac_gridlight.SetActive(false);
            }

            if (networking.rasp.dc_load_relay_state == "ON")
            {
                energyFlow.batteryToDC.SetActive(true);
                lights.dc_light.SetActive(true);
            }
            else
            {
                energyFlow.batteryToDC.SetActive(false);
                lights.dc_light.SetActive(false);
            }

            if (networking.rasp.inverter_to_ac_load_relay_state == "ON")
            {
                energyFlow.lamp_inverter.SetActive(true);
            }
            else
            {
                energyFlow.lamp_inverter.SetActive(false);
            }

        }
        else
        {
            update = 0;
        }
    }
}
