using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChange : MonoBehaviour
{
    Renderer rend;

    private void Start() {
        rend = GetComponent<Renderer>();
    }

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Mat_Black")) { //If player is on the tag Mat_Black change player to white
            rend.material.SetColor("_Color", Color.white);
        }
        if (other.CompareTag("Mat_White")) { //If player is on the tag Mat_White change player to black
            rend.material.SetColor("_Color", Color.black);
        }
    }
}
