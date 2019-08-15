using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRControllerRight : Abstract_VRController
{
    public override void ForwardingDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        DDebug.Instance.Log("Forwarding down");
        Debug.Log("Forwarding down");
        isForwarding = true;
    }

    public override void ForwardingUp(SteamVR_Action_Boolean fromActive, SteamVR_Input_Sources fromSource)
    {
        DDebug.Instance.Log("Forwarding Up");
        Debug.Log("Forwarding Up");
        isForwarding = false;
    }
}
