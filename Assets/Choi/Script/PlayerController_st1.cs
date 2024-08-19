using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Choi
{

    public class PlayerController_st1 : MonoBehaviour
    {
        public bool simulated = false;

        Rigidbody2D rb;
        [SerializeField]
        float moveSpeed;
        

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (!simulated)
            {
                float axis = Input.GetAxis("Horizontal");
                rb.velocity = new Vector2(axis * moveSpeed, 0f);
            }
        }

        void Update()
        {
            if(Input.GetMouseButton(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider.gameObject.layer == 6)
                {

                    FamiliyFicture ficture = hit.collider.gameObject.GetComponent<FamiliyFicture>();
                    ficture.Rezise();
                }
            }
        }
    }
}
