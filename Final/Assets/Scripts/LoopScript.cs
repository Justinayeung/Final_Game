using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopScript : MonoBehaviour
{
    public Transform fallPos;
    public int loopNum;
    public bool firstLoop;

    void Start() {
        loopNum = 0;
        firstLoop = true;
    }

    public bool loopIsTrue = false;

    void Update()
    {
        if (loopIsTrue) {
            loopIsTrue = false;
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Loop_Col")) { //If player his the trigger for looping
            firstLoop = false;
            transform.position = fallPos.position;
            loopNum++;
            loopIsTrue = true;
        }
    }
}
