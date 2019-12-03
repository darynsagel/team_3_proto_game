using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inking : MonoBehaviour
{

	public KeyCode activate;
	public ParticleSystem inksplot;


	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(activate))
		{
			toggleInk();
		}

	}

    public void toggleInk()
	{
		if (inksplot.isPlaying)
			inksplot.Play();
		else
			inksplot.Stop();
	}
}
