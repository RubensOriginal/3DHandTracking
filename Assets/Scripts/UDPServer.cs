using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class UDPServer : MonoBehaviour
{
    private Thread thread;
    private UdpClient client;
    public int port = 5052;
    public bool startRecieving = true;
    public bool printToConsole = false;
    public string Data { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        thread = new Thread(new ThreadStart(ReceiveData));
        thread.IsBackground = true;
        thread.Start();
    }

    private void ReceiveData()
    {
        client = new UdpClient(port);

        while (startRecieving)
        {
            try
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataByte = client.Receive(ref ip);
                Data = Encoding.UTF8.GetString(dataByte);
                
                if (printToConsole)
                    Debug.Log(Data);
            }
            catch (Exception e)
            {
                Debug.LogError(e.ToString());
                throw;
            }
        }
    }
}
