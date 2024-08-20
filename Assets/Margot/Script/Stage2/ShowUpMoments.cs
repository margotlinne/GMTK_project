using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Margot
{
    public class ShowUpMoments : MonoBehaviour
    {
        Animator anim;
        public StageTwoManager manager;

        void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void ShowingUpMoment()
        {
            anim.SetTrigger("ShowUp");
        }

        public void UnFreeze()
        {
            manager.freeze = false;
        }
    }

}

