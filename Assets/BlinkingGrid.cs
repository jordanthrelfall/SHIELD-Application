using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingGrid : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject blinkingGridPole;
    public GameObject solarEducation;
    private void OnMouseDown()
    {
        blinkingGridPole.SetActive(false);
        solarEducation.SetActive(true);
    }
}
