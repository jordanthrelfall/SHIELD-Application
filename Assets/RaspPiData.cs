using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;

[Serializable]
public class RaspPiData
{
    public string solar;
    public string solar_voltage;
    public string solar_current;
    public string inverter_power;
    public string inverter_voltage;
    public string inverter_current;
    public string battery;
    public string battery_voltage;
    public string battery_current;
    public string grid_power;
    public string grid_voltage;
    public string grid_current;
    public string dc_load;
    public string ac_load;
    public string inverter_power_factor;
    public string grid_power_factor;
    public string cyberattack;

    public string solar_relay_state;
    public string battery_to_inv_relay_state;
    public string grid_relay_state;
    public string dc_load_relay_state;
    public string inverter_to_ac_load_relay_state;
}
