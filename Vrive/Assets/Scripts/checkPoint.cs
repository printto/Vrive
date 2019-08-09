using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class checkPoint : MonoBehaviour {


    private static float x = 0;
    private static float y = 0;
    private static float z = 0;
    
    public GameObject timeLap;
    
    static Transform ThisTransform;

    static GameObject playerObject;

    //Take is as TextMeshPro
    public GameObject cutTrackText;

    //Next checkpoint
    public GameObject nextCheckPoint;

    public bool canCheck = false;
    public bool checkPointed = false;
    public bool nextIsGoal = false;
    bool isGoal = false;

    private void Start()
    {
        
        playerObject = GameObject.FindGameObjectWithTag("Vehicles");
    }

    public static void setSavePoint(float x, float y, float z)
    {
        checkPoint.x = x;
        checkPoint.y = y;
        checkPoint.z = z;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Vehicles"))
        {
            if (isGoal)
            {
                //TODO: Goal screen, record the time
                cutTrackText.GetComponent<TextMeshPro>().SetText("GOAL~!!");
            }
            if (canCheck)
            {
                cutTrackText.GetComponent<TextMeshPro>().SetText("");
                ThisTransform = transform;
                Debug.Log("Checkpoint!");
                Vector3 checkPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                setSavePoint(checkPos.x, checkPos.y, checkPos.z);
                Debug.Log(checkPos.x.ToString() + ", " + checkPos.y.ToString() + ", " + checkPos.z.ToString());
                PlayerNew.checkPoint = this;
                Debug.Log(checkPos.x.ToString() + ", " + checkPos.y.ToString());
                StartCoroutine(DisplayCheckpointTime());
                nextCheckPoint.GetComponent<checkPoint>().canCheck = true;
                nextCheckPoint.GetComponent<checkPoint>().checkPointed = false;
                if (nextIsGoal)
                {
                    nextCheckPoint.GetComponent<checkPoint>().setIsGoal(true);
                }
                checkPointed = true;
                canCheck = false;
                
                //For debug
                StartCoroutine(DisplayCutTrackText("Checkpoint!"));
            }
            else if(!checkPointed)
            {
                cutTrackText.GetComponent<TextMeshPro>().SetText("Cutting track!");
            }
            else
            {
                cutTrackText.GetComponent<TextMeshPro>().SetText("");
            }
        }
    }

    IEnumerator DisplayCheckpointTime() {
        string temp = CurrentTime.GetCurrentTimeString;
        //timeLap.text = temp;
        timeLap.GetComponent<TextMeshPro>().SetText(temp);
        yield return new WaitForSeconds(2f);
        timeLap.GetComponent<TextMeshPro>().SetText("");
        
    }

    IEnumerator DisplayCutTrackText(string text)
    {
        cutTrackText.GetComponent<TextMeshPro>().SetText(text);
        yield return new WaitForSeconds(2f);
        cutTrackText.GetComponent<TextMeshPro>().SetText("");
    }

    public void respawnPlayerAtCheckPoint()
    {
        playerObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        playerObject.transform.SetPositionAndRotation(new Vector3(ThisTransform.position.x, ThisTransform.position.y + 0.5f, ThisTransform.position.z), ThisTransform.rotation);
        Debug.Log("Respawned!");
        Debug.Log(checkPoint.x.ToString() + ", " + checkPoint.y.ToString() + ", " + checkPoint.z.ToString());
    }
    
    public void setIsGoal(bool isGoalParam)
    {
        isGoal = isGoalParam;
    }

}
