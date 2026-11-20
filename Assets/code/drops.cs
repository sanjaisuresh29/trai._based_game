using System.Collections.Generic;
using System.Collections;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class drops : MonoBehaviour
{
    private Rigidbody2D rb;

    public ufo_posion ufomoving;

    public GameObject poision;

    bool candeploy = false;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        int timetodeploy = Random.Range(2, 4);

        if(this.transform.position.x >= -8 && this.transform.position.y >= -4)
        {
            StartCoroutine(deploynow());
        }
        
        
    }

    
    void Update()
    {


        Invoke("canmove", 3);
        

        
    }
    void canmove()
    {
        Vector3 rotz = new Vector3(0, 0, 360);

        Vector3 rota = new Vector2(this.transform.position.x, this.transform.position.y);

        transform.RotateAround(rota, rotz, 50 * Time.deltaTime);
        //Vector2 spwanpos = new Vector2(this.transform.position.x, 0);

        if (ufomoving.posionpos[0].transform.position == this.transform.position)
        {
            rb.linearVelocity = Vector2.down * 2;
        }

        else if (ufomoving.posionpos[1].transform.position == this.transform.position)
        {
            rb.linearVelocity = Vector2.right * 2;
        }
        else if (ufomoving.posionpos[2].transform.position == this.transform.position)
        {
            rb.linearVelocity = Vector2.left * 2;
        }

        else if (ufomoving.posionpos[3].transform.position == this.transform.position)
        {
            rb.linearVelocity = Vector2.up * 2;
        }
    }
    IEnumerator deploynow()
    {
        yield return new WaitForSeconds(3);
        if (!candeploy)
        {
            Instantiate(poision, this.transform.position, Quaternion.identity);
            candeploy = true;
        }
    }

    
}
