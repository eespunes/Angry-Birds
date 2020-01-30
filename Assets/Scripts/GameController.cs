using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private int score;
    public Text scoreText;
    public GameObject[] birds,sprites;
    private int numberBirds;
    private GameObject pigs;
    private GameObject Win;
    private int flyingPigs;
	// Use this for initialization
	void Start () {
        numberBirds = (birds.Length - 1);
        score = 0;
        Instantiate(NextBird(), GameObject.Find("Launch").transform).transform.parent = null;
        scoreText.text = "0";
        pigs = GameObject.Find("Pigs");
        for(int i = 0; i < pigs.transform.childCount; i++)
        {
            if (pigs.transform.GetChild(i).name.Contains("Flying"))
                flyingPigs++;
        }
    }

    public void AddScore(int i)
    {
        score += i;
        scoreText.text = score.ToString();
        if (pigs.transform.childCount <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }
    public GameObject NextBird()
    {
        if (numberBirds < 0)
        {
            if (pigs.transform.childCount <= 0)
            {
                SceneManager.LoadScene("Win");
                return sprites[0];
            }
            else
            {
                SceneManager.LoadScene("GameOver");
                return sprites[0];
            }
        }
        if (numberBirds >= 0)
        {
            sprites[numberBirds].SetActive(false);
            GameObject go = birds[numberBirds];
            numberBirds--;
            return go;
        }
        return null;
    }
}
