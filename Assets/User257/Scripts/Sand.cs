using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using User257;

public class Sand : MonoBehaviour
{
    [SerializeField] float sizingSpeed;

    [SerializeField] Sandglass sandglass;

    bool doSmaller = true;
    bool resize = true;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sandglass.OnChangeRound += ChangeDoSmaller;
    }
    private void Update()
    {
        Resize();    
    }

    void ChangeDoSmaller(int curRound)
    {
        switch (curRound)
        {
            case 0:
                doSmaller = true;
                break;
            case 1:
                doSmaller = false;
                break;
            case 2:
                doSmaller = true;
                break;
            case 3:
                resize = false;
                break;
        }
    }

    void Resize()
    {
        if (!resize)
            return;

        float time = Time.deltaTime * sizingSpeed;

        if (doSmaller)
        {
            transform.localScale -= new Vector3(1f * sizingSpeed * Time.deltaTime, 1f * sizingSpeed * Time.deltaTime, 1f * sizingSpeed * Time.deltaTime);
            rb.gravityScale = 0.05f;
        }
        else
        {
            transform.localScale += new Vector3(1f * sizingSpeed * Time.deltaTime, 1f * sizingSpeed * Time.deltaTime, 1f * sizingSpeed * Time.deltaTime);
            rb.gravityScale = 0.005f;
        }

        transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, sandglass.minSize, sandglass.maxSize), Mathf.Clamp(transform.localScale.y, sandglass.minSize, sandglass.maxSize), Mathf.Clamp(transform.localScale.z, sandglass.minSize, sandglass.maxSize));
    }
}
