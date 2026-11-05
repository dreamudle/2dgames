using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    void Start()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
    public GameObject panel;

    public void Pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}