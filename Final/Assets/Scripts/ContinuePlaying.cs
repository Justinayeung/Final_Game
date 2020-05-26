using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinuePlaying : MonoBehaviour
{
    public GameObject MainCam;
    public GameObject CMCam;
    public GameObject QuitArea;
    public GameObject QuitAreaUpsideDown;
    public GameObject player;
    LoopScript loopScript;

    public Animator transition;
    public Image fadeIn;

    public void Start()
    {
        loopScript = FindObjectOfType<LoopScript>();
    }

    private void OnTriggerEnter(Collider other) { //Return to game
        if (other.gameObject.CompareTag("Player") && !loopScript.rotateCam) {
            StartCoroutine(QATransition());

        }

        if (other.gameObject.CompareTag("Player") && loopScript.rotateCam){
            StartCoroutine(QAUDTransition());
        }
    }

    IEnumerator QATransition() {
        transition.SetBool("ToBlack", true);
        yield return new WaitUntil(() => fadeIn.color.a == 1); //Wait until image is fully black/can be seen
        MainCam.SetActive(true);
        CMCam.SetActive(true);
        player.transform.position = new Vector3(1438.9f, 1f, 0f);
        QuitArea.SetActive(false);
        transition.SetBool("ToBlack", false);
    }

    IEnumerator QAUDTransition() {
        transition.SetBool("ToBlack", true);
        yield return new WaitUntil(() => fadeIn.color.a == 1); //Wait until image is fully black/can be seen
        MainCam.SetActive(true);
        CMCam.SetActive(true);
        player.transform.position = new Vector3(1438.9f, 1f, 0f);
        QuitAreaUpsideDown.SetActive(false);
        transition.SetBool("ToBlack", false);
    }
}
