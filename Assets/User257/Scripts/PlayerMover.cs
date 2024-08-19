using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] float speed = 0.01f;

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
    }
}
