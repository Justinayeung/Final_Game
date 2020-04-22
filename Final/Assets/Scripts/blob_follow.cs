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

    void Start()
    {
        loop = FindObjectOfType<LoopScript>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        Debug.Log(loop.loopNum);

        if (loop.loopNum > 1)
        { 
            agent.SetDestination(player.position);
            anim.SetBool("follow", true);
        }
    }
}
