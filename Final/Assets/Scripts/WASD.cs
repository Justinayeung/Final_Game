using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WASD : MonoBehaviour
{
    public Image fadeIm; //Image for black screen fade
    public Animator WASDkeys;
    bool newPlayer;

    private void Awake()
    {
        newPlayer = true;
    }

    void Update()
    {
        if (fadeIm.color.a == 0 && newPlayer) {
            WASDkeys.SetBool("Shown", true);
            newPlayer = false;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) {
            WASDkeys.SetBool("Shown", false);
        }
    }
}
