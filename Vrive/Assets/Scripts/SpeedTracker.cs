using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTracker : MonoBehaviour
{

    public GameObject speedText;
    public GameObject objectToTrack;

    // Update is called once per frame
    void Update()
    {
        if(speedText != null && objectToTrack != null)
        {
            speedText.GetComponent<TextMeshPro>().SetText(((int)objectToTrack.GetComponent<Rigidbody>().velocity.magnitude) + " KPH");
            //speedText.text = ((int)objectToTrack.GetComponent<Rigidbody>().velocity.magnitude) + " KPH";
        }
    }
}
