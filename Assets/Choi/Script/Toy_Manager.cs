using Choi;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;

namespace Choi
{
    public class Toy_Manager : MonoBehaviour
    {
        public Transform player_Hand;
        SpriteOutline[] spriteLine;
        void Start()
        {
            spriteLine = GetComponentsInChildren<SpriteOutline>();
            for(int i = 0; i < spriteLine.Length; i++) 
            {
                spriteLine[i].outlineSize = 0;
            }
        }

        public void OnActive()
        {
            Toy_Interaction[] toy = GetComponentsInChildren<Toy_Interaction>();
            foreach(Toy_Interaction element in toy)
            {
                element.activate = true;
            }
        }
    }
}
