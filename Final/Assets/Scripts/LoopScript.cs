using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopScript : MonoBehaviour
{
    public Transform fallPos;
    public int loopNum;
    public bool firstLoop;

    public GameObject[] collectives;
    void Start() {
        loopNum = 0;
        firstLoop = true;
        loopIsTrue = false;
    }

    public bool loopIsTrue;
    public vignette vScript;
    public lensDistortion ldScript;

    void Update()
    {
        Debug.Log("looping is" + loopIsTrue);

        if (loopIsTrue) {

            vScript.increaseVignette = true;
            ldScript.distort = true;
            loopIsTrue = false;
          
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Loop_Col")) { //If player his the trigger for looping
            firstLoop = false;
            transform.position = fallPos.position;
            loopNum++;
            loopIsTrue = true;
            collectives[0].SetActive(true);
            collectives[1].SetActive(true);
            collectives[2].SetActive(true);
        }
    }

}
