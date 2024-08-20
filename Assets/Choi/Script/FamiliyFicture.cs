using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

namespace Choi
{
    public class FamiliyFicture : MonoBehaviour
    {
        public GameObject monster;
        [SerializeField]
        GameObject wall;
        float MaxScale = 1.0f;
        SpriteRenderer spriteRenderer;
        SpriteOutline sp;
        Light2D map_Light;
        Coroutine lookFicture;
        bool flag = false;

        [SerializeField] GameObject mouseWheel;

        void Start()
        {
            spriteRenderer = monster.GetComponent<SpriteRenderer>();
            sp = GetComponent<SpriteOutline>();
            map_Light = GameObject.Find("Maps").GetComponent<Light2D>();
        }

        private void Update()
        {
            if (flag && lookFicture == null)
            {
                lookFicture = StartCoroutine(LookFicture());
                flag = false;
            }
            else return;
        }
        public void Enabled_OutLine()
        {
            sp.outlineSize = 4;
        }

        public void Disable_OutLine()
        {
            sp.outlineSize = 0;
        }

        public void Rezise()
        {
            float value = Input.GetAxis("Mouse ScrollWheel");

            if (value > 0 && transform.localScale.x < 1.0f) transform.localScale *= value + 1;
            else if (transform.localScale.x > 1.0f) flag = true;
            Color color = spriteRenderer.color;
            if (color.a > 0) color.a = 1 - transform.localScale.x;
            spriteRenderer.color = color;
        }

        void OnMouseEnter()
        {
            if (transform.localScale.x < 1.0f) Enabled_OutLine();
            else Disable_OutLine();
        }
        
        void OnMouseExit()
        {
            Disable_OutLine();
        }

        IEnumerator LookFicture()
        {

            Color color = GetComponent<SpriteRenderer>().color;
            color.a = 1.0f;
            GetComponent<SpriteRenderer>().color = color;
            Animator anim = GameObject.Find("Player").GetComponent<Animator>();
            anim.SetBool("lookForFicture", true);
            map_Light.intensity += 0.1f;
            GameObject.Find("Player").GetComponent<PlayerController_st1>().simulated = true;
            yield return new WaitForSeconds(5.0f);

            mouseWheel.SetActive(false);

            GameObject.Find("ToyManager").GetComponent<Toy_Manager>().OnActive();
            GameObject.Find("Player").GetComponent<PlayerController_st1>().simulated = false;
            Destroy(wall);
            anim.SetBool("lookForFicture", false);

        }
    }
}
