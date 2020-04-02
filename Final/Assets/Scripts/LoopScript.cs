using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopScript : MonoBehaviour
{
    public Transform fallPos;

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Loop_Col")) {
            transform.position = fallPos.position;
        }
    }
}
