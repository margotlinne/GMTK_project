using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Choi
{
    public class Toy_Interaction : MonoBehaviour
    {
        public GameObject shelf_Toy;
        public bool activate = false;
        Transform handPos;

        bool holding = false;

        void Start()
        {
            handPos = GetComponentInParent<Toy_Manager>().player_Hand;
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (activate && !holding && !handPos.GetComponentInParent<PlayerController_st1>().hold) GetComponent<SpriteOutline>().outlineSize = 1;
            else return;
        }

        void OnTriggerStay2D(Collider2D collision)
        {
            if(activate && handPos.childCount == 0 && !holding && Input.GetKeyDown(KeyCode.E))
            {
                holding = true;
                transform.position = handPos.position;
                transform.parent = null;
                transform.parent = handPos;
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            GetComponent<SpriteOutline>().outlineSize = 0;
        }
    }
}