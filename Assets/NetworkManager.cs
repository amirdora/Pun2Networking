using System;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        Connect();
    }

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Play()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
       Debug.Log("Tried to join a room and failed");
       // most likely because there is no room
       PhotonNetwork.CreateRoom(null, new RoomOptions{MaxPlayers = 4});
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("joined a room");
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
