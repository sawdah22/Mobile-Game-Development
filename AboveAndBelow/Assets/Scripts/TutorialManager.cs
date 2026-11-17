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
            tutorialStep = 1;
        }
        else if (tutorialStep == 1)
        {
            movementTutorialText.SetActive(false);
            tutorialPanel.SetActive(false);
            canMove = true;
            tutorialStep = 2;
        }
        else if (tutorialStep == 3)
        {
            jumpTutorialText.SetActive(false);
            tutorialPanel.SetActive(false);
            canMove = true;
            canJump = true;
            tutorialStep = 4;
        }
        else if (tutorialStep == 5)
        {
            flipTutorialText.SetActive(false);
            tutorialPanel.SetActive(false);
            canMove = true;
            canFlip = true;
            tutorialStep = 6;
            PlayerPrefs.SetInt("TutorialCompleted", 1);
            PlayerPrefs.Save();
        }
    }

    public void ShowJumpTutorial()
    {
        if (tutorialStep == 2)
        {
            tutorialPanel.SetActive(true);
            jumpTutorialText.SetActive(true);
            canMove = false;
            tutorialStep = 3;
        }
    }

    public void ShowFlipTutorial()
    {
        if (tutorialStep == 4)
        {
            tutorialPanel.SetActive(true);
            flipTutorialText.SetActive(true);
            canMove = false;
            tutorialStep = 5;
        }
    }
}
