using UnityEngine;

public class Blinking : MonoBehaviour
{
    public GameObject blinkingBattery;
    public GameObject blinkingInverter;
    public GameObject blinkingSolar;
    public GameObject blinkingGridPole;
    public Material material;        // The material to apply the blinking effect to
    public float blinkSpeed = 1.0f;  // Speed of the blinking effect
    public float minOpacity = 0.2f;  // Minimum opacity (0 to 1)
    public float maxOpacity = 1.0f;  // Maximum opacity (0 to 1)
    public bool isBlinking = false;  // Flag to enable or disable blinking

    private Color originalColor;
    private float blinkTimer;

    void Start()
    {
        if (material != null)
        {
            material.SetOverrideTag("RenderType", "Transparent");
            material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            material.SetInt("_ZWrite", 0);
            material.DisableKeyword("_ALPHATEST_ON");
            material.EnableKeyword("_ALPHABLEND_ON");
            material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            material.renderQueue = 3000;

            // Set original color to light yellow if starting as black
            originalColor = material.color;

                originalColor = new Color(1f, 1f, 0.6f, maxOpacity); // Set to light yellow with full alpha
                material.color = originalColor;


            Debug.Log("Original Color: " + originalColor);
        }
    }



    void Update()
    {
        if (material != null)
        {
            if (isBlinking)
            {
                // Calculate the new opacity for blinking effect
                float alpha = Mathf.Lerp(minOpacity, maxOpacity, (Mathf.Sin(blinkTimer * blinkSpeed) + 1.0f) / 2.0f);

                // Apply the new color with updated alpha
                Color newColor = originalColor;
                newColor.a = alpha;
                material.color = newColor;

                // Update the timer
                blinkTimer += Time.deltaTime;
            }
            else
            {
                // Reset opacity to original when blinking is disabled
                ResetOpacity();
            }
        }
    }

    // Method to reset the opacity to the original color
    public void ResetOpacity()
    {
        if (material != null)
        {
            Color resetColor = originalColor;
            resetColor.a = maxOpacity; // Set back to maxOpacity when not blinking
            material.color = resetColor;
            blinkTimer = 0.0f; // Reset the timer
        }
    }

    // Method to start blinking
    public void StartBlinking()
    {
        isBlinking = true;
    }

    // Method to stop blinking
    public void StopBlinking()
    {
        isBlinking = false;
        ResetOpacity();
    }

    public void EnableEducation(GameObject edu)
    {
        edu.SetActive(true);
    }
}
