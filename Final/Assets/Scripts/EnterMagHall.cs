using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterMagHall : MonoBehaviour
{
    public Animator hallClosed;
    public Animator hallClosed2;
    public bool MagHallenabled;

    // Start is called before the first frame update
    void Start() {
        MagHallenabled = false;
        hallClosed.SetBool("Close", false);
        hallClosed2.SetBool("Close", false);
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Mag_Hall")) {
            hallClosed.SetBool("Close", true);
            hallClosed2.SetBool("Close", true);
        }
    }
}
