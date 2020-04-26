using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaggotScript : MonoBehaviour
{
    private float waitTime;
    public Animator anim;

    //public AudioSource maggotSound;
    //public GameObject player;
    //public float distToMaggot;

    void Start()
    {
        anim = GetComponent<Animator>();
        waitTime = Random.Range(1f, 5f);

       // maggotSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(States());
        /*
        distToMaggot = Vector3.Distance(transform.position, player.transform.position);

        if (distToMaggot <= 4)
        {
            maggotSound.Play();
        }

        if (distToMaggot > 4)
        {
            maggotSound.Stop();
        }
        */
    }
    IEnumerator States() {
        yield return new WaitForSeconds(waitTime);
        anim.SetBool("Move", true);
        transform.position += transform.forward * Time.deltaTime * 0.4f;
        yield return new WaitForSeconds(waitTime);
        transform.Rotate(0, 0.2f, 0, Space.Self);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Move", false);
        yield return new WaitForSeconds(waitTime);
    }

}
