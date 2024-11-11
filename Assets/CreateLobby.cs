using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateLobby : MonoBehaviourPunCallbacks
{
    public TMP_InputField createLobby;
    public TMP_InputField joinLobby;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createLobby.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinLobby.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("2p_MultiplayerMode");
    }
}
