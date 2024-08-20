using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform target;
    public float speed;
    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, 0f, -10f);
    }
}
