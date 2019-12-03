using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GemQuota : MonoBehaviour
{

    public Text gemText;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gemText.text = "At least 45 gem points needed to continue!";
    }
}
