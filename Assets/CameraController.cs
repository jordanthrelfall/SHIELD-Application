using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] cameraPositions;
    public float transitionSpeed = 5.0f; // Speed of transition, adjust as needed
    private Transform targetTransform;
    private bool isMoving = false;

    /* Positions
    ---------
    0: Main
    1: Solar
    2: Battery
    3: Interior */

    void Start()
    {
        // Create a new GameObject to handle the target transform
        targetTransform = new GameObject("CameraTarget").transform;

        // Optionally set the initial position and rotation if desired
        if (cameraPositions.Length > 0)
        {
            SetCameraTransform(0);
        }
    }

    void Update()
    {
        if (isMoving)
        {
            MoveCameraToPosition();
        }
    }

    public void SetCameraTransform(int index)
    {
        if (index < cameraPositions.Length)
        {
            targetTransform.position = cameraPositions[index].position;
            targetTransform.rotation = cameraPositions[index].rotation;
            isMoving = true;
        }
    }

    private void MoveCameraToPosition()
    {
        // Smoothly interpolate the position and rotation of the camera to the target
        transform.position = Vector3.Lerp(transform.position, targetTransform.position, Time.deltaTime * transitionSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetTransform.rotation, Time.deltaTime * transitionSpeed);

        // Determine if the movement is close enough to consider complete
        if (Vector3.Distance(transform.position, targetTransform.position) < 0.01f && Quaternion.Angle(transform.rotation, targetTransform.rotation) < 0.1f)
        {
            isMoving = false; // Stop moving once the target is reached
        }
    }
}
