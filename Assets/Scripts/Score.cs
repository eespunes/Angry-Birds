using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : Explosion {
    private GameController gc;
    public int score;
    private bool move;
    private GameObject text;

    private void Start()
    {
        gc = GameObject.Find("Canvas").GetComponent<GameController>();
        move = true;
        text = GameObject.Find("Score");
        gc.AddScore(score);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, text.transform.position, 5*Time.deltaTime);
    }

}
