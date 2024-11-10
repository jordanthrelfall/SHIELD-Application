using UnityEngine;

public class CyberBlinking : MonoBehaviour
{
    public Light targetLight;       // Reference to the light component
    public float minIntensity = 0f; // Minimum light intensity
    public float maxIntensity = 2f; // Maximum light intensity
    public float speed = 2f;        // Speed of the fade in/out

    private bool increasing = true;

    void Start()
    {
        if (targetLight == null)
        {
            targetLight = GetComponent<Light>();
        }
    }

    void Update()
    {
        // Adjust the intensity
        if (increasing)
        {
            targetLight.intensity += speed * Time.deltaTime;
            if (targetLight.intensity >= maxIntensity)
            {
                increasing = false;
            }
        }
        else
        {
            targetLight.intensity -= speed * Time.deltaTime;
            if (targetLight.intensity <= minIntensity)
            {
                increasing = true;
            }
        }

        // Ensure light is red
        targetLight.color = Color.red;
    }
}
