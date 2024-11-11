using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using Photon.Pun;

public class ballPhysics : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public int rotationSpeed;
    public Vector3 startRotation;
    int maxVelocity = 10;
    public string gameMode;
    float[] xAxis = {-45, 45};
    float[] yAxis = {-45, 45};
    int randomX;
    int randomY;
    public bool gameStart = false;
    public bool alreadyStarted = false;
    public int timing;

    void Start()
    {
        gameMode = SceneManager.GetActiveScene().name;
        rb2d = GetComponent<Rigidbody2D>();
        alreadyStarted = false;

        if(SceneManager.GetActiveScene().name != "2p_MultiplayerMode" && SceneManager.GetActiveScene().name != "1p_StoryMode"){
            Invoke("GoBall", 3f);
        } 
        
        if (SceneManager.GetActiveScene().name == "1p_StoryMode"){
            Invoke("GoBall", timing);
        }

        transform.eulerAngles = startRotation;
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    void Update()
    {
        Rotation();
        rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxVelocity);
        Debug.Log(gameStart);
        CheckPlayer();

        if(gameStart)
        {
            Invoke("GoBall", 3f);
            gameStart = false;
            alreadyStarted = true;
            Debug.Log("If "+ gameStart);
            Debug.Log("2p Invoke");
        }
    }

    void Rotation()
    {
        transform.Rotate(Vector3.forward, 10f * Time.deltaTime);
    }

    public void GoBall()
    {
        switch(gameMode){
            case "1p_StoryMode":
                randomY = Random.Range(0, 2);       
                rb2d.constraints = RigidbodyConstraints2D.None;

                rb2d.AddForce(new Vector2(xAxis[0], yAxis[randomY]));
                break;

            case "1p_EnemyMode":    
                randomX = Random.Range(0, 2);
                randomY = Random.Range(0, 2);       
                rb2d.constraints = RigidbodyConstraints2D.None;

                rb2d.AddForce(new Vector2(xAxis[randomX], yAxis[randomY]));
                break;

            case "2p_CouchMode":
                randomX = Random.Range(0, 2);
                randomY = Random.Range(0, 2);       
                rb2d.constraints = RigidbodyConstraints2D.None;

                rb2d.AddForce(new Vector2(xAxis[randomX], yAxis[randomY]));
                break;

            case "2p_MultiplayerMode":
                randomX = Random.Range(0, 2);
                randomY = Random.Range(0, 2);       
                rb2d.constraints = RigidbodyConstraints2D.None;

                rb2d.AddForce(new Vector2(xAxis[randomX], yAxis[randomY]));
                break;    
        }
        
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        Invoke("ResetBall", 1);
        Invoke("GoBall", 2);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player1") || coll.collider.CompareTag("Player2"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 2);
            rb2d.velocity = vel;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(SceneManager.GetActiveScene().name != "1p_StoryMode"){
            if(coll.CompareTag("Goal"))
            {
                RestartGame();
            }
        }
    }

    void CheckPlayer()
    {
        if(GameObject.FindGameObjectWithTag("Player2") && !alreadyStarted){
            gameStart = true;
        }
    }

}