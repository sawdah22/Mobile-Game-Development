using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject tutorialText;
    public GameObject movementTutorialText;
    public GameObject jumpTutorialText;
    public GameObject flipTutorialText;

    private int tutorialStep = 0;
    public static bool canMove = false;
    public static bool canJump = false;
    public static bool canFlip = false;

    void Start()
    {
        tutorialPanel.SetActive(false);
        tutorialText.SetActive(true);
        movementTutorialText.SetActive(false);
        jumpTutorialText.SetActive(false);
        flipTutorialText.SetActive(false);

        if (PlayerPrefs.GetInt("TutorialCompleted", 0) == 0)
        {
            canMove = false;
            canJump = false;
            canFlip = false;

            StartCoroutine(ShowTutorial());
        }
        else
        {
            canMove = true;
            canJump = true;
            canFlip = true;
        }
    }

    IEnumerator ShowTutorial()
    {
        yield return new WaitForSeconds(2F);
        tutorialPanel.SetActive(true);
    }

    public void ContinueTutorial()
    {
        if (tutorialStep == 0)
        {
            tutorialText.SetActive(false);
            movementTutorialText.SetActive(true);
            canMove = true;
            tutorialStep = 1;
        }
        else if (tutorialStep == 1)
        {
            movementTutorialText.SetActive(false);
            jumpTutorialText.SetActive(true);
            canJump = true;
            tutorialStep = 2;
        }
        else if (tutorialStep == 2)
        {
            jumpTutorialText.SetActive(false);
            flipTutorialText.SetActive(true);
            canFlip = true;
            tutorialStep = 3;
        }
        else if (tutorialStep == 3)
        {
            tutorialPanel.SetActive(false);
            canMove = true;
            canJump = true;
            canFlip = true;
            PlayerPrefs.SetInt("TutorialCompleted", 1);
            PlayerPrefs.Save();
        }
    }
}
