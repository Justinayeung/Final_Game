using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopScript : MonoBehaviour
{
    public Transform fallPos;

    public bool loopIsTrue = false;

    void Update()
    {
        if (loopIsTrue)
        {
            loopIsTrue = false;
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Loop_Col")) {
            transform.position = fallPos.position;

            loopIsTrue = true;
        }
    }
}
