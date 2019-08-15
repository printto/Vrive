using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Abstract_VRController : MonoBehaviour
{
    public SteamVR_Action_Boolean _InputForwarding;
    // public SteamVR_Action_Boolean _InputForwarding2;
    public SteamVR_Action_Boolean _InputBacking;
    public SteamVR_Action_Boolean _InputBreaking;

    public SteamVR_Input_Sources leftHand = SteamVR_Input_Sources.LeftHand;
    public SteamVR_Input_Sources rightHand = SteamVR_Input_Sources.RightHand;

    protected bool isForwarding;
    protected bool isBacking;
    protected bool isBreaking;

    /**
     * Called when component actived or enabled
     */
    private void OnEnable()
    {
        // Bind event handler;
        // Right Hand
        _InputForwarding.AddOnStateDownListener(ForwardingDown, rightHand);
        _InputForwarding.AddOnStateUpListener(ForwardingUp, rightHand);
        // _InputForwarding2.AddOnStateDownListener(ForwardingDown, rightHand);
        // _InputForwarding2.AddOnStateUpListener(ForwardingUp, rightHand);

        // Left Hand
        _InputBacking.AddOnStateDownListener(BackingDown, leftHand);
        _InputBacking.AddOnStateUpListener(BackingUp, leftHand);
        _InputBreaking.AddOnStateDownListener(BreakingDown, leftHand);
        _InputBreaking.AddOnStateUpListener(BreakingUp, leftHand);
    }

    /**
     * Called when component disabled
     */
    private void OnDisable()
    {
        // Unbind event handler;
        // Right Hand
        _InputForwarding.RemoveOnStateDownListener(ForwardingDown, rightHand);
        _InputForwarding.RemoveOnStateUpListener(ForwardingUp, rightHand);
        // _InputForwarding2.RemoveOnStateDownListener(ForwardingDown, rightHand);
        // _InputForwarding2.RemoveOnStateUpListener(ForwardingUp, rightHand);

        // Left Hand
        _InputBacking.RemoveOnStateDownListener(BackingDown, leftHand);
        _InputBacking.RemoveOnStateUpListener(BackingUp, leftHand);
        _InputBreaking.RemoveOnStateDownListener(BreakingDown, leftHand);
        _InputBreaking.RemoveOnStateUpListener(BreakingUp, leftHand);
    }

    private void FixedUpdate()
    {
        // handle movement stuff here
    }

    #region RequiredOverride
    public virtual void ForwardingDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        throw new System.NotImplementedException();
    }

    public virtual void ForwardingUp(SteamVR_Action_Boolean fromActive, SteamVR_Input_Sources fromSource)
    {
        throw new System.NotImplementedException();
    }

    public virtual void BackingDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        throw new System.NotImplementedException();
    }

    public virtual void BackingUp(SteamVR_Action_Boolean fromActive, SteamVR_Input_Sources fromSource)
    {
        throw new System.NotImplementedException();
    }

    public virtual void BreakingDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        throw new System.NotImplementedException();
    }

    public virtual void BreakingUp(SteamVR_Action_Boolean fromActive, SteamVR_Input_Sources fromSource)
    {
        throw new System.NotImplementedException();
    }
    #endregion
}
