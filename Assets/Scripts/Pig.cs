using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pig : Life {
    protected new void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            if (collision.gameObject.tag.Equals("Player"))
                damage = 100;
            else
                damage = 35;
            LoseLife((int)(rb.velocity.magnitude * damage));
        }
        else
            LoseLife(10);

    }
    private new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Explosion"))
        {
            LoseLife(1000);
        }
    }
    protected new void LoseLife(int f)
    {

        life -= f;
        if (life <= 0)
        {
            Die();
        }
        else
        {
            ChangeSprite();
        }
    }
    protected new void Die()
    {
        if (die != null)
        {
            sr.sprite = null;
            Instantiate(die, transform.position, Quaternion.identity);
        }
        if (gameObject.name.Contains("Flying"))
            Destroy(gameObject.transform.parent.gameObject);
        
        else Destroy(gameObject);
    }

}
