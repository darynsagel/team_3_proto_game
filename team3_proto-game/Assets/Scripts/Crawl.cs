using System.Collections;
using UnityEngine;

public class Crawl : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        {
            float move = Input.GetAxis("Horizontal");
            anim.SetFloat("Speed", move);
        }
    }

    void Movement()
    {
        if(Input.GetKey (KeyCode.D))
        {
            transform.Translate(Vector2.right * 3f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if(Input.GetKey (KeyCode.A))
        {
            transform.Translate(Vector2.right * 3f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, -100);
        }


    }
}
