using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    public float speed = 3;
    public bool faceRight= true ;
    public Rigidbody2D rd2d;
    // Start is called before the first frame update
    void Start()
    {
        rd2d.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision .gameObject.tag  == "Wall")
        {
            if(faceRight ==true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                faceRight = false;
                Debug.Log("jhi");
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                faceRight = true;
                Debug.Log("Hello");
            }
        }
    }
}
