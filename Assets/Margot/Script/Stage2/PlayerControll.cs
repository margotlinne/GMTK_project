using Margot;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Margot
{
    public class PlayerControll : MonoBehaviour
    {
        Rigidbody2D rb;
        Animator anim;

        [SerializeField]
        float speed;

        [SerializeField]
        bool isWalking;

        bool gameStarted = false;

        public StageTwoManager manager;
        public GameObject footStepSoundObj;
        public GameObject breathingSoundObj;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            if (manager.pickedUpPhone && !gameStarted)
            {
                anim.SetTrigger("StartedGame");
                gameStarted = true;
            }

            if (gameStarted && !manager.freeze)
            {
                float moveInput = Input.GetAxisRaw("Horizontal");
                anim.SetFloat("Vertical", moveInput);

                rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

                //Debug.Log(rb.velocity);


                if (moveInput != 0)
                {
                    // [sound] footstep

                    isWalking = true;
                    anim.SetBool("Walking", true);
                    StartFootStepSound();
                }
                else
                {
                    isWalking = false;
                    anim.SetBool("Walking", false);
                    StopFootStepSound();
                }    

            }

            if (manager.showBox)
            {
                KeyCode keycode = GetKeyCodeFromString(manager.interactKey);

                if (keycode != KeyCode.None && Input.GetKeyDown(keycode))
                {
                    Debug.Log("work");
                    manager.interacted = true;
                }
            }



            if (manager.interactingWNegativeLight)
            {
                anim.SetBool("Shivering", true);
                breathingSoundObj.SetActive(true);
                manager.freeze = true;
            }
            else
            {
                anim.SetBool("Shivering", false);
                breathingSoundObj.SetActive(false);
                manager.freeze = false;
            }

        }


        KeyCode GetKeyCodeFromString(string key)
        {
            KeyCode keyCode;

            if (System.Enum.TryParse(key.ToUpper(), out keyCode))
            {
                return keyCode;
            }
            return KeyCode.None; // ��ȿ���� ���� Ű �ڵ�

        }

        void StopFootStepSound()
        {
            footStepSoundObj.SetActive(false);
        }

        void StartFootStepSound()
        {
            footStepSoundObj.SetActive(true);
        }
    }
}

