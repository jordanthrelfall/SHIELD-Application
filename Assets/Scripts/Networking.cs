using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;
using TMPro;

public class Networking : MonoBehaviour
{
    public TMP_Text solar;
    public TMP_Text solar_voltage;
    public TMP_Text solar_current;
    public TMP_Text inverter_power;
    public TMP_Text inverter_voltage;
    public TMP_Text inverter_current;
    public TMP_Text battery;
    public TMP_Text battery_voltage;
    public TMP_Text battery_current;
    public TMP_Text grid_power;
    public TMP_Text grid_voltage;
    public TMP_Text grid_current;
    public TMP_Text ac_load;
    public TMP_Text inverter_power_factor;
    public TMP_Text grid_power_factor;

    UdpClient udpClient;
    private Thread receiveThread;
    public string host = "172.20.10.6"; // IP address of the receiver
    public int port = 1234; // Port number on which to send data
    public string text = "hello";
    public RaspPiData rasp;

    void Start()
    {
        udpClient = new UdpClient();
        solar.text = rasp.solar.ToString();
        solar_voltage.text = rasp.solar_voltage.ToString();
        solar_current.text = rasp.solar_current.ToString();
        inverter_power.text = rasp.inverter_power.ToString();
        inverter_voltage.text = rasp.inverter_voltage.ToString();
        inverter_current.text = rasp.inverter_current.ToString();
        battery.text = rasp.battery.ToString();
        battery_voltage.text = rasp.battery_voltage.ToString();
        battery_current.text = rasp.battery_current.ToString();
        grid_power.text = rasp.grid_power.ToString();
        grid_voltage.text = rasp.grid_voltage.ToString();
        grid_current.text = rasp.grid_current.ToString();
        ac_load.text = rasp.ac_load.ToString();
        inverter_power_factor.text = rasp.inverter_power_factor.ToString();
        grid_power_factor.text = rasp.grid_power_factor.ToString();
        StartReceiving();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SendData(text);
        }

        solar.text = rasp.solar.ToString();
        solar_voltage.text = rasp.solar_voltage.ToString();
        solar_current.text = rasp.solar_current.ToString();
        inverter_power.text = rasp.inverter_power.ToString();
        inverter_voltage.text = rasp.inverter_voltage.ToString();
        inverter_current.text = rasp.inverter_current.ToString();
        battery.text = rasp.battery.ToString();
        battery_voltage.text = rasp.battery_voltage.ToString();
        battery_current.text = rasp.battery_current.ToString();
        grid_power.text = rasp.grid_power.ToString();
        grid_voltage.text = rasp.grid_voltage.ToString();
        grid_current.text = rasp.grid_current.ToString();
        ac_load.text = rasp.ac_load.ToString();
        inverter_power_factor.text = rasp.inverter_power_factor.ToString();
        grid_power_factor.text = rasp.grid_power_factor.ToString();
    }

    private void StartReceiving()
    {
        udpClient = new UdpClient(port);  // Bind the client to the specific port
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    private void ReceiveData()
    {
        while (true)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, port);
                byte[] data = udpClient.Receive(ref anyIP);
                string jsonData = Encoding.ASCII.GetString(data); // Convert byte data to string
                Debug.Log("Received JSON Data: " + jsonData);

                // Parse JSON string to RaspPiData object
                RaspPiData receivedData = JsonUtility.FromJson<RaspPiData>(jsonData);
                Debug.Log("Parsed Data: " + receivedData.dc_load.ToString()); // Debug output to check if parsing worked

                // Update UI on the main thread
                rasp.solar = Convert.ToDouble(receivedData.solar).ToString("N" + 2);
                rasp.solar_voltage = Convert.ToDouble(receivedData.solar_voltage).ToString("N" + 2);
                rasp.solar_current = Convert.ToDouble(receivedData.solar_current).ToString("N" + 2);
                rasp.inverter_power = Convert.ToDouble(receivedData.inverter_power).ToString("N" + 2);
                rasp.inverter_voltage = Convert.ToDouble(receivedData.inverter_voltage).ToString("N" + 2);
                rasp.inverter_current = Convert.ToDouble(receivedData.inverter_current).ToString("N" + 2);
                rasp.battery = Convert.ToDouble(receivedData.battery).ToString("N" + 2);
                rasp.battery_voltage = Convert.ToDouble(receivedData.battery_voltage).ToString("N" + 2);
                rasp.battery_current = Convert.ToDouble(receivedData.battery_current).ToString("N" + 2);
                rasp.grid_power = Convert.ToDouble(receivedData.grid_power).ToString("N" + 2);
                rasp.grid_voltage = Convert.ToDouble(receivedData.grid_voltage).ToString("N" + 2);
                rasp.grid_current = Convert.ToDouble(receivedData.grid_current).ToString("N" + 2);
                rasp.dc_load = Convert.ToDouble(receivedData.dc_load).ToString("N" + 2);
                rasp.ac_load = Convert.ToDouble(receivedData.ac_load).ToString("N" + 2);
                rasp.inverter_power_factor = Convert.ToDouble(receivedData.inverter_power_factor).ToString("N" + 2);
                rasp.grid_power_factor = Convert.ToDouble(receivedData.grid_power_factor).ToString("N" + 2);
                rasp.cyberattack = receivedData.cyberattack;
                rasp.solar_relay_state = receivedData.solar_relay_state;
                rasp.battery_to_inv_relay_state = receivedData.battery_to_inv_relay_state;
                rasp.grid_relay_state = receivedData.grid_relay_state;
                rasp.dc_load_relay_state = receivedData.dc_load_relay_state;
                rasp.inverter_to_ac_load_relay_state = receivedData.inverter_to_ac_load_relay_state;

                // Assign the received data to the rasp variable
                //rasp = receivedData;
            }
            catch (Exception e)
            {
                Debug.LogError("Exception in ReceiveData: " + e.ToString());
            }
        }
    }

    public void SendData(string message)
    {
        try
        {
            byte[] bytesToSend = Encoding.ASCII.GetBytes(message);
            udpClient.Send(bytesToSend, bytesToSend.Length, host, port);
            Debug.Log("Data sent: " + message);
        }
        catch (Exception e)
        {
            Debug.LogError("Exception: " + e.ToString());
        }
    }

    private void OnDestroy()
    {
        receiveThread?.Abort();
        if (udpClient != null)
        {
            udpClient.Close();
        }
    }
}


