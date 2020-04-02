using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class lensDistortion : MonoBehaviour
{
    //When I did this for the prototype I put it on the gameobject with postprocess volume on it

    PostProcessVolume v;

    LensDistortion lensD;

    public bool distort;

    void Start()
    {
        v = GetComponent<PostProcessVolume>();
        v.profile.TryGetSettings<LensDistortion>(out lensD);
        lensD.intensity.value = 0;

        distort = false;
    }


    void Update()
    {
        //when a new loop starts --> distort == true
        if (distort)
        {
            // this setting distorts into a repeating circle thing when the value changes a lot
            lensD.intensity.value += 1; 
            lensD.scale.value -= 0.01f;

            distort = false;
        }

    }
}
