using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class rockets_blast : MonoBehaviour
{
    public GameObject[] rockets;

    float[] lifeTimes = { 3f,4f,5f };

    int i;

    public ParticleSystem blast;
    void Start()
    {
        for ( i = 0; i < rockets.Length; i++)
        {
            float t = lifeTimes[i];

            
            StartCoroutine(death(rockets[i], t));
        }
    }

    // Update is called once per frame
    void Update()
    {
        blast.transform.position = rockets[i].transform.position;
    }

   System.Collections.IEnumerator death(GameObject obj,float time)
    {
        yield return new WaitForSeconds(time);

        if(obj != null)
        {

            
            blast.gameObject.SetActive(true);
            blast.Play();
            obj.gameObject.SetActive(false);
        }
    }
}
