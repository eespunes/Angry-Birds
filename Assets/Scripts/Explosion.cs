using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public float time;
    public GameObject go;
    public AudioClip sound;
    protected AudioSource audioSource;


    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sound;
        audioSource.Play();
        Invoke("Die", time);
    }
    public void Die()
    {
        if (go != null) {
            GameObject go2= Instantiate(go, transform);
            go2.transform.parent = null;
        }
        Destroy(gameObject);
    }
}
