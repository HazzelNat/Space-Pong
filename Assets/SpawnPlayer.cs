using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject[] playerPrefab;
    public GameObject ballPrefab;
    Vector2 playerPosition;
    
    private void Start() 
    {
        if(PhotonNetwork.IsMasterClient){
            playerPosition = new Vector2(-7, 0);
            Spawn(playerPrefab[0]);
        } else {
            playerPosition = new Vector2(7, 0);
            Spawn(playerPrefab[1]);
        }
    }

    private void Spawn(GameObject playerPrefab)
    {
        PhotonNetwork.Instantiate(playerPrefab.name, playerPosition, Quaternion.identity);
    }

    public void DisconnectPhoton()
    {
        PhotonNetwork.Disconnect();
    }
}
