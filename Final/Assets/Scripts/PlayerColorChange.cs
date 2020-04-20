using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChange : MonoBehaviour
{
    public Material White;
    public Material Black;
    MeshRenderer mesh;

    private void Start() {
        mesh = GetComponent<MeshRenderer>();
    }

    public void OnTriggerStay(Collider other) {
        if (other.CompareTag("Plat_Black")) { //If player is on the tag Mat_Black change player to white
            mesh.material = White;
        }
        if (other.CompareTag("Plat_White")) { //If player is on the tag Mat_White change player to black
            mesh.material = Black;
        }
    }

    public void OnTriggerEnter(Collider other){
        if (other.CompareTag("Mat_Black")) { //If player is on the tag Mat_Black change player to white
            mesh.material = White;
        }
        if (other.CompareTag("Mat_White")) { //If player is on the tag Mat_White change player to black
            mesh.material = Black;
        }
    }
}
