using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClips : MonoBehaviour
{
    [SerializeField]
    AudioClip charge;



    [SerializeField]
    AudioClip bearStep;
    

    [SerializeField]
    AudioClip bearUlti;



    [SerializeField]
    AudioClip bearHit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayBearStep()
    {
        AudioSource asourse = this.GetComponent<AudioSource>();
        asourse.loop = true;
        asourse.clip = bearStep;
        asourse.Play();
    }
    public void StopPlay()
    {
        this.GetComponent<AudioSource>().Stop();
    }
    public void PlayCharge()
    {
        AudioSource asource = this.GetComponent<AudioSource>();
        asource.loop = false;
        asource.clip = charge;
        asource.Play();
    }
    public void PlayBearHit()
    {
        AudioSource asource = this.GetComponent<AudioSource>();
        asource.loop = false;
        asource.clip = bearHit;
        asource.Play();
    }
    public void PlayBearUlti()
    {
        AudioSource asource = this.GetComponent<AudioSource>();
        asource.loop = false;
        asource.clip = bearUlti;
        asource.Play();
    }
}
