using System.IO;
using UnityEngine;
using Photon.Pun;

public class NetworkManager : MonoBehaviour
{
    void Start()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        Debug.Log("Creating Player");
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity, 0);
    }
}
