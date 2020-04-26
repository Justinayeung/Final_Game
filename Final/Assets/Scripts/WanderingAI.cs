using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderingAI : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    // Use this for initialization
    void OnEnable() {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;

        if (timer >= wanderTimer) { //Wander for a certain time and then pick a new location
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1); //-1 (layermask) means all layers
            agent.SetDestination(newPos); //Setting AI destination
            timer = 0; //Reset timer
        }
    }

    /// <summary>
    /// Return a random point on Navmesh within a given distance from the origin point
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="distance"></param>
    /// <param name="layermask"></param>
    /// <returns></returns>
    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask) {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance; //Get random location within distance
        randomDirection += origin; //Random location from origin
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);
        return navHit.position; //Return that random point
    }
}
