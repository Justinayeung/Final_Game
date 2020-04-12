using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollecting : MonoBehaviour
{
    public float SpawningTime;

    public GameObject prefab;
    public Transform spawnPos;

    public AudioSource _audio;
    public AudioClip cSound;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable")) {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            StartCoroutine(CubeGettingBiggerAnim());
            _audio.pitch = 0.8f;
            _audio.PlayOneShot(cSound);                     
        }

        if (other.gameObject.CompareTag("Maggot")) {
            other.gameObject.SetActive(false);
            SpawningCube();

        }
    }

    void SpawningCube() {
        GameObject a = Instantiate(prefab, spawnPos.position, spawnPos.rotation) as GameObject;
        StartCoroutine(CubeGettingSmallerAnim());
        _audio.pitch = 1.5f;
        _audio.PlayOneShot(cSound);
    }

    IEnumerator CubeGettingBiggerAnim() {
        gameObject.transform.localScale += new Vector3(gameObject.transform.localScale.x * 0.3f,
                                                           gameObject.transform.localScale.y * 0.3f,
                                                           gameObject.transform.localScale.z * 0.3f);

        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator CubeGettingSmallerAnim()
    {
        gameObject.transform.localScale -= new Vector3(gameObject.transform.localScale.x * 0.25f,
                                                           gameObject.transform.localScale.y * 0.25f,
                                                           gameObject.transform.localScale.z * 0.25f);
        yield return new WaitForSeconds(0.5f);
    }
}
