using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score2 : MonoBehaviour
{

    public Text scoreText;
    public int scorenum;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scorenum = GameObject.Find("Player").GetComponent<PlayerController2>().score;
        scoreText.text = "Gems: " + scorenum.ToString();
    }
}
