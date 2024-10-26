using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject dc_light;
    public GameObject ac_light;
    public MessageHandler load;

    // Update is called once per frame
    void Update()
    {
        if (load.load == "AC")
        {
            ac_light.SetActive(true);
            dc_light.SetActive(false);
        }
        else if (load.load == "DC")
        {
            ac_light.SetActive(false);
            dc_light.SetActive(true);
        }
        else
        {
            ac_light.SetActive(true);
            dc_light.SetActive(true);
        }
    }
}
