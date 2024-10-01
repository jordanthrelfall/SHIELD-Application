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
    public TMP_Text dc_load;
    public TMP_Text ac_load;
    public TMP_Text battery;

    private UdpClient udpClient;
    private Thread receiveThread;
    public string host = "10.37.29.168"; // IP address of the receiver
    public int port = 1234; // Port number on which to send data
    public string text = "hello";
    public RaspPiData rasp;

    void Start()
    {
        udpClient = new UdpClient();
        solar.text = rasp.solar.ToString();
        dc_load.text = rasp.dc_load.ToString();
        ac_load.text = rasp.ac_load.ToString();
        battery.text = rasp.battery.ToString();
        StartReceiving();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SendData(text);
        }

        solar.text = rasp.solar.ToString();
        dc_load.text = rasp.dc_load.ToString();
        ac_load.text = rasp.ac_load.ToString();
        battery.text = rasp.battery.ToString();
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
                rasp.dc_load = receivedData.dc_load;
                rasp.ac_load = receivedData.ac_load;
                rasp.battery = receivedData.battery;

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


