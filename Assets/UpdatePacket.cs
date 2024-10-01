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
    public ToggleGroup todToggleGroup;
    public ToggleGroup pwrToggleGroup;
    public ToggleGroup ldToggleGroup;
    public GameObject night;

    public void updatePacketAndSend()
    {
        Toggle todActiveToggle = todToggleGroup.ActiveToggles().FirstOrDefault();
        Toggle pwrActiveToggle = pwrToggleGroup.ActiveToggles().FirstOrDefault();
        Toggle ldActiveToggle = ldToggleGroup.ActiveToggles().FirstOrDefault();
        messageHandler.timeOfDay = todActiveToggle.name;
        messageHandler.powerSource = pwrActiveToggle.name;
        messageHandler.load = ldActiveToggle.name;

        if (todActiveToggle.name == "Day")
        {
            night.active = false;
        }
        else
        {
            night.active = true;
        }

        string json = JsonUtility.ToJson(messageHandler);

        networking.SendData(json);
    }
}
