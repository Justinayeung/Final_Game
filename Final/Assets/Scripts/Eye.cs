using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public Transform eyeDest;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(eyeDest);
    }
}
