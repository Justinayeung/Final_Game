using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController1 : MonoBehaviour
{
    public bool spawned;
    public NavMeshAgent agent;
    public Transform player;
    public GameObject monster;
    EnterMagHall mHall;

    // Start is called before the first frame update
    void Start() {
        monster.SetActive(false);
        mHall = FindObjectOfType<EnterMagHall>();
    }

    // Update is called once per frame
    void Update() {

        if (mHall.MagHallenabled || spawned) { //If player entered the mag hall, agent will start moving towards player
            monster.SetActive(true);
            agent.SetDestination(player.position);
        }
    }     
}
