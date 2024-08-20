using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Spider_Monster : MonoBehaviour
{
    public GameObject spider_toy;
    public GameObject toy_count;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void Weak()
    {
        if (toy_count.transform.childCount > 0) transform.localScale += new Vector3(-0.050f, -0.050f, 0.0f);
        else
        {
            spider_toy.SetActive(true);
            Destroy(this.gameObject);
            GameObject.Find("Maps").GetComponent<Light2D>().intensity += 0.3f;
        }
    }
}
