using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quitGame : MonoBehaviour
{
    public GameObject MainCam;
    public GameObject CMCam;
    public GameObject QuitArea;
    public GameObject QuitAreaUpsideDown;
    LoopScript loopScript;

    public Animator transition;
    public Image fadeIn;

    // Start is called before the first frame update
    void Start() {
        transition.SetBool("ToBlack", false);
        loopScript = FindObjectOfType<LoopScript>();
        MainCam.SetActive(true);
        CMCam.SetActive(true);
        QuitArea.SetActive(false);
        QuitAreaUpsideDown.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !loopScript.rotateCam) { //Pause menu for Quit Area
            StartCoroutine(QATransition());
        }

        if (Input.GetKeyDown(KeyCode.Escape) && loopScript.rotateCam) { //Pause menu for Quit Area when upside down
            StartCoroutine(QAUDTransition());
        }
    }

    IEnumerator QATransition() {
        transition.SetBool("ToBlack", true);
        yield return new WaitUntil(() => fadeIn.color.a == 1); //Wait until image is fully black/can be seen
        MainCam.SetActive(false);
        CMCam.SetActive(false);
        QuitArea.SetActive(true);
        transition.SetBool("ToBlack", false);
    }

    IEnumerator QAUDTransition() {
        transition.SetBool("ToBlack", true);
        yield return new WaitUntil(() => fadeIn.color.a == 1); //Wait until image is fully black/can be seen
        MainCam.SetActive(false);
        CMCam.SetActive(false);
        QuitAreaUpsideDown.SetActive(true);
        transition.SetBool("ToBlack", false);
    }
}
