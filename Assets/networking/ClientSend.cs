
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour
{
    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    #region Packets
    // sending data to server , can use for sending other data like wtime used or score .
    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.myId); // client id or ip id

            SendTCPData(_packet);
        }
    }

    public static void resultSend(float time)
    {
        using (Packet _packet = new Packet((int)ClientPackets.result))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(time);

            SendTCPData(_packet);

        }
    }
    #endregion
}
