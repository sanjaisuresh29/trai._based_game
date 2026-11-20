using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;


public class spwaning_object : MonoBehaviour
{
    public Transform targetpos;

    public float reachdistance = 0.5f;

    public GameObject droprefab;

    public Vector2 randommin;

    public Vector2 randommax;

    bool spwaned = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (spwaned) return;

        float distance = Vector2.Distance(transform.position, targetpos.position);

        if(distance <= reachdistance)
        {
            spwaned = true;
        }
    }

    void spwaneddrop()
    {
        Vector2 posmin = new Vector2(Random.Range(randommin.x, randommin.x), Random.Range(randommin.x, randommax.y));
        Instantiate(droprefab, posmin, Quaternion.identity);
    }
}
