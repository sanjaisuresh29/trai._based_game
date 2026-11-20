using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;

public class Rocket_movement : MonoBehaviour
{
    [SerializeField] float Rocketime;

    //Rigidbody2D rb;

    public GameObject[] Bigrockets;

    

    int count = 0;

   public Vector2 BR1;
    public Vector2 BR2;
    public Vector2 BR3;

   
    void Start()
    {

    }


    void Update()
    {
        if (Rocketime > 0)
        {
            Rocketime -= Time.deltaTime;
        }

        else if (Rocketime < 0)
        {
            Rocketime = 0;

            count += 1;

            switch (count)
            {
                case 1:
                    Bigrockets[0].SetActive(true);

                    break;
                case 2:
                    Bigrockets[0].SetActive(true);
                    Bigrockets[1].SetActive(true);


                    break;
                case 3:
                    Bigrockets[0].SetActive(true);
                    Bigrockets[1].SetActive(true);
                    Bigrockets[2].SetActive(true);


                    break;
                default:
                    Debug.Log("error");
                    break;
            }

            Rocketime = 10;
        }

        if (count >= 3)
        {
            count = 3;

            // StartCoroutine(stopspwaning());

            if(Rocketime < 0)
            {
                Bigrockets[0].SetActive(true);
                Bigrockets[1].SetActive(true);
                Bigrockets[2].SetActive(true);
            }
        }
        if (Bigrockets[0].transform.position.y <= -8)
        {
            Bigrockets[0].transform.position = BR1;
            Bigrockets[0].SetActive(false);
        }
        if (Bigrockets[1].transform.position.y <= -8)
        {
            Bigrockets[0].transform.position = BR1;
            Bigrockets[1].transform.position = BR2;
            Bigrockets[1].SetActive(false);
        }

        if (Bigrockets[2].transform.position.y <= -8)
        {
            Bigrockets[0].transform.position = BR1;
            Bigrockets[1].transform.position = BR2;
            Bigrockets[2].transform.position = BR3;
            Bigrockets[2].SetActive(false);
        }
    }

    IEnumerator stopspwaning()
    {
        yield return new WaitForSeconds(10);
        Bigrockets[0].SetActive(true);
        Bigrockets[1].SetActive(true);
        Bigrockets[2].SetActive(true);
    }
    
}
