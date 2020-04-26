using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpider : MonoBehaviour
{
    public List<GameObject> _Spider;

    void Awake() {
        for (int i = 0; i < _Spider.Count; i++) { //Set all object in _Spider to false
            _Spider[i].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            for (int i = 0; i < _Spider.Count; i++) { //Set all object in _Spider to true
                _Spider[i].SetActive(true);
            }

            this.gameObject.SetActive(false);
        }
    }
}
