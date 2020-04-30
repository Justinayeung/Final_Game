using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuePlaying : MonoBehaviour
{
    public GameObject MainCam;
    public GameObject CMCam;
    public GameObject QuitArea;
    public GameObject player;

    private void OnTriggerEnter(Collider other) { //Return to game
        if (other.gameObject.CompareTag("Player")) {
            MainCam.SetActive(true);
            CMCam.SetActive(true);
            player.transform.position = new Vector3(1096.5f, 1f, 0f);
            QuitArea.SetActive(false);
        }
    }
}
