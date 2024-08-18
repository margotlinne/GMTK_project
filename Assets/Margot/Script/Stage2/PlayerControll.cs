using Margot;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace stageTwo
{
    public class PlayerControll : MonoBehaviour
    {
        Rigidbody2D rb;
        [SerializeField]
        float speed;

        public StageTwoManager manager;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (manager.pickedUpPhone)
            {
                float moveInput = Input.GetAxisRaw("Horizontal");
                rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            }
            else if (manager.showBox)
            {
                KeyCode keycode = GetKeyCodeFromString(manager.interactKey);

                if (keycode != KeyCode.None && Input.GetKeyDown(keycode))
                {
                    Debug.Log("work");
                    manager.interacted = true;
                }
            }
        }

        void CheckInteractionKey(string val)
        {
            if (val == "E")
            {

            }
        }
        

        KeyCode GetKeyCodeFromString(string key)
        {
            KeyCode keyCode;

            if (System.Enum.TryParse(key.ToUpper(), out keyCode))
            {
                return keyCode;
            }
            return KeyCode.None; // 유효하지 않은 키 코드

        }
    }
}

