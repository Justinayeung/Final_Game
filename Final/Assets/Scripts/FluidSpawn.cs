using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidSpawn : MonoBehaviour
{
    public GameObject FluidSpawner;
    public AudioSource Button;

    private void Start() {
        FluidSpawner.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            FluidSpawner.SetActive(true);
            Button.Play();
            this.gameObject.SetActive(false);
        }
    }
}
