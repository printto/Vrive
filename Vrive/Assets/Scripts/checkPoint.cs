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

    //Take this as TextMeshPro
    public GameObject LapsText;
    public GameObject CuttingTrackText;

    //Next checkpoint
    public GameObject nextCheckPoint;

    public bool canCheck = false;
    public bool checkPointed = false;
    //public bool nextIsGoal = false;
    public bool isGoal = false;

    //Can add laps here (Only for goal)
    public int maxLaps = 2;
    int laps = 0;

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

            //For goal
            if (isGoal && canCheck && maxLaps > laps)
            {
                laps++;
                LapsText.GetComponent<TextMeshPro>().SetText("Lap " + laps + "/" + maxLaps);
            }
            else if (isGoal && canCheck)
            {
                
                LapsText.GetComponent<TextMeshPro>().SetText("GOAL~!!");
                SceneManager.LoadScene("Ending");
            }

            //All checkpoints
            if (canCheck)
            {
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
                checkPointed = true;
                canCheck = false;
                CuttingTrackText.GetComponent<TextMeshPro>().SetText("");
            }
            else if (!checkPointed)
            {
                CuttingTrackText.GetComponent<TextMeshPro>().SetText("Wrong checkpoint!");
            }
            else
            {
                CuttingTrackText.GetComponent<TextMeshPro>().SetText("");
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
