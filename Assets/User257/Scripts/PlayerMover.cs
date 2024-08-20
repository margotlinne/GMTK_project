using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace User257
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] Animator anim;
        [SerializeField] float speed = 0.01f;

        [SerializeField] float startPosX;
        [SerializeField] float endPosX;


        Vector2 movement;

        private void Update()
        {
            Move();
        }

        void Move()
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            anim.SetFloat("xDir", movement.x);
            anim.SetFloat("yDir", movement.y);

            transform.position += new Vector3(movement.x * speed, 0f, 0f);

            //최대 최소 이동 가능한 거리 지정
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, startPosX, endPosX), transform.position.y, transform.position.z);
        }
    }
}
