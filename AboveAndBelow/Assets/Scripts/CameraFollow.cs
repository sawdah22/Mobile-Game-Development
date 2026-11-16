using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public float leftBoundary = -10f;
    public float rightBoundary = 10f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        float cameraHalfWidth = cam.orthographicSize * cam.aspect;

        float minX = leftBoundary + cameraHalfWidth;
        float maxX = rightBoundary - cameraHalfWidth;

        float targetX = target.position.x;

        if (minX <= maxX)
        {
            targetX = Mathf.Clamp(targetX, minX, maxX);
        }
        else
        {
            targetX = (leftBoundary + rightBoundary) / 2f;
        }

        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
