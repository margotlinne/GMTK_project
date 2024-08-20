using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Choi
{
    public class Toy_Interaction : MonoBehaviour
    {
        public GameObject shelf_Toy;
        public GameObject interaction_Key;
        public bool activate = false;
        Transform handPos;

        bool holding = false;

        void Start()
        {
            handPos = GetComponentInParent<Toy_Manager>().player_Hand;
            interaction_Key.SetActive(false);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (activate && !holding && !handPos.GetComponentInParent<PlayerController_st1>().hold)
            {
                GetComponent<SpriteOutline>().outlineSize = 1;
                interaction_Key.SetActive(true);
            }
            else return;
        }

        void OnTriggerStay2D(Collider2D collision)
        {
            if(activate && handPos.childCount == 0 && !holding)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    holding = true;
                    transform.position = handPos.position;
                    transform.parent = null;
                    transform.parent = handPos;
                    Destroy(interaction_Key);
                }
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            GetComponent<SpriteOutline>().outlineSize = 0;
            if(interaction_Key != null) interaction_Key.SetActive(false);
        }
    }
}