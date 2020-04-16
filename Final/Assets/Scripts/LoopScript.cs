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

    void Start() {
        loopNum = 0;
        firstLoop = true;
        loopIsTrue = false;
        rotateCam = false;
        camOff = cam.GetComponent<CinemachineCameraOffset>();
    }

    public bool loopIsTrue;
    //public vignette vScript;
    //public lensDistortion ldScript;

    void Update()
    {

        if (loopIsTrue) {
            //vScript.increaseVignette = true;
            //ldScript.distort = true;
            loopIsTrue = false;
        }

        if (rotateCam)
        {
            //rotate the camera on Z-axis 180 degrees           
            cam.transform.rotation = Quaternion.Euler(12.399f, -9.892f, 180);
            camOff.m_Offset = new Vector3(-3.97f, -0.27f, 0);
        }
        else {
            cam.transform.rotation = Quaternion.Euler(12.399f, 9.892f, 0);
            camOff.m_Offset = new Vector3(4.02f, 0.31f, 0);
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Loop_Col")) { //If player hits the trigger for looping
            firstLoop = false;
            loopNum++;
            transform.position = fallPos.position;
<<<<<<< HEAD
            rotateCam = !rotateCam;
=======
            invertedGravity = false;
            collectives[0].SetActive(true);
            collectives[1].SetActive(true);
            collectives[2].SetActive(true);
            loopNum++;
>>>>>>> 0bcd2690b8fdd646b50989b4072ae8ec868598a7
        }
    }

}
