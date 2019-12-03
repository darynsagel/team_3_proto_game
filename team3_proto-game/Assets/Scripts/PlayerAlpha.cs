using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAlpha : MonoBehaviour
{

    public KeyCode alphaOn;
    public KeyCode alphaOff;
    public float alphaLevel;


    // Start is called before the first frame update
    void Start()
    {
        alphaLevel = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(alphaOn))
            alphaLevel = 0.3f;
        if (Input.GetKeyDown(alphaOff))
            alphaLevel = 1.0f;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaLevel);
    }
}
