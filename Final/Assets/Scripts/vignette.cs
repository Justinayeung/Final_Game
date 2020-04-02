using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class vignette : MonoBehaviour
{
    PostProcessVolume v;
    Vignette vign;

    public bool increaseVignette;

    void Start()
    {
        v = GetComponent<PostProcessVolume>();
        v.profile.TryGetSettings<Vignette>(out vign);
        vign.intensity.value = 0.05f;
        increaseVignette = false;
    }

    
    void Update()
    {
        //when a new loop starts --> increaseVignette == true

        if (increaseVignette)
        {
            vign.intensity.value += 0.05f;

            increaseVignette = false;
        }
    }
}
