 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    protected float distance, forceValue;
    protected Rigidbody2D rb;
    protected Vector3 initialPosition;
    protected GameObject launch;
    protected bool launchTime,one,hasDied,end,revive;
    public Sprite hurt;
    protected GameController gc;
    public AudioClip[] sounds;
    public AudioClip rope;
    protected AudioSource audioSource;
    protected CameraMovement cm;
    protected SpriteRenderer sr;

    // Use this for initialization
    protected void Start () {
        rb=GetComponent<Rigidbody2D>();
        launch = GameObject.Find("Launch");
        rb.bodyType=RigidbodyType2D.Kinematic;
        transform.position = launch.transform.position;
        transform.parent = null;
        launchTime = true;
        one = false;
        forceValue = 10f;
        distance = 2;
        end = false;
        revive = false;
        gc = GameObject.Find("Canvas").GetComponent<GameController>();
        audioSource = GetComponent<AudioSource>();
        hasDied = false;
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        CanDie();
    }

    protected void OnMouseDown()
    {
        if (launchTime)
        {
            audioSource.clip = rope;
            audioSource.Play();
            initialPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    protected void OnMouseUp()
    {
        if (launchTime)
        {
            audioSource.clip = sounds[0];
            audioSource.Play();
            Invoke("Change", 15);
            Vector2 force = initialPosition - transform.position;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddRelativeForce(force * forceValue, ForceMode2D.Impulse);
            cm = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
                cm.FollowMe(gameObject);
            launchTime = false;
        }
    }
    protected void OnMouseDrag()
    {
        if (launchTime)
        {
            Vector3 location = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 force = location - initialPosition;
            if (force.magnitude > distance)
                transform.position = force.normalized * distance + launch.transform.position;
            else
            {
                location.z = 0;
                transform.position = location;
            }
        }
    }
    protected void CanDie()
    {
        if (!launchTime && rb.velocity.magnitude < 0.1f) {
            revive = false;
            Invoke("Die", 2);
        }
        else
            revive = true;

    }
    protected void Die()
    {
        if (!revive&&!hasDied)
        {
            audioSource.clip = sounds[2];
            audioSource.Play();
            sr.sprite = null;
            hasDied = true;
            Invoke("Dead", 1.25f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!end)
        {
            audioSource.clip = sounds[1];
            audioSource.Play();
           sr.sprite = hurt;
            end = true;
        }
    }
    protected void Change()
    {
        if (revive)
        {
            audioSource.clip = sounds[2];
            audioSource.Play();
            sr.sprite = null;
            hasDied = true;
            Invoke("Dead", 1.25f);
        }
        else
            Invoke("Change", 5);
    }
    void Dead()
    {
        Instantiate(gc.NextBird(), transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public bool GetLaunch()
    {
        return launchTime;
    }
}
