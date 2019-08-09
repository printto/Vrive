using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public GameObject timerText;
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }
    
    private void Update()
    {
        float t = Time.time - startTime;
        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        //timerText.text = minutes + ":" + seconds;
        timerText.GetComponent<TextMeshPro>().SetText(minutes + ":" + seconds);
        CurrentTime.GetCurrentTimeString = timerText.GetComponent<TextMeshPro>().text;
    }

    public void RecordTime()
    {
        LastRecordTime.record = Time.time - startTime;
    }

}
