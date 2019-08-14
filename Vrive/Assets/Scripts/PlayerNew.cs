using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerNew : MonoBehaviour
{

 

    public static checkPoint checkPoint;


    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }






    void Update()
    {
       if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Pressed!");
            checkPoint.respawnPlayerAtCheckPoint();
        }
    }



    /*
     * 
     * These are for animations
     *
     */


    /*
     * 
     * These are for sounds
     *
     */

    /*
   public void playSound(AudioClip[] sounds)
   {
       if (soundEffect != null)
           soundEffect.PlaySound(sounds);
   }
   */



}