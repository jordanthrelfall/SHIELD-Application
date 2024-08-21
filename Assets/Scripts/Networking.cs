using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;

public class Networking : MonoBehaviour
{
    private UdpClient udpClient;
    private Thread receiveThread;
    public string host = "192.168.1.50"; // IP address of the receiver
    public int port = 1234; // Port number on which to send data
    public string text = "hello";

    void Start()
    {
        udpClient = new UdpClient();
        StartReceiving();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Press space to send a message
        {
            SendData("Hello, UDP!");
        }
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
            IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, port);
            byte[] data = udpClient.Receive(ref anyIP);
            text = Encoding.ASCII.GetString(data);
            Debug.Log("Received: " + text);
        }
    }
    private void SendData(string message)
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
