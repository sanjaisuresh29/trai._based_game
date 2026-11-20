using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] float remaingtime;


    public GameObject shield;

    public ParticleSystem aura;

    

    public Vector2 pos;
    void Update()
    {
        if (remaingtime > 0)
        {
            remaingtime -= Time.deltaTime;
        }

        else if (remaingtime < 0)
        {
            remaingtime = 0;
            this.transform.position = new Vector2(Random.Range(-8, 8), Random.Range(-4, 4));
            if (remaingtime == 0)
            {
                aura.gameObject.SetActive(true);
                aura.transform.position = this.transform.position;
                aura.Play();
                remaingtime = 40;

                Invoke("stoplplaying", 10);

             




            }

           

        }

       
    }
    void stoplplaying()
    {
        aura.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" || collision.tag == "Bigrocket")
        {
            Debug.Log("inside");
        }
    }

}
