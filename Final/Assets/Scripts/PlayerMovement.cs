using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    Vector3 movement;
    Rigidbody rb;

    public AudioSource _audio;
    public AudioClip walkSound;

    public LoopScript inverted;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("PlaySound", 0.0f, 0.5f);
        inverted = GetComponent<LoopScript>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (inverted.rotateCam)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //move right
                rb.velocity = Vector3.right * speed;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //move left
                rb.velocity = -Vector3.right * speed;
            }
            if (Input.GetKey(KeyCode.UpArrow)) {
                rb.velocity = Vector3.forward * speed;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.velocity = -Vector3.forward * speed;
            }
        }
        else {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");

            Vector3 movement = new Vector3(moveHorizontal * speed, rb.velocity.y, moveVertical * speed);
            rb.velocity = movement;
        }
        */

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal * speed, rb.velocity.y, moveVertical * speed);
        rb.velocity = movement;

    }

    void PlaySound()
    {
        if(Input.GetButton("Vertical")|| Input.GetButton("Horizontal") || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
           _audio.pitch = Random.Range(.85f, 1.15f);
           _audio.PlayOneShot(walkSound);
        }
    }
}
