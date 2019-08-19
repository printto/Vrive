 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{

    public bool isTesting = false;

    private void Start()
    {
        if (isTesting)
        {
            StartCoroutine(changeSceneTest());
        }
    }

    IEnumerator changeSceneTest()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Track");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("hand"))
        {
            SceneManager.LoadScene("Track");
        }
    }
}
