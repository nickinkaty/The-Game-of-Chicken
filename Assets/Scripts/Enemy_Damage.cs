using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Damage : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public HealthSystem healthSystem;
    public int damageInflicted;
    public float cooldown;
    public float maxCoolDown;
    public float attack;

    // Start is called before the first frame update
    void Start()
    {  
        rigidbody = GetComponent<Rigidbody2D>();
        maxCoolDown = cooldown;
    }

    // Update is called once per frame

    /*void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
         {
            if (cooldown == 0)
            {
                healthSystem.TakeDamage(damageInflicted);
            }
            //cooldown = maxCoolDown;
        }
        cooldown--;
        if (cooldown == -10)
        {
            cooldown = maxCoolDown;
        }
    }*/   

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            attack = Mathf.Min(cooldown * Time.deltaTime, 100.0f);
            if (attack == 0)
            {
                healthSystem.TakeDamage(damageInflicted);
                //attack = 0;
            }
            //cooldown = maxCoolDown;
        }
        cooldown--;
        if (cooldown == -10)
        {
            cooldown = maxCoolDown;
        }
    }   

    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            healthSystem.TakeDamage(damageInflicted);
        }
    }
    
}

