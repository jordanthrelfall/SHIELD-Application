using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;

[Serializable]
public class RaspPiData
{
    public float solar;
    public float dc_load;
    public float ac_load;
    public float battery;
    public string SolarRelay;
    public string BatteryToInvRelay;
    public string ToggleRelay;
    public string DCLoadRelay;
}
