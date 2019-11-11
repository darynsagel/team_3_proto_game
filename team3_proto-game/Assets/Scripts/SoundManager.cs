using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip enemybump;
    public static AudioClip bubbles;
    public static AudioClip cage;
    public static AudioClip gem;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        enemybump = Resources.Load<AudioClip>("enemybump");
        bubbles = Resources.Load<AudioClip>("bubbles");
        cage = Resources.Load<AudioClip>("cage");
        gem = Resources.Load<AudioClip>("gem");
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
            case "cage":
                audioSrc.PlayOneShot(cage);
                break;
            case "gem":
                audioSrc.PlayOneShot(gem);
                break;
            case "bubbles":
                audioSrc.PlayOneShot(bubbles);
                break;
        }
    }
}
