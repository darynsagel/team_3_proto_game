﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;
    public int score = 0;
    public Text scoreBoard;

    private GameObject CageObj, Gem;
	private Rigidbody2D rb;
	private Vector2 moveVelocity;

	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate()
	{
		rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Button"))
        {
            CageObj = GameObject.FindGameObjectWithTag("Cage");
            Object.Destroy(CageObj);
        }
        else if (other.gameObject.CompareTag("VictoryFish"))
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
        else if (other.gameObject.CompareTag("Gem1"))
        {
            Gem = GameObject.FindGameObjectWithTag("Gem1");
            Object.Destroy(Gem);
            score++;
            scoreBoard.text = "Score: " + score;
        }
        else if (other.gameObject.CompareTag("Gem2"))
        {
            Gem = GameObject.FindGameObjectWithTag("Gem2");
            Object.Destroy(Gem);
            score++;
            scoreBoard.text = "Score: " + score;
        }
        else if (other.gameObject.CompareTag("Gem3"))
        {
            Gem = GameObject.FindGameObjectWithTag("Gem3");
            Object.Destroy(Gem);
            score++;
            scoreBoard.text = "Score: " + score;
        }
        else if (other.gameObject.CompareTag("Gem4"))
        {
            Gem = GameObject.FindGameObjectWithTag("Gem4");
            Object.Destroy(Gem);
            score++;
            scoreBoard.text = "Score: " + score;
        }
        else if (other.gameObject.CompareTag("Gem5"))
        {
            Gem = GameObject.FindGameObjectWithTag("Gem5");
            Object.Destroy(Gem);
            score++;
            scoreBoard.text = "Score: " + score;
        }
        else if (other.gameObject.CompareTag("Gem10"))
        {
            Gem = GameObject.FindGameObjectWithTag("Gem10");
            Object.Destroy(Gem);
            score = score + 10;
            scoreBoard.text = "Score: " + score;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            SoundManager.PlaySound("enemybump");
        }
    }
}
