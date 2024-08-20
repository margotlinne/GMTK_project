using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    AudioSource audioSource;

    /*
     * if you wanna add variable of 'kid walking sound' then it'd be like 
     * 
     * public AudioClip kidWalkingSoundClip;
     * 
     * 
     */

    void Awake()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }

    void Start()
    {
        /*
         * if the audio file name is 'kidwalking.wav' then it should be 
         * 
         * kidWalkingSoundClip = Resources.Load<AudioClip>("kidwalking");
         
         */
    }

    /*
     * keep the form of ~SoundPlay 
     * 
     * public void KidWalkingSoundPlay()
     * {
     *   audioSource.PlayOneShot("kidWalkingSoundClip");
     * }
     * 
     */


}
