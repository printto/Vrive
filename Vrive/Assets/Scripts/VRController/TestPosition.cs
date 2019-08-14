using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPosition : MonoBehaviour
{
    VRController[] controllers;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        controllers = GetComponentsInChildren<VRController>();
    }

    // Update is called once per frame
    void Update()
    {
        DDebug.Instance.Log("0 : " + controllers[0].gameObject.transform.localPosition.ToString());   
        DDebug.Instance.Log("1 : " + controllers[1].gameObject.transform.localPosition.ToString());   
    }
}
