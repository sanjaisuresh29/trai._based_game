using System;
using UnityEngine;

public class circlesheild : MonoBehaviour
{
    public Transform player;

    public float radius;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);
        if (dist <= radius) {

            
            Debug.Log("IN");

        }
    }
}
