using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Margot
{
    public class PhoneKeyCode : MonoBehaviour
    {
        public bool isNumberOne;
        public StageTwoManager manager;


        public GameObject downBtnBox;

        Animator anim;

        void Awake()
        {
            anim = GetComponent<Animator>();
        }

        void Start()
        {
            if (isNumberOne)
            {
                gameObject.SetActive(false);
            }
        }

        void Update()
        {
            if (manager.pickedUpPhone)
            {
                if (isNumberOne && Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Disappearing();
                }
                else if (!isNumberOne && Input.GetKeyDown(KeyCode.Alpha2))
                {
                    downBtnBox.SetActive(true);
                    Disappearing();

                }
            }

            
        }

        public void Disappearing()
        {
            anim.SetTrigger("Disappear");
        }

        public void DestroyThisBox()
        {
            Destroy(gameObject);
        }
    }

}
