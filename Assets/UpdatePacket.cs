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
    public Slider slider;
    string mode;

    public GameObject night;

    public void updatePacketAndSend()
    {
        Toggle pwrActiveToggle = pwrToggleGroup.ActiveToggles().FirstOrDefault();
        messageHandler.timeOfDay = shieldControls.tod;

        if (pwrActiveToggle != null)
            messageHandler.powerSource = pwrActiveToggle.name;
       
        messageHandler.load = shieldControls.ld;

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

        string json = JsonUtility.ToJson(messageHandler);

        networking.SendData(json);
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
    }
}
