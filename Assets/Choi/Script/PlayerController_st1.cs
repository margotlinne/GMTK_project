using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Choi
{

    public class PlayerController_st1 : MonoBehaviour
    {
        public bool simulated = false;
        public bool hold = false;
        Animator anim;
        Rigidbody2D rb;
        [SerializeField]
        float moveSpeed;

        Toy_Interaction onhand_toy;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();

        }

        private void FixedUpdate()
        {
            
        }

        void Update()
        {
            float moveInput = Input.GetAxisRaw("Horizontal");
            
            anim.SetFloat("Vectical", moveInput);

            if (moveInput != 0) anim.SetBool("IsWalking", true);
            else anim.SetBool("IsWalking", false);


            if (!simulated)
            {
                float axis = Input.GetAxis("Horizontal");
                rb.velocity = new Vector2(axis * moveSpeed, 0f);
            }

            if (GetComponentInChildren<Toy_Interaction>() != null)
            {
                hold = true;
                onhand_toy = GetComponentInChildren<Toy_Interaction>();
            }
            if (Input.GetMouseButton(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.layer == 6)
                    {
                        FamiliyFicture ficture = hit.collider.gameObject.GetComponent<FamiliyFicture>();
                        ficture.Rezise();
                    }
                }
                else return;
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 7 && hold)
            {
                // 상호작용 키 활성화 함수 or 코루틴
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject go = onhand_toy.shelf_Toy;
                    Color color = go.GetComponent<SpriteRenderer>().color;
                    color.a = 1f;
                    go.GetComponent<SpriteRenderer>().color = color;
                    go.GetComponent<SpriteOutline>().outlineSize = 0;
                    Destroy(onhand_toy.gameObject);
                    hold = false;
                    GameObject.Find("Spider_Monster").gameObject.GetComponent<Spider_Monster>().Weak();
                }
            }
        }
    }
}
