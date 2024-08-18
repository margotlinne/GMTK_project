using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Margot
{
    public class InteractionBox : MonoBehaviour
    {
        Animator anim;

        void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void Disappearing()
        {
            anim.SetTrigger("Interacted");
        }

        public void Inactive()
        {
            gameObject.SetActive(false);
        }
    }
}

