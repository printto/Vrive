using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTurnController : MonoBehaviour
{
    [Header("Driven tool")]
    public VR_WheelDrive wheelDrive;
    [Header("Angle Optimization")]
    [SerializeField]
    private bool CalculateDistanceBetweenTwoStick = true;
    public float MinDistance = 0.1f; // Before start turning on the first angle
    public float MaxDistance = 1f; // Maximum distance that turn = 1
    public float TurnRate = 0.2f;

    // [Header("VR Controllers Stick in the CameraRig")]
    // public GameObject[] VRControllers;
    // Start is called before the first frame update
    void Start()
    {
        // if (VRControllers.Length < 2)
        // {
        //     Debug.LogWarning("Controller might be missing!");
        // }
    }

    void FixedUpdate()
    {
        GameObject[] VRControllers = GameObject.FindGameObjectsWithTag("Controller");
        // Determine which one is left / right;
        Transform rightController;
        Transform leftController;

        if (VRControllers[0].transform.localPosition.x < VRControllers[1].transform.localPosition.x)
        {
            // DDebug.Instance.Log("0");
            leftController = VRControllers[0].transform;
            rightController = VRControllers[1].transform;
        }
        else
        {
            // DDebug.Instance.Log("1");
            leftController = VRControllers[1].transform;
            rightController = VRControllers[0].transform;
        }

        // Find the distance between two controller;
        if (CalculateDistanceBetweenTwoStick)
        {

        }

        // Find the center point;
        Vector3 centerPoint = (rightController.localPosition + leftController.localPosition) * 0.5f;

        // Determine the turn angle
        // Min = 0, Max = 1;
        float HorizontalDrive = 0;
        if (Mathf.Abs(rightController.localPosition.y - leftController.localPosition.y) <= MinDistance)
        {
            HorizontalDrive = 0;
        }
        else if (Mathf.Abs(rightController.localPosition.y - leftController.localPosition.y) >= MaxDistance)
        {
            HorizontalDrive = 1;
        }
        // right > left
        else if (rightController.localPosition.y > leftController.localPosition.y)
        {
            HorizontalDrive = (rightController.localPosition.y - leftController.localPosition.y) * TurnRate * -1;
        }
        else // left > right
        {
            HorizontalDrive = (leftController.localPosition.y - rightController.localPosition.y) * TurnRate;
        }

        // DDebug.Instance.Log("HorizontalDrive float : " + HorizontalDrive);
        // Debug.Log("HorizontalDrive float : " + HorizontalDrive);

        wheelDrive.HorizontalDrive = HorizontalDrive;
    }
}
