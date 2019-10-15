using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{

    public bool faceRight = true;
    public bool faceLeft = true;
    public bool stopped = false;
    public float stun = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 5;
        if (stopped == false)
        {
            if (gameObject.tag == "Enemy(Left)")
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }
        else if (stopped == true)
        {
            stun++;
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if(stun == 1)
            {
                sr.color = Color.red;
            }
            else if(stun == 10)
            {
                sr.color = Color.white;
            }
            else if (stun == 55)
            {
                Debug.Log("Stun reached 55");
                Rigidbody2D rd2dP = GetComponent<Rigidbody2D>();
                BoxCollider2D bc2dp = GetComponent<BoxCollider2D>();
                rd2dP.bodyType = RigidbodyType2D.Dynamic;
                bc2dp.enabled = true;
                stopped = false;
                stun = 0;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Cage")
        {
            switch (gameObject.tag)
            {
                case "Enemy(Left)":
                    Debug.Log("Left facing touch wall");
                    if (faceRight == true)
                    {
                        transform.eulerAngles = new Vector3(0, -180, 0);
                        faceRight = false;

                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        faceRight = true;

                    }
                    break;
                case "Enemy":
                    Debug.Log("Right facing touch wall");
                    if (faceLeft == true)
                    {
                        transform.eulerAngles = new Vector3(0, -180, 0);
                        faceLeft = false;

                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        faceLeft = true;

                    }
                    break;
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody2D rd2d = GetComponent<Rigidbody2D>();
            BoxCollider2D bc2d = GetComponent<BoxCollider2D>();
            rd2d.bodyType = RigidbodyType2D.Static;
            bc2d.enabled = false;
            stopped = true;
        }
    }
}
