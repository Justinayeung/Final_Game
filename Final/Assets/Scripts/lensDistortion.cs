using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using Cinemachine.PostFX;

public class lensDistortion : MonoBehaviour
{
    //put this on virtual cam with cineMachine postProcessing extension

    CinemachinePostProcessing v;
    LensDistortion lensD;

    public bool distort;

    void Start()
    {

        v = GetComponent<CinemachinePostProcessing>();
        v.m_Profile.TryGetSettings<LensDistortion>(out lensD);
        lensD.intensity.value = 0;
        lensD.scale.value = 1f;

        distort = false;
    }


    void Update()
    {
        //Debug.Log("lens distort is" + distort);
        //Debug.Log(lensD.intensity.value);

        if (distort)
        {
            // this setting distorts into a repeating circle thing when the value changes a lot
            lensD.intensity.value += 5; 
            lensD.scale.value -= 0.05f;

            distort = false;
        }

        if (lensD.intensity.value > 90)
        {
            lensD.intensity.value = 90;
        }

    }
}
