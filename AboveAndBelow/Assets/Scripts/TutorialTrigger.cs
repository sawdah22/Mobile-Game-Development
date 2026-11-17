using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public TutorialManager tutorialManager;
    public bool isJumpTutorial = true;

    private bool hasTriggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasTriggered && other.GetComponent<MushroomBuddyMovement>() != null)
        {
            hasTriggered = true;
            if (isJumpTutorial)
            {
                tutorialManager.ShowJumpTutorial();
            }
            else
            {
                tutorialManager.ShowFlipTutorial();
            }
        }
    }
}
