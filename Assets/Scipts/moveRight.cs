using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public float speed;
    private Vector3 destination = new Vector3(0, 0, -10);
    void Start()
    {

    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed*Time.deltaTime);
    }
}
