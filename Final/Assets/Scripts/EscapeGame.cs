using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeGame : MonoBehaviour
{
    public Animator OpeningDoor;
    public Animator WordFade;

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")) {
            OpeningDoor.SetTrigger("Open");
            WordFade.SetTrigger("FadeIn");
        }
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            OpeningDoor.SetTrigger("Close");
            WordFade.SetTrigger("FadeOut");
        }
    }
}
