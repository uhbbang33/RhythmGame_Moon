using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sync : MonoBehaviour
{
    [SerializeField] float musicBPM;
    float stdBPM = 60f;
    [SerializeField] int musicTempo;
    int stdTempo = 4;

    float nextTime = 0f;
    float beepTime;

    AudioSource shortMetronome;

    void Start()
    {
        shortMetronome = GetComponent<AudioSource>();
    }

    void Update()
    {
        beepTime = (stdBPM / musicBPM) * (musicTempo / stdTempo);

        nextTime += Time.deltaTime;
        Debug.Log(Time.time);
        if(nextTime > beepTime)
        {
            //Debug.Log(nextTime);
            shortMetronome.Play();
            nextTime = 0;
        }
    }
}
