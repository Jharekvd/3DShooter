using Photon.Pun;
using UnityEngine;
public class Spawn : MonoBehaviourPunCallbacks
{
    [Header("PlayerPrefab")]
    //ComponenteView del Player
    public PhotonView playerPrefab;
    //Referencia al punto de partida
    public Transform spawnPoint;
    void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);

    }

}
