using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoopScript : MonoBehaviour
{
    public Transform fallPos;
    public Transform fallPosInvert;

    public int loopNum;
    public bool firstLoop;

    public GameObject cam;
    CinemachineCameraOffset camOff;

    public bool rotateCam;

    public bool loopIsTrue;
    public vignette vScript;
    public lensDistortion ldScript;

    public Animator transition;
    public Image fadeIm;

    public GameObject loopCol;
    public GameObject endingCol;
    bool endingCamOffset;
    public Animator credit;

    void Start() {
        loopNum = 0;
        firstLoop = true;
        loopIsTrue = false;
        rotateCam = false;
        camOff = cam.GetComponent<CinemachineCameraOffset>();
        loopCol.SetActive(true);
        endingCol.SetActive(false);
        endingCamOffset = false;
    }

    void Update()
    {

        if (loopIsTrue)
        {
            vScript.increaseVignette = true;
            ldScript.distort = true;
            loopIsTrue = false;
        }

        if (rotateCam)
        {
            //rotate the camera on Z-axis 180 degrees           
            //cam.transform.rotation = Quaternion.Euler(-12f, 1f, 180);
            cam.transform.rotation = Quaternion.Euler(-10f, 1f, 0);
            camOff.m_Offset = new Vector3(-2.3f, -3f, 1f);
            Physics.gravity = new Vector3(0, 9.81F, 0);
        }
        else
        {
            cam.transform.rotation = Quaternion.Euler(12f, 1f, 0);
            camOff.m_Offset = new Vector3(2.3f, 1f, 1f);
            Physics.gravity = new Vector3(0, -9.81F, 0);
        }
        /*
        if (loopNum >= 14)
        {
            StartCoroutine(LoadingScene(0));
        }
        */
        if (loopNum == 13)
        {
            loopCol.SetActive(false);
            endingCol.SetActive(true);
        }
        if (endingCamOffset)
        {
            Camera.main.backgroundColor = Color.black;
            Physics.gravity = new Vector3(0, -0F, 0);
            camOff.m_Offset = new Vector3(5.49f, 1f, 1f);
            credit.SetTrigger("CreditStart");
            StartCoroutine(LoadingScene(0));
        }
    }

        public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Loop_Col")) { //If player hits the trigger for looping
            rotateCam = true;
            firstLoop = false;
            transform.position = fallPosInvert.position;
            loopIsTrue = true;
            loopNum++;
        }

        if (other.CompareTag("Loop_Col_Invert"))
        {
            rotateCam = false;
            transform.position = fallPos.position;
            loopIsTrue = true;
            loopNum++;
        }
        if (other.CompareTag("EndingCollider")) {
            endingCamOffset = true;
        }
    }

    IEnumerator LoadingScene(int levelIndex)
    {
        yield return new WaitForSeconds(20f);
        transition.SetTrigger("Start");
        Physics.gravity = new Vector3(0, -9.81F, 0);
        yield return new WaitUntil(() => fadeIm.color.a == 1); //Wait until image is fully black/can be seen
        SceneManager.LoadScene(levelIndex);
    }

}
