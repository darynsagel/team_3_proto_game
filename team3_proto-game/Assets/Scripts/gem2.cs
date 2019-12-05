using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class gem2 : MonoBehaviour
{

    public Text gemText;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gemText.text = "At least 60 gem points needed to continue!";
    }
}
