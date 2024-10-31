using UnityEngine;
using TMPro;

public class CameraController : MonoBehaviour
{
    public Transform[] cameraPositions;
    public float transitionSpeed = 5.0f; // Speed of transition, adjust as needed
    private Transform targetTransform;
    private bool isMoving = false;
    public int cam = 0;
    public GameObject Solar;
    public GameObject DCACBatt;
    public GameObject InsideHouse;
    public GameObject Grid;
    public GameObject panelBlinking;
    public GameObject batteryBlinking;
    public GameObject inverterBlinking;
    public GameObject solarEducation;
    public GameObject batteryEducation;
    public GameObject inverterEducation;
    public GameObject gridInformation;
    public Blinking blinking;


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

            Solar.SetActive(false);
            DCACBatt.SetActive(false);
            InsideHouse.SetActive(false);
            Grid.SetActive(false);
            blinking.StopBlinking();
            solarEducation.SetActive(false);
            batteryEducation.SetActive(false);
            inverterEducation.SetActive(false);
            gridInformation.SetActive(false);
        }
    }

    private void UpdateTextVisibility()
    {
        Debug.Log("Current camera position index: " + cam);
        // Initially disable all text displays
        Solar.SetActive(false);
        DCACBatt.SetActive(false);
        InsideHouse.SetActive(false);
        Grid.SetActive(false);
        panelBlinking.SetActive(false);
        batteryBlinking.SetActive(false);
        inverterBlinking.SetActive(false);

        switch (cam)
        {
            case 0:
                Debug.Log("All texts disabled.");
                break;
            case 1:
                Solar.SetActive(true);
                panelBlinking.SetActive(true);
                blinking.StartBlinking();
                Debug.Log("Solar text enabled.");
                break;
            case 2:
                DCACBatt.SetActive(true);
                batteryBlinking.SetActive(true);
                inverterBlinking.SetActive(true);
                blinking.StartBlinking();
                Debug.Log("DC Load, AC Load, and Battery texts enabled.");
                break;
            case 3:
                InsideHouse.SetActive(true);
                Debug.Log("Showing inside house.");
                break;
            case 4:
                Grid.SetActive(true);
                Debug.Log("Grid.");
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
