using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ufo_posion : MonoBehaviour
{
    public Transform[] posionpos;

    public GameObject ufo;

    int index;

   
    void Start()
    {
        spwanobjects();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
    void spwanobjects()
    {

         index = Random.Range(0, posionpos.Length);
        //Debug.Log(index);
        Instantiate(ufo, posionpos[index].transform.position, Quaternion.identity);

    }

    
  
}
