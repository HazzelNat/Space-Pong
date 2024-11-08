using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalTrigger : MonoBehaviour
{
    public static bool levelFinished = false;

    private void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ball")){
            string wallName = transform.name;
            GameManager.instance.Score(wallName);
        }
    }
}
