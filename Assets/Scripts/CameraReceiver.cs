using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class CameraReceiver : MonoBehaviour
{
    [Range(0, 1)] public float normalizedY; // 0..1 (0=atas,1=bawah)
    public int cameraHeight = 480; // sesuaikan bila    perlu
    public int port = 5052; // harus sama dgn    Python
    UdpClient client;
    Thread thread;

    volatile float rawY = 240f;
    void Start()
    {
        client = new UdpClient(port);
        thread = new Thread(Listen);
        thread.IsBackground = true;
        thread.Start();
    }
    void Listen()
    {
        IPEndPoint ep = new IPEndPoint(IPAddress.Any, port);
        while (true)
        {
            try
            {
                var data = client.Receive(ref ep);
                rawY = System.BitConverter.ToSingle(data, 0);
            }
            catch { }
        }
    }
    void Update()
    {
        // normalisasi dan balik (tangan naik → nilai kecil)
        normalizedY = Mathf.Clamp01(rawY / Mathf.Max(1,
        cameraHeight));
    }
    void OnApplicationQuit()
    {
        if (thread != null) thread.Abort();
        if (client != null) client.Close();
    }
}