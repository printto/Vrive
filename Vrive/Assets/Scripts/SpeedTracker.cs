using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTracker : MonoBehaviour
{

    public Text speedText;
    public GameObject objectToTrack;

    // Update is called once per frame
    void Update()
    {
        if(speedText != null && objectToTrack != null)
        {
            speedText.text = ((int)objectToTrack.GetComponent<Rigidbody>().velocity.magnitude) + " KPH";
        }
    }
}
