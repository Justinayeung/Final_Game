using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    public float throwForce = 600f; //Deternmine how far object will be thrown
    public bool isHolding = false;

    GameObject item;
    Vector3 objPos;
    float distance; //How far object has to be to pick it up

    // Update is called once per frame
    void Update(){
        AllowDistance();
        Throw();
    }

    private void OnTriggerEnter(Collider other) { //If other gameobject is named BounceCube
        if (other.CompareTag("BounceCube")) {
            isHolding = true;
            item = other.gameObject; //Item is set equal to that gameobject
            item.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
            item.GetComponent<Rigidbody>().useGravity = false; //Turn off gravity
        }
    }

    /// <summary>
    /// If player gets too far away from the object drop it
    /// </summary>
    void AllowDistance() {
        distance = Vector3.Distance(item.transform.position, transform.position); //Distance between tempParent and held item
        if (distance >= 2.5f) {
            isHolding = false;
            item.GetComponent<Rigidbody>().useGravity = true; //Turn gravity back on
        }
    }

    /// <summary>
    /// Throw object that you picked up
    /// </summary>
    void Throw() {
        if (Input.GetButtonUp("Jump") && isHolding) { //If spacebar is released and isHolding is true
            item.GetComponent<Rigidbody>().useGravity = true; //Turn gravity back on
            item.GetComponent<Rigidbody>().AddForce(Vector3.up * throwForce, ForceMode.Impulse);
            isHolding = false;
        }
    } 
}
