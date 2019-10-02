using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip enemybump;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        enemybump = Resources.Load<AudioClip>("enemybump");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch(clip)
        {
            case "enemybump":
                audioSrc.PlayOneShot(enemybump);
                break;
        }
    }
}
