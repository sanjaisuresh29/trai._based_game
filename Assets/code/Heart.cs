using UnityEngine;

public class Heart : MonoBehaviour
{
    int count = 0;

   

    public ParticleSystem brokenheart;

    public GameObject gameover;


    public Animator panelanim;

   public bool inside = false;

    bool canplay = true;
    void Start()
    {
        
    }

    
    void Update()
    {
        
        if(count >= 3)
        {
           this.gameObject.SetActive(false);
            panelanim.SetBool("playnow", canplay);
            Invoke("Gameover", 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" || collision.tag == "Bigrocket")
        {
            if (!inside)
            {
                count += 1;
                brokenheart.transform.position = new Vector3(0, 0, -1);
                brokenheart.gameObject.SetActive(true);
                brokenheart.Play();

            }
            
        }
    }


    public void Gameover()
    {
        gameover.SetActive(true);
        
        //Time.timeScale = 0f;
        
        
    }
}
