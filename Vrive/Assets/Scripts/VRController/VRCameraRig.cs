using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRCameraRig : MonoBehaviour
{
    public static VRCameraRig Instance = null;
    // Start is called before the first frame update
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Destoryed " + gameObject.name);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        SceneManager.LoadScene("Track");
        // SteamVR_LoadLevel.Begin("Track");
    }

    public void LoadTrack()
    {
        GameObject rallyCar = GameObject.FindGameObjectWithTag("Vehicles");
        this.transform.SetParent(rallyCar.transform);
        this.transform.localPosition = new Vector3(0f, -0.093f, -0.339f);
        this.transform.localRotation = new Quaternion(0, 0, 0, 0);
        this.transform.localScale = new Vector3(0.556f, 0.668f, 1f);
    }

    public void LoadEndScene()
    {
        this.transform.parent = null;
        this.transform.localPosition = new Vector3(504.41f, 1.92f, 324.05f);
        this.transform.localRotation = new Quaternion(0, 106.118f, 0, 0);
        this.transform.localScale = new Vector3(10, 10, 10);
    }
}
