using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public static AudioClip digSound;
    static AudioSource audioSource;
    public static bool isPlaying;
    
    // Start is called before the first frame update
    void Start()
    {
        //digSound = Resources.Load<AudioClip> ("audioGarsas");
        digSound = Resources.Load<AudioClip>("digSound");
        audioSource = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying)
        {
            isPlaying = true;
        }
        else
        {
            isPlaying = false;
        }
    }

    public static void PlaySound(string sound)
    {
        switch (sound)
        {
            case "audioGarsas":
                if (!isPlaying)
                {
                    audioSource.PlayOneShot(digSound);
                }
                break;
        }
    }
}
