using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Choi
{
    public class Shelf_Interaction : MonoBehaviour
    {
        public GameObject interaction;
        public PlayerController_st1 player; 
        void Start()
        {
            interaction.SetActive(false);
        }

        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(player.hold) interaction.SetActive(true);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            interaction.SetActive(false);
        }
    }
}
