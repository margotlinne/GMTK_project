using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Choi
{
    public class WardrobeMonster : MonoBehaviour
    {
        public GameObject interaction;
        [SerializeField]
        GameObject Wall;

        Light2D map_light;

        void Start()
        {
            map_light = GameObject.Find("Maps").GetComponent<Light2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            interaction.SetActive(true);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            // 상호작용 UI 표시
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(Wall);
                map_light.intensity += 0.2f;
                Destroy(this.gameObject);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            interaction.SetActive(false);
        }
    }
}