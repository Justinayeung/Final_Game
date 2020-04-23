using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaggotTrigger : MonoBehaviour
{
    public GameObject[] maggots;
    public LoopScript loop;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && loop.loopNum == 0)
        {
            maggots[0].SetActive(true);
            
        }
        if (other.gameObject.CompareTag("Player") && loop.loopNum == 1)
        {
            maggots[0].SetActive(false);
        }
        if (other.gameObject.CompareTag("Player") && loop.loopNum == 2) {
            maggots[1].SetActive(true);
            maggots[0].SetActive(false);
            Destroy(gameObject);
        }
    }
}
