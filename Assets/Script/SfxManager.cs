using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using User257;

public class SfxManager : MonoBehaviour
{
    AudioSource audioSource;

    public static SfxManager instance;

    /*
     * if you wanna add variable of 'kid walking sound' then it'd be like 
     * 
     * public AudioClip kidWalkingSoundClip;
     * 
     * 
     */
    [HideInInspector]
    public AudioClip footStepSoundClip;
    [HideInInspector]
    public AudioClip ClassRoomAmbSoundClip;
    [HideInInspector]
    public AudioClip ClassAmbNegativeSoundClip;
    [HideInInspector]
    public AudioClip BreatheSoundClip;
    [HideInInspector]
    public AudioClip ChildrenPlayingSoundClip;
    [HideInInspector]
    public AudioClip InteractionAppearSoundClip;
    [HideInInspector]
    public AudioClip InteractionDisappearSoundClip;
    [HideInInspector]
    public AudioClip PhoneGrabSoundClip;
    [HideInInspector]
    public AudioClip ShockwavePosSoundClip;
    [HideInInspector]
    public AudioClip ShockwaveNegSoundClip;
    [HideInInspector]
    public AudioClip VolUpSoundClip;
    [HideInInspector]
    public AudioClip VolDownSoundClip;
    [HideInInspector]
    public AudioClip BareFootSoundClip;
    [HideInInspector]
    public AudioClip NightAmbSoundClip;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        #region singleton
        if (instance == null) { instance = this; }
        else { Destroy(this.gameObject); }
        #endregion

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

        if (VolUpSoundClip == null)
        {
            Debug.Log("우하하하하히");
        }
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
    public void NightAmbSoundPlay()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void BareFootSoundPlay()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void VolDownSoundPlay()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void VolUpSoundPlay()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void ShockwaveNegSoundPlay()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void ShockwavePosSoundPlay()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void PhoneGrabSoundPlay()
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

    public void ClassAmbNegativeSoundPlay()
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
