using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public KeyCode space;
    public float speed;
    private Vector2 botMove;
    public Transform ball;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        BotControl();
    }

    private void BotControl()
    {
        if(ball.position.y > transform.position.y + 0.6f){
            botMove = new Vector2(0, 1);
        } else if(ball.position.y < transform.position.y - 0.6f){
            botMove = new Vector2(0, -1);
        } else {
            botMove = new Vector2(0, 0);
        }
    }

    private void FixedUpdate()
    {
        rb2d.velocity = botMove * speed;
    }
}