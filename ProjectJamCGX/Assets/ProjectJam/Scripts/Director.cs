using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    public AudioSource audio;
    float timeInterval = 0f;
    private void Update()
    {
        if (audio.volume < .155 && Time.fixedTime + 1f >= timeInterval)
        {
            timeInterval = Time.fixedTime;
            audio.volume += .001f;
        }
    }
}
