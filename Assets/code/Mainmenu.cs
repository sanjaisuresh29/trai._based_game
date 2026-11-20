using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public ParticleSystem damla;

    Vector2 mousepos;

    public GameObject panel;

    public GameObject buttons;
    private void Start()
    {
        damla.gameObject.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            damla.transform.position = new Vector2(mousepos.x, mousepos.y);
            damla.gameObject.SetActive(true);
            damla.Play();


            if (Input.GetMouseButtonUp(0))
            {
                damla.gameObject.SetActive(false);
            }
        }
    }

    public void loadnextscene()
    {
        
        SceneManager.LoadScene(1);
    }

    public void openinstruction()
    {
        buttons.SetActive(false);
        panel.SetActive(true);
    }

    public void backbutton()
    {
        buttons.SetActive(true);
        panel.SetActive(false);
    }
}
