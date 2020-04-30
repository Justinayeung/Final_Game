using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSpiderDoor : MonoBehaviour
{
    public Animator Door;
    public AudioSource button;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Door.SetTrigger("Open");
            button.Play();
            this.gameObject.SetActive(false);
        }
    }
}
