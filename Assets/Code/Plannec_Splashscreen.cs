using System;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(AudioSource))]
public class Plannec_Splashscreen : MonoBehaviour {

    public MovieTexture movie;
    private AudioSource audio;

    void Start()
    {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;

        movie.Play();
        audio.Play();

        Debug.Log(movie.duration);
    }

    void Update()
    {
        try
        {
            if (!movie.isPlaying)
            {
                Application.LoadLevel(1);
            }
        }
        catch (UnassignedReferenceException e)
        { }
        catch(NullReferenceException e1)
        { }
    }
}
