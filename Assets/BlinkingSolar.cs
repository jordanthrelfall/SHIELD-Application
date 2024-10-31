using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingSolar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject blinkingsolar;
    public GameObject solarEducation;
    private void OnMouseDown()
    {
        blinkingsolar.SetActive(false);
        solarEducation.SetActive(true);
    }
}
