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
    public TMP_Text dc_load;
    public TMP_Text ac_load;

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
        dc_load.text = rasp.dc_load.ToString();
        ac_load.text = rasp.ac_load.ToString();
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
        dc_load.text = rasp.dc_load.ToString();
        ac_load.text = rasp.ac_load.ToString();
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
                rasp.solar = receivedData.solar;
                rasp.solar_voltage = receivedData.solar_voltage;
                rasp.solar_current = receivedData.solar_current;
                rasp.inverter_power = receivedData.inverter_power;
                rasp.inverter_voltage = receivedData.inverter_voltage;
                rasp.inverter_current = receivedData.inverter_current;
                rasp.battery = receivedData.battery;
                rasp.battery_voltage = receivedData.battery_voltage;
                rasp.battery_current = receivedData.battery_current;
                rasp.grid_power = receivedData.grid_power;
                rasp.grid_voltage = receivedData.grid_voltage;
                rasp.grid_current = receivedData.grid_current;
                rasp.dc_load = receivedData.dc_load;
                rasp.ac_load = receivedData.ac_load;
                rasp.cyberattack = receivedData.cyberattack;

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


