using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Margot
{
    public class PhoneAnim : MonoBehaviour
    {
        Animator anim;

        void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void VolumeUpAnimation()
        {
            anim.SetTrigger("VolumeUp");
        }

        public void VolumeDownAnimation()
        {
            anim.SetTrigger("VolumeDown");
        }
    }
}

