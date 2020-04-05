using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    Vector3 movement;
    Rigidbody rb;

    public AudioSource audio;
    public AudioClip walkSound;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("PlaySound", 0.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal * speed, rb.velocity.y, moveVertical * speed);
        rb.velocity = movement;
 
    }

    void PlaySound()
    {
        if(Input.GetButton("Vertical")|| Input.GetButton("Horizontal"))
        {
           audio.pitch = Random.Range(.85f, 1.15f);
            audio.PlayOneShot(walkSound);
        }
    }
}
