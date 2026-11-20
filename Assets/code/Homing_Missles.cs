using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;


[RequireComponent(typeof(Rigidbody2D))]
public class Homing_Missles : MonoBehaviour
{
    private GameObject target;

    public float speed;

    public float rotatespeed;

    float chasetime;

    bool ischase = false;

    private Rigidbody2D rb;

    public ParticleSystem blast;

    private Heart life;



    

    int timetoblast;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timetoblast = Random.Range(3, 7);
        target = GameObject.FindWithTag("Player");
        //Debug.Log("blast" + timetoblast);
    }

   

    private void Update()
    {
        chasetime += Time.deltaTime;
        
        
        
       
      

            //if (ischase)
            {
                Vector2 direction = (Vector2)target.transform.position - rb.position;

                direction.Normalize();
             

                float rotateamount = Vector3.Cross(direction, transform.up).z;

                rb.angularVelocity = -rotateamount * rotatespeed;
                
                

                rb.linearVelocity = transform.up * speed;

                StartCoroutine(nowblast(timetoblast));

            }

        

       



        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            blast.gameObject.SetActive(true);
            blast.transform.position = this.transform.position;
            blast.Play();
            Instantiate(blast, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }


        if (collision.tag == "Shield")
        {
            Debug.Log("hit the shild");
            life.inside = true;
            blast.gameObject.SetActive(true);
            blast.transform.position = this.transform.position;
            blast.Play();
            Instantiate(blast, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }






    }

    
    
    IEnumerator nowblast(int time)
    {
        yield return new WaitForSeconds(time);
        blast.gameObject.SetActive(true);
        blast.transform.position = this.transform.position;
        blast.Play();
        
        Instantiate(blast, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
       
    }

    void blastgame()
    {
        Destroy(gameObject);
    }

    

    

    
}
