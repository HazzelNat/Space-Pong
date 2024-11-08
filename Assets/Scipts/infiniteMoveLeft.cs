using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infiniteMoveLeft : MonoBehaviour
{
    public float scrollSpeed;

    private Renderer objectRenderer;
    private Vector2 savedOffset;

    void Start ()
    {
        objectRenderer = GetComponent<Renderer> ();
    }

    void Update ()
    {
        float x = Mathf.Repeat (Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2 (x, 0);
        objectRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

}
