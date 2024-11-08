using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public KeyCode space;
    public float speed;
    private Vector2 playerMove;
    private string playerName;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerName = gameObject.name;
    }

    void Update()
    {
        playerControl();
    }

    private void playerControl()
    {
        switch(playerName){
            case "Player":
                playerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
                break;

            case "Player2":
                playerMove = new Vector2(0, Input.GetAxisRaw("Vertical1"));
                break;    
        }   
    }

    private void FixedUpdate()
    {
        rb2d.velocity = playerMove * speed;
    }
}