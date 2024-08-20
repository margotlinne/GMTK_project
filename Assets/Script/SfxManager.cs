using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

        footStepSoundClip = Resources.Load<AudioClip>("Sfx_Ftstp_01");

        ClassRoomAmbSoundClip = Resources.Load<AudioClip>("Amb_Classroom");

        ClassAmbNegativeSoundClip = Resources.Load<AudioClip>("Amb_Classroom_Negative");

        BreatheSoundClip = Resources.Load<AudioClip>("Dx_Breathing");

        ChildrenPlayingSoundClip = Resources.Load<AudioClip>("Amb_ChildernPlaying");

        InteractionAppearSoundClip = Resources.Load<AudioClip>("Sfx_Interaction_Appear");

        InteractionDisappearSoundClip = Resources.Load<AudioClip>("Sfx_Interaction_Disappear");

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
