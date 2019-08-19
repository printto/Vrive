 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.Equals("hand"))
        {
            SceneManager.LoadScene("Track");
        }
    }
}
