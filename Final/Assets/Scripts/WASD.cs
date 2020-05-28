using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WASD : MonoBehaviour
{
    public Animator WASDkeys;

    private void Awake() {
        WASDkeys.SetBool("Shown", true);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) {
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut() {
        yield return new WaitForSeconds(1f);
        WASDkeys.SetBool("Shown", false);
    }
}
