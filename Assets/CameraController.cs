using UnityEngine;
using TMPro;

public class CameraController : MonoBehaviour
{
    public Transform[] cameraPositions;
    public float transitionSpeed = 5.0f; // Speed of transition, adjust as needed
    private Transform targetTransform;
    private bool isMoving = false;
    public int cam = 0;
    public TMP_Text solarMetering;
    public TMP_Text solarLearning;
    public TMP_Text dc_load;
    public TMP_Text ac_load;
    public TMP_Text battery;
    public TMP_Text dcacbattLearning;


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
            cam = index;

            solarMetering.gameObject.SetActive(false);
            solarLearning.gameObject.SetActive(false);
            dc_load.gameObject.SetActive(false);
            ac_load.gameObject.SetActive(false);
            battery.gameObject.SetActive(false);
            dcacbattLearning.gameObject.SetActive(false);
        }
    }

    private void UpdateTextVisibility()
    {
        Debug.Log("Current camera position index: " + cam);
        // Initially disable all text displays
        solarMetering.gameObject.SetActive(false);
        solarLearning.gameObject.SetActive(false);
        dc_load.gameObject.SetActive(false);
        ac_load.gameObject.SetActive(false);
        battery.gameObject.SetActive(false);
        dcacbattLearning.gameObject.SetActive(false);

        switch (cam)
        {
            case 0:
                Debug.Log("All texts disabled.");
                break;
            case 1:
                solarMetering.gameObject.SetActive(true);
                solarLearning.gameObject.SetActive(true);
                Debug.Log("Solar text enabled.");
                break;
            case 2:
                dc_load.gameObject.SetActive(true);
                ac_load.gameObject.SetActive(true);
                battery.gameObject.SetActive(true);
                dcacbattLearning.gameObject.SetActive(true);
                Debug.Log("DC Load, AC Load, and Battery texts enabled.");
                break;
            case 3:
                Debug.Log("No text settings defined for camera position 2.");
                break;
            default:
                Debug.Log("Default case: all texts disabled.");
                break;
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
            UpdateTextVisibility();
        }
    }
}
