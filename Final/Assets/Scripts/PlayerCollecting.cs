using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollecting : MonoBehaviour
{
    public float SpawningTime;

    public GameObject prefab;
    public Transform spawnPos;

    void Start()
    {
        InvokeRepeating("SpawningCube", 10f, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable")) {
            Destroy(other.gameObject);
            gameObject.transform.localScale += new Vector3(gameObject.transform.localScale.x * 1.01f, 
                                                           gameObject.transform.localScale.y * 1.01f, 
                                                           gameObject.transform.localScale.z * 1.01f);
        }
    }

    void SpawningCube() {
        GameObject a = Instantiate(prefab, spawnPos.position, spawnPos.rotation) as GameObject;
        gameObject.transform.localScale -= new Vector3(gameObject.transform.localScale.x/ 10f,
                                                           gameObject.transform.localScale.y/ 10f,
                                                           gameObject.transform.localScale.z / 10f);
    }
}
