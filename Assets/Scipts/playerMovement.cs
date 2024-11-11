using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public KeyCode space;
    public float speed;
    private Vector2 playerMove;
    private string playerTag;
    PhotonView photonView;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerTag = gameObject.tag;

        photonView = GetComponent<PhotonView>();

        // if(SceneManager.GetActiveScene().name == "2p_MultiplayerMode"){
            
        // } else {
        //     PhotonTransformViewClassic = false;
        // }
    }

    void Update()
    {
        playerControl();
        playerControlMultiplayer();
    }

    private void playerControlMultiplayer()
    {
        if(photonView.IsMine){
            switch(playerTag){
                case "Player1":
                    playerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
                    break;

                case "Player2":
                    if(SceneManager.GetActiveScene().name == "2p_MultiplayerMode"){
                        playerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
                    } else {
                        playerMove = new Vector2(0, Input.GetAxisRaw("Vertical1"));
                    }
                    
                    break;
            }
        }
    }

    private void playerControl()
    {
        switch(playerTag){
            case "Player1":
                playerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
                break;

            case "Player2":
                if(SceneManager.GetActiveScene().name == "2p_MultiplayerMode"){
                    playerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
                } else {
                    playerMove = new Vector2(0, Input.GetAxisRaw("Vertical1"));
                }
                
                break;
        }
        
    }

    private void FixedUpdate()
    {
        rb2d.velocity = playerMove * speed;
    }
}