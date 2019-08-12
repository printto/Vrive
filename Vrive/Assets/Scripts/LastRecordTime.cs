using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastRecordTime
{

    public static float record;

    public static string GetString()
    {
        string minutes = ((int)record / 60).ToString();
        string seconds = (record % 60).ToString("f2");

        //timerText.text = minutes + ":" + seconds;
        return minutes + ":" + seconds;
    }
}
