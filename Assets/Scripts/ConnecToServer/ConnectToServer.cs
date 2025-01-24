using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Connec : MonoBehaviourPunCallbacks
{
    void Start()
    {
        //Neceario para inciar el servidor
        PhotonNetwork.ConnectUsingSettings();        
    }
    

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
