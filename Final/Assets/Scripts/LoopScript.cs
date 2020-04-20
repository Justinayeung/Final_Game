using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LoopScript : MonoBehaviour
{
    public Transform fallPos;

    public int loopNum;
    public bool firstLoop;

    public GameObject cam;
    CinemachineCameraOffset camOff;

    public bool rotateCam;

    public bool loopIsTrue;
    public vignette vScript;
    public lensDistortion ldScript;

    void Start() {
        loopNum = 0;
        firstLoop = true;
        loopIsTrue = false;
        rotateCam = false;
        camOff = cam.GetComponent<CinemachineCameraOffset>();
    }

    void Update()
    {

        if (loopIsTrue) {
            vScript.increaseVignette = true;
            ldScript.distort = true;
            loopIsTrue = false;
        }

        if (rotateCam)
        {
            //rotate the camera on Z-axis 180 degrees           
            cam.transform.rotation = Quaternion.Euler(-12f, 1f, 180);
            camOff.m_Offset = new Vector3(-2.3f, 1f, 1);
            Physics.gravity = new Vector3(0, 9.81F, 0);
        }
        else {
            cam.transform.rotation = Quaternion.Euler(12f, 1f, 0);
            camOff.m_Offset = new Vector3(2.3f, 1f, 1);
            Physics.gravity = new Vector3(0, -9.81F, 0);
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Loop_Col")) { //If player hits the trigger for looping
            firstLoop = false;
            transform.position = fallPos.position;
            rotateCam = !rotateCam;
            loopIsTrue = true;
            loopNum++;
        }
    }

}
