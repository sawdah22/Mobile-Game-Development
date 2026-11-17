using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject SettingsPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("CharacterSelection");
    }

    public void ReplayTutorial()
    {
        PlayerPrefs.DeleteKey("TutorialCompleted");
        PlayerPrefs.Save();

        PlayGame();
    }

    public void OpenSettings()
    {
        SettingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
    }
}
