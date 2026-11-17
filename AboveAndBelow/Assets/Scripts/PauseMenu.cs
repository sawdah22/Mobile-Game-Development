using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseButton;

    void Start()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
       Time.timeScale = 1f;
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
