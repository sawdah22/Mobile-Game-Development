using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    public GameObject LevelCompletedPanel;
    private bool levelCompleted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( levelCompleted)
        {
            return;
        }

        if (collision.GetComponent<MushroomBuddyMovement>() != null)
        {
            levelCompleted = true;
            Debug.Log("Level Completed!");

            if (LevelCompletedPanel != null)
            {
                LevelCompletedPanel.SetActive(true);
            }
        }
    }
}
