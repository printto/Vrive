using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    public GameObject target;
    public bool reverse;

    // Update is called once per frame
    void Update()
    {
        if (reverse)
        {
            transform.LookAt(2 * transform.position - target.transform.position);
        }
        else
        {
            transform.LookAt(target.transform);
        }
    }
}
