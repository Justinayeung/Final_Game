using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayStop : MonoBehaviour
{
    public AudioSource Door;

    public void AudioPlay() {
        Door.Play();
    }

    public void AudioStop() {
        Door.Stop();
    }
}
