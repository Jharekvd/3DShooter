using UnityEngine;
using Photon.Pun;
//Importante añadir esta liberia
public class Launcher : MonoBehaviourPunCallbacks
{
    [Header("PlayerPrefab")]
    //ComponenteView del Player
    public PhotonView playerPrefab;
    //Referencia al punto de partida
    public Transform spawnPoint;

    void Start()
    {
        //Inicia lo necesario para el servidor
        PhotonNetwork.ConnectUsingSettings();
    
    }

    public override void OnConnectedToMaster()
    {
        //Aqui es cuando nos conectamos al master
        Debug.Log("Nos hemos conectado al master");
        //Este metodo crea una sala si no la va a crear y si no nos unimos a una
        PhotonNetwork.JoinRandomOrCreateRoom();
    }
    //Este metodo nos hace unir a la sala
    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(playerPrefab.name,spawnPoint.position,spawnPoint.rotation);
    }
    
            
}

