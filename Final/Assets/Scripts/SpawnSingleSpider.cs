using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSingleSpider : MonoBehaviour
{
    public GameObject Spider;

    void Awake() {
        Spider.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            Spider.SetActive(true);
        }
    }
}
