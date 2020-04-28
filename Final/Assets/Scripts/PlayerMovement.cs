using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Variables")]
    public float speed;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    [Range(1, 10)]
    public float jumpVelocity;
    bool canJump;
    bool inWeb;

    [Header("References")]
    public AudioSource _audio;
    public AudioClip walkSound;
    public LoopScript loopScript;
    Vector3 movement;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("PlaySound", 0.0f, 0.5f);
        loopScript = GetComponent<LoopScript>();
        Cursor.visible = false;
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

        //Jump
        if (canJump) {
            if (Input.GetButtonDown("Jump")) {
                rb.velocity = Vector3.up * jumpVelocity; //Add velocity downwards
            }
        }

        //Faster Falling
        if (rb.velocity.y > 0) { //If vertical motion is less then 0 (falling)
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime; //Apply fall multiplier
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) { //If jumping and if button not held = low jump
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (inWeb) { //If in spider web slow down
            speed = 4f;
        } else {
            speed = 8f;
        }
    }

    void PlaySound()
    {
        if(Input.GetButton("Vertical")|| Input.GetButton("Horizontal") || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
           _audio.pitch = Random.Range(.85f, 1.15f);
           _audio.PlayOneShot(walkSound);
        }
    }

    private void OnCollisionEnter(Collision other) { //If on ground, canJump = true
        if (other.gameObject.CompareTag("Plat_Black")|| other.gameObject.CompareTag("Plat_White") || other.gameObject.CompareTag("Ground")) {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision other) { //If off ground, canJump = false
        if (other.gameObject.CompareTag("Plat_Black") || other.gameObject.CompareTag("Plat_White") || other.gameObject.CompareTag("Ground")) {
            canJump = false;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("SpiderWeb")) { //Check if player is in spider web
            inWeb = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("SpiderWeb")) { //Check if player is not in spider web
            inWeb = false;
        }
    }
}
