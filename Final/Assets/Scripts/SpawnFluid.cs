using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFluid : MonoBehaviour
{
    public GameObject FluidSpawner;
    bool once = false;

    private void Start() {
        FluidSpawner.SetActive(false);
    }
    private void OnTriggerEnter(Collider other) { //Turn on fluid
        if(other.CompareTag("Player") && !once) {
            FluidSpawner.SetActive(true);
            once = true;
            this.gameObject.SetActive(false);
        }
    }
}
