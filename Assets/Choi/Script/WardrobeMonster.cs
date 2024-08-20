using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Choi
{
    public class WardrobeMonster : MonoBehaviour
    {
        [SerializeField]
        GameObject Wall;

        Light2D map_light;

        void Start()
        {
            map_light = GameObject.Find("Maps").GetComponent<Light2D>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            // 상호작용 UI 표시
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(Wall);
                // 상호작용 UI 페이드 아웃
                Destroy(this.gameObject);
                map_light.intensity += 0.2f;
            }
        }
    }
}