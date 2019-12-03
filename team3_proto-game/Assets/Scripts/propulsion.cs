using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propulsion : MonoBehaviour
{

    public KeyCode push;
    public float fast;
    private float timebtwn = 7.0f;
    private float starttime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        fast = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(push) && Time.time > starttime)
            {
            starttime = Time.time + timebtwn;
                fast = 60.0f;
                Invoke("resetspeed", 0.75f);

            }

    }

    public void resetspeed()
    {
        fast = 20.0f;
    }

    public void chill()
    {

    }
}
