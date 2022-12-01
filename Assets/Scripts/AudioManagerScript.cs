using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioClip playerJumpSound, fireBallSound, eggShootSound, playerDeathSound, playerWalkSound, playerChickenJump, playerChickenDeath;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        playerJumpSound = Resources.Load<AudioClip>("jump");
        fireBallSound = Resources.Load<AudioClip>("fireball");
        eggShootSound = Resources.Load<AudioClip>("egg");
        playerDeathSound = Resources.Load<AudioClip>("death");
        playerWalkSound = Resources.Load<AudioClip>("walking");
        playerChickenJump = Resources.Load<AudioClip>("ChickenJump");
        playerChickenDeath = Resources.Load<AudioClip>("ChickenDeath");
        

        audioSrc = GetComponent<AudioSource>();
        audioSrc.clip = playerWalkSound;
        audioSrc.volume = 0.5f;
        
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
                audioSrc.PlayOneShot(playerChickenJump);
                break;
            case "fireball":
                audioSrc.PlayOneShot(fireBallSound);
                break;
            case "egg":
                audioSrc.PlayOneShot(eggShootSound);
                break;
            case "death":
                audioSrc.PlayOneShot(playerDeathSound);
                audioSrc.PlayOneShot(playerChickenDeath);
                break;
            case "walk":
                audioSrc.Play();
                break;
            case "stop":
                audioSrc.Stop();
                break;
        }
    }
}
