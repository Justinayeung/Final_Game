﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadScene : MonoBehaviour
{

    public Animator transition;
    public Image fadeIm;
   
    void Update()
    {
        
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            StartCoroutine(LoadingScene(SceneManager.GetActiveScene().buildIndex + 1));


        }
       }

    public void loadGame()
    {

        StartCoroutine(LoadingScene(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator LoadingScene(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitUntil(() => fadeIm.color.a == 1); //Wait until image is fully black/can be seen
        SceneManager.LoadScene(levelIndex);
    }

   

}
