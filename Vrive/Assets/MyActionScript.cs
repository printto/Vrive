using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class MyActionScript : MonoBehaviour
{
    // a reference to the action
    public SteamVR_Action_Boolean SphereOnOff;
    // a reference to the hand
    public SteamVR_Input_Sources handType;
    //reference to the sphere
    public GameObject Sphere;
    void Start()
    {
        SphereOnOff.AddOnStateDownListener(TriggerDown, handType);
        SphereOnOff.AddOnStateUpListener(TriggerUp, handType);
    }
    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        // Debug.Log(“Trigger is up”);
        Debug.Log("Trigger is Up");
        Sphere.GetComponent<MeshRenderer>().enabled = false;
    }
    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        // Debug.Log(“Trigger is down”);
        Debug.Log("Trigger is Up");
        Sphere.GetComponent<MeshRenderer>().enabled = true;
    }

    void Update()
    {
    }
}