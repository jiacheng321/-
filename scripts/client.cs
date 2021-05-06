using System.Collections;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;
public class client 
{
    static byte[] receivebuffer = new byte[1024];
    byte[] sendebuffer = new byte[1024];

    static Socket sthis, ssever;
    static IPAddress ipthis;//本地
    static IPAddress ipsever;
    static IPEndPoint ippoint = new IPEndPoint(ipthis, 1044);
    static IPEndPoint ippointromote = new IPEndPoint(ipsever, 1044);

    // Start is called before the first frame update
    void Start()
    {
        ssever=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        sthis = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        sthis.Connect(ippointromote);
        if (!sthis.Connected)
        {
            sthis = null;
        }   
    }
    public void senddata()
    {
        sthis.SendTo(sendebuffer, 0, sendebuffer.Length, SocketFlags.None, ippointromote);
    }
    public void  receivedata(ref byte[] receivebuffer)
    {
        ssever.Receive(receivebuffer, 0, ssever.Available, SocketFlags.None);
    }

    public void packdata()
    {

    }
    // Update is called once per frame

}
