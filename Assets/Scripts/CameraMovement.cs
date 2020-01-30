using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private GameObject bird;
    public GameObject bounce, game;
    private bool launch,direction;
    private int minX, maxX, minY, maxY;
    private Vector3 initialPosition;
    public GameObject camLimit;

    private void Start()
    {
        Vector2 posInicial = bounce.transform.position;
        Vector2 posFin = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        game.transform.position += new Vector3((posFin.x - posInicial.x), 0);
        initialPosition = transform.position;
        minX = (int)transform.position.x;
        minY = (int)transform.position.y;
        maxX = (int)camLimit.transform.position.x;
        maxY = (int)camLimit.transform.position.y;
    }

    // Update is called once per frame
    void Update () {

        if (bird != null)
        {
                float x = Mathf.Clamp(bird.transform.position.x, minX, maxX);
                float y = Mathf.Clamp(bird.transform.position.y, minY, maxY);
                
                transform.position = new Vector3(x, y, transform.position.z);
        }
        else
            transform.position = initialPosition;
    }
    public void FollowMe(GameObject go)
    {
        bird = go;
    }
}
