using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : Bird
{
    public GameObject explosion;

    protected void Update()
    {
        if (Input.GetButtonDown("Fire1") && !one && !launchTime)
        {
            rb.bodyType = RigidbodyType2D.Static;
            GameObject go =Instantiate(explosion, transform.position,Quaternion.identity);
            go.transform.parent = gameObject.transform;
            one = true;
            GetComponent<SpriteRenderer>().sprite = null;
            Invoke("Die", 1f);
        }
    }
}