using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    public bool spawned;
    public NavMeshAgent agent;
    public Transform player;
    public GameObject monster;
    LoopScript loop;

    // Start is called before the first frame update
    void Start() {
        monster.SetActive(false);
        loop = FindObjectOfType<LoopScript>();
    }

    // Update is called once per frame
    void Update() {

        if (loop.loopNum >= 1 || spawned) { //loopNum is >= 1, agent will start moving towards player
            monster.SetActive(true);
            agent.SetDestination(player.position);
        }
    }     
}
