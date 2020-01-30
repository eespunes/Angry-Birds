using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

    public int life;
    protected float divisor, maxLife;
    protected SpriteRenderer sr;
    public Sprite[] sprites;
    protected int damage;
    public GameObject die;
    public AudioClip sound;
    protected AudioSource audioSource;
    protected int actualHealth;

    protected void Start()
    {
        maxLife = life;
        divisor = (10f / sprites.Length);
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        actualHealth = sprites.Length;
    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            if (collision.gameObject.tag.Equals("Player"))
                damage = 75;
            else
                damage = 50;
            LoseLife((int)(rb.velocity.magnitude * damage));
        }
        else
            LoseLife(10);
            
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Explosion"))
        {
            LoseLife(2000);
        }
    }

    protected void LoseLife(int f)
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
    protected void Die()
    {
        if (die != null)
            Instantiate(die, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    protected void ChangeSprite()
    {
        int dividend = (int)((life / maxLife) * 10);
        int solution = (int)Mathf.Round(dividend / divisor);
        if (solution < actualHealth)
        {
            audioSource.clip = sound;
            audioSource.Play();
            sr.sprite = sprites[solution];
            actualHealth = solution;
        }
    }
}
