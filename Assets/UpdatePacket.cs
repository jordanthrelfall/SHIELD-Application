using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;


public class UpdatePacket : MonoBehaviour
{
    public Networking networking;
    public MessageHandler messageHandler;
    public ShieldControls shieldControls;
    public ToggleGroup pwrToggleGroup;
    public ToggleGroup ldToggleGroup;
    public Slider slider;
    public LightController lights;
    public EnergyFlow energy;
    public GameObject energyflow;
    public GameObject lampsObject;
    string mode;

    public GameObject night;

    public void updatePacketAndSend()
    {
        Toggle pwrActiveToggle = pwrToggleGroup.ActiveToggles().FirstOrDefault();
        Toggle ldActiveToggle = ldToggleGroup.ActiveToggles().FirstOrDefault();
        messageHandler.timeOfDay = shieldControls.tod;

        if (pwrActiveToggle != null)
        {
            messageHandler.powerSource = pwrActiveToggle.name;
        }
        if (ldActiveToggle != null)
        {
            messageHandler.load = ldActiveToggle.name;
        }

        if (slider.value == 1)
        {
            mode = "manual";
        }
        else
        {
            mode = "automatic";
        }
        messageHandler.mode = mode;


        if (shieldControls.tod == "Day")
        {
            night.active = false;
        }
        else
        {
            night.active = true;
        }

        lights.UpdateLights();
        energy.UpdateEnergyFlow();

        string json = JsonUtility.ToJson(messageHandler);

        networking.SendData(json);

        shieldControls.ResetController();
    }
    public void sliderUpdatePacketAndSend()
    {
        messageHandler.timeOfDay = "";

        messageHandler.powerSource = "";

        messageHandler.load = "";

        if (slider.value == 1)
        {
            mode = "manual";
        }
        else
        {
            mode = "automatic";
        }
        messageHandler.mode = mode;
    }

    public void resetUpdatePacketAndSend()
    {
        messageHandler.timeOfDay = "";

        messageHandler.powerSource = "";

        messageHandler.load = "";

        messageHandler.mode = "";

        messageHandler.reset = "reset";

        string json = JsonUtility.ToJson(messageHandler);

        networking.SendData(json);

        messageHandler.reset = "";

        TurnOffSources();
    }

    public void TurnOffSources()
    {
        energyflow.SetActive(false);
        lampsObject.SetActive(false);
    }
    public void TurnOnSources()
    {
        energyflow.SetActive(true);
        lampsObject.SetActive(true);
    }
}
