using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using Cinemachine.PostFX;

public class vignette : MonoBehaviour
{
    CinemachinePostProcessing v;
    Vignette vign;

    public bool increaseVignette;

    void Start()
    {
        v = GetComponent<CinemachinePostProcessing>();
        v.m_Profile.TryGetSettings<Vignette>(out vign);
        vign.intensity.value = 0;
        increaseVignette = false;
    }

    
    void Update()
    {
        //when a new loop starts --> increaseVignette == true

        if (increaseVignette)
        {
            vign.intensity.value += 0.02f;

            increaseVignette = false;
        }
    }
}
