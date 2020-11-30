using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyGlassSoundScript : MonoBehaviour
{

    public static AudioClip brokenGlassSound;
    static AudioSource audioSrc3;
    // Start is called before the first frame update
    void Start()
    {
        brokenGlassSound = Resources.Load<AudioClip>("brokenGlassSound");
        audioSrc3 = GetComponent<AudioSource>();
    }

    public static void PlayBrokenGlassSound()
    {
        audioSrc3.PlayOneShot(brokenGlassSound);
    }
}
