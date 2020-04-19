using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaggotTrigger : MonoBehaviour
{
    public GameObject maggots;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            maggots.SetActive(true);
        }
    }
}
