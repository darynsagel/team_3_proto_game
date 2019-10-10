using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public float speed = 3;
    public bool faceRight = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Cage")
        {
            if (faceRight == false )
            {
                transform.eulerAngles = new Vector3(0,-180, 0);
                faceRight = true;
                
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                faceRight = false;
                
            }
        }
    }
}
