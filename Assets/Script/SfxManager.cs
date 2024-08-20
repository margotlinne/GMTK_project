using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using User257;

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

    public AudioClip footStepSoundClip;

    public AudioClip ClassRoomAmbSoundClip;

    public AudioClip ClassAmbNegativeSoundClip;

    public AudioClip BreatheSoundClip;

    public AudioClip ChildrenPlayingSoundClip;

    public AudioClip InteractionAppearSoundClip;

    public AudioClip InteractionDisappearSoundClip;

    public AudioClip PhoneGrabSoundClip;

    public AudioClip ShockwavePosSoundClip;

    public AudioClip ShockwaveNegSoundClip;

    public AudioClip VolUpSoundClip;

    public AudioClip VolDownSoundClip;

    public AudioClip BareFootSoundClip;

    public AudioClip NightAmbSoundClip;

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

        footStepSoundClip = Resources.Load<AudioClip>("Stage2/Sfx_Ftstp_01");

        ClassRoomAmbSoundClip = Resources.Load<AudioClip>("Stage2/Amb_Classroom");

        ClassAmbNegativeSoundClip = Resources.Load<AudioClip>("Stage2/Amb_Classroom_Negative");

        BreatheSoundClip = Resources.Load<AudioClip>("Stage2/Dx_Breathing");

        ChildrenPlayingSoundClip = Resources.Load<AudioClip>("Stage2/Amb_ChildernPlaying");

        InteractionAppearSoundClip = Resources.Load<AudioClip>("Stage2/Sfx_Interaction_Appear");

        InteractionDisappearSoundClip = Resources.Load<AudioClip>("Stage2/Sfx_Interaction_Disappear");

        PhoneGrabSoundClip = Resources.Load<AudioClip>("Stage2/Sfx_PhoneGrab");

        ShockwavePosSoundClip = Resources.Load<AudioClip>("Stage2/Sfx_ShockwavePositive");

        ShockwaveNegSoundClip = Resources.Load<AudioClip>("Stage2/Sfx_Shockwave_Negative");

        VolUpSoundClip = Resources.Load<AudioClip>("Stage2/Sfx_Vol_Up");

        VolDownSoundClip = Resources.Load<AudioClip>("Stage2/Sfx_Vol_Down");

        BareFootSoundClip = Resources.Load<AudioClip>("Stage1/Sfx_BareFtstp_01");

        NightAmbSoundClip = Resources.Load<AudioClip>("Stage1/Amb_Night");
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
    public void NightAmb()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void BareFoot()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void VolDown()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void VolUp()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void ShockwaveNeg()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void ShockwavePos()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void PhoneGrab()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void footStepSoundPlay()
    {
        audioSource.PlayOneShot(footStepSoundClip);
    }

    public void ClassRoomAmbSoundPlay()
    {
        audioSource.PlayOneShot(ClassRoomAmbSoundClip);
    }

    public void ClassAmbNegative()
    {
        audioSource.PlayOneShot(ClassAmbNegativeSoundClip);
    }

    public void BreatheSoundPlay() 
    {
        audioSource.PlayOneShot(BreatheSoundClip);
    }

    public void ChildrenPlayingSoundPlay()
    {
        audioSource.PlayOneShot(ChildrenPlayingSoundClip);
    }

    public void InteractionAppearSoundPlay()
    {
        audioSource.PlayOneShot(InteractionAppearSoundClip);
    }

    public void InteractionDisappearSoundPlay()
    {
        audioSource.PlayOneShot(InteractionDisappearSoundClip);
    }


}
