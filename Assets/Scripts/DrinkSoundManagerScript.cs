using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkSoundManagerScript : MonoBehaviour
{

    public static AudioClip drinkSound;
    static AudioSource audioSrc2;
    // Start is called before the first frame update
    void Start()
    {
        drinkSound = Resources.Load<AudioClip>("drinkSound");
        audioSrc2 = GetComponent<AudioSource>();
    }

    public static void PlayDrinkSound()
    {
        audioSrc2.PlayOneShot(drinkSound);
    }
}
