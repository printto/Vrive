using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecordText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshPro>().text = "Time Record\n" + LastRecordTime.GetString();
    }
    
}
