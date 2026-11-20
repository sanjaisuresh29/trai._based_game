using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject Bigrockets;

    Rigidbody2D rb;

    public ParticleSystem boom;

    bool canboom;

    public Vector2 startpos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //for (i = 0; i < Bigrockets.Length; i++)
        {
            if (Bigrockets.activeInHierarchy)
            {
                Vector2 moved = new Vector2(-1, -1);

                rb.linearVelocity = moved * 10;
            }
        }

        // canboom = false;

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            boom.gameObject.SetActive(true);
            boom.transform.position = this.transform.position;
            boom.Play();
            this.gameObject.SetActive(false);
            this.gameObject.transform.position = startpos;
        }
       
    }
}
