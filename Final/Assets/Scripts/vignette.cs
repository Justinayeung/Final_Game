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

    float incrValue;

    LoopScript loop;

    void Start()
    {
        v = GetComponent<CinemachinePostProcessing>();
        v.m_Profile.TryGetSettings<Vignette>(out vign);
        vign.intensity.value = 0;
        increaseVignette = false;

        incrValue = 0.1f;

        loop = FindObjectOfType<LoopScript>();
    }

    
    void Update()
    {
        //when a new loop starts --> increaseVignette == true

        //Debug.Log("vignette is" + increaseVignette);
        //Debug.Log(vign.intensity.value);

        if (loop.loopNum > 8)
        {

            if (increaseVignette)
            {
                vign.intensity.value += incrValue;

                increaseVignette = false;
            }

            if (incrValue > 0.3f)
            {
                incrValue = 0.03f;
            }

            if (vign.intensity.value > 0.48f)
            {
                vign.intensity.value = 0.48f;
            }

        }
    }
}
