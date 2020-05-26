using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript_Test : MonoBehaviour
{
    private Rigidbody rb;
    public float torqueAmt = 50f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        rb.AddTorque(-Vector3.forward * moveHorizontal * torqueAmt * Time.deltaTime, ForceMode.VelocityChange);
        rb.AddTorque(Vector3.right * moveVertical * torqueAmt * Time.deltaTime, ForceMode.VelocityChange);
    }
}
