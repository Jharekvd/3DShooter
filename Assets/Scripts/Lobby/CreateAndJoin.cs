using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
public class CreateAndJoin : MonoBehaviourPunCallbacks
{
    [Header("Creacion y Union")]
    private bool isConnecting = false;

    public void JoinOrCreateRoom()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            isConnecting = true;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        if (isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnJoinedRoom()
    {
        UnityEngine.Debug.Log("Joined room: " + PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LoadLevel("Principal");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        UnityEngine.Debug.Log("No random room available, creating a new room.");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4; // Ajusta esto según tus necesidades
        PhotonNetwork.CreateRoom(null, roomOptions, TypedLobby.Default);
    }

}
