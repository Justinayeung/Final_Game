using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class blob_follow : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    LoopScript loop;
    Animator anim;
    AudioSource aud;

    void Start()
    {
        loop = FindObjectOfType<LoopScript>();
        anim = gameObject.GetComponent<Animator>();
        aud = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (loop.loopNum > 3)
        { 
            agent.SetDestination(player.position);
            anim.SetBool("follow", true);
            aud.Play();
        }
    }
}
