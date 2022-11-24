using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioClip playerJumpSound, fireBallSound, eggShootSound, playerDeathSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        playerJumpSound = Resources.Load<AudioClip>("jump");
        fireBallSound = Resources.Load<AudioClip>("fireball");
        eggShootSound = Resources.Load<AudioClip>("egg");
        playerDeathSound = Resources.Load<AudioClip>("death");

        audioSrc = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSrc.PlayOneShot(playerJumpSound);
                break;
            case "fireball":
                audioSrc.PlayOneShot(fireBallSound);
                break;
            case "egg":
                audioSrc.PlayOneShot(eggShootSound);
                break;
            case "death":
                audioSrc.PlayOneShot(playerDeathSound);
                break;
        }
    }
}
