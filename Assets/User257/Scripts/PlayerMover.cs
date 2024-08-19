using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] float speed = 0.01f;

    private void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("Walk_L", true);
            transform.position += new Vector3(-speed, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("Walk_R", true);
            transform.position += new Vector3(speed, 0f, 0f);
        }
        else
        {
            anim.SetBool("Walk_L", false);
            anim.SetBool("Walk_R", false);
        }
    }
}
