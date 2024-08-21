using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageHandler : MonoBehaviour
{

    public TextMeshProUGUI text;
    public Networking networking;
    public string timeOfDay;
    public string powerSource;
    public string load;

    public TMP_Text tod;
    public TMP_Text pwr;
    public TMP_Text ld;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = networking.text;
    }

    public void updateMessage()
    {
        timeOfDay = tod.text;
        powerSource = pwr.text;
        load = ld.text;
    }
}
