using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;


public class Bulletspeed : MonoBehaviour
{
    public GameObject bullet;
    private Rigidbody2D rb;

    public int Bspeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = Vector2.up * Bspeed;
    }
}
