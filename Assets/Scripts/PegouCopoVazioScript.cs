using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegouCopoVazioScript : MonoBehaviour
{
    public static AudioClip PegouCopoVazioSound;
    static AudioSource audioSrc4;
    // Start is called before the first frame update
    void Start()
    {
        PegouCopoVazioSound = Resources.Load<AudioClip>("PegouCopoVazio");
        audioSrc4 = GetComponent<AudioSource>();
    }

    public static void PlayBrokenGlassSound()
    {
        audioSrc4.PlayOneShot(PegouCopoVazioSound);
    }
}

