using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip glassSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        glassSound = Resources.Load<AudioClip>("glassSound");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlayGlassSound()
    {
        audioSrc.PlayOneShot(glassSound);
    }
}
