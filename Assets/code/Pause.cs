using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public GameObject pausepanel;

    public void Resume()
    {
        pausepanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void pausegame()
    {
        pausepanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void home()
    {
        SceneManager.LoadScene(0);
    }

    public void restart()
    {
        SceneManager.LoadScene(1);
    }
}
