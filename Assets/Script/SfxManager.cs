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
        audioSource.PlayOneShot(NightAmbSoundClip);
    }

    public void BareFootSoundPlay()
    {
        audioSource.PlayOneShot(BareFootSoundClip);
    }

    public void VolDownSoundPlay()
    {
        audioSource.PlayOneShot(VolUpSoundClip);
    }

    public void VolUpSoundPlay()
    {
        audioSource.PlayOneShot(VolUpSoundClip);
    }

    public void ShockwaveNegSoundPlay()
    {
        audioSource.PlayOneShot(ShockwaveNegSoundClip);
    }

    public void ShockwavePosSoundPlay()
    {
        audioSource.PlayOneShot(ShockwavePosSoundClip);
    }

    public void PhoneGrabSoundPlay()
    {
        audioSource.PlayOneShot(PhoneGrabSoundClip);
    }

    public void footStepSoundPlay()
    {
        audioSource.PlayOneShot(footStepSoundClip);
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
