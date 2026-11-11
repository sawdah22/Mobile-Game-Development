using UnityEngine;

public class MobileControls : MonoBehaviour
{
    public static float horizontalInput = 0f;
    public static bool jumpPressed = false;
    public static bool flipPressed = false;

    public void MoveLeft()
    {
        horizontalInput = -1f;
    }

    public void MoveRight()
    {
        horizontalInput = 1f;
    }

    public void StopMoving()
    {
        horizontalInput = 0f;
    }

    public void Jump()
    {
        jumpPressed = true;
    }

    public void Flip()
    {
        flipPressed = true;
    }
}
