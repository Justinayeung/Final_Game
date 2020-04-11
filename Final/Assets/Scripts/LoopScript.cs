using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopScript : MonoBehaviour
{
    public Transform fallPos;
    public Transform fallPosInverted;

    public int loopNum;
    public bool firstLoop;

    public GameObject cam;
    //Cinemachine.CinemachineVirtualCamera vcam;

    public GameObject[] collectives;
    public bool rotateCam;
    private bool invertedGravity;
    //private Rigidbody rb;

    void Start() {
        loopNum = 0;
        firstLoop = true;
        loopIsTrue = false;
        rotateCam = false;
        invertedGravity = false;
        //rb = GetComponent<Rigidbody>();
        //vcam = cam.GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }

    public bool loopIsTrue;
    public vignette vScript;
    public lensDistortion ldScript;

    void Update()
    {
        //Debug.Log("looping is" + loopIsTrue);

        if (loopIsTrue) {

            vScript.increaseVignette = true;
            ldScript.distort = true;
            loopIsTrue = false;
          
        }
        /*
        if (rotateCam) {
            //rotate the camera on Z-axis 180 degrees
            Vector3 rotateZ = new Vector3(cam.transform.rotation.x, cam.transform.rotation.y, cam.transform.rotation.z + 180);
            cam.transform.Rotate(rotateZ, 20.0f * Time.deltaTime);
            //vcam.
        }
        */

        if (invertedGravity)
        {
            Physics.gravity = Vector3.up * 9.81f *2;
        }
        else {
            Physics.gravity = Vector3.down * 9.81f *2;
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Loop_Col")) { //If player hits the trigger for looping
            firstLoop = false;
            transform.position = fallPosInverted.position;
            loopNum++;
            loopIsTrue = true;
            collectives[0].SetActive(true);
            collectives[1].SetActive(true);
            collectives[2].SetActive(true);

            rotateCam = true;
            //invert the color of the whole world
            invertedGravity = true;
        }

        if (other.CompareTag("Loop_Col_Inverted")) {
            loopIsTrue = true;
            transform.position = fallPos.position;
            invertedGravity = false;
        }
    }

}
