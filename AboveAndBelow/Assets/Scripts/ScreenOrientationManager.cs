using UnityEngine;

public class ScreenOrientationManager : MonoBehaviour
{
    public bool useLandscape = false;
    public GameObject rotatePhonePanel;

    void Start()
    {
        if (useLandscape)
        {
            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = false;
            Screen.autorotateToLandscapeLeft = true;
            Screen.autorotateToLandscapeRight = true;
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
        else
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        if (rotatePhonePanel !=null)
        {
            rotatePhonePanel.SetActive(false);
        }
    }

    void Update()
    {
        if (useLandscape && rotatePhonePanel != null)
        {
            bool isportrait = Screen.width < Screen.height;
            rotatePhonePanel.SetActive(isportrait);
        }

    }
}
