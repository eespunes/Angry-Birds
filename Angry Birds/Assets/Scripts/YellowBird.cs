using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBird : Bird {
    public Sprite speed;
    private int maxSpeed=500;

    protected void Update()
    {
        if (Input.GetButtonDown("Fire1")&&!one&&!launchTime)
        {
            GetComponent<SpriteRenderer>().sprite = speed;
            rb.AddForce(rb.velocity.normalized * maxSpeed);
            one = true;
        }
        CanDie();
    }
}
