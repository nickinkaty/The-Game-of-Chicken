using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Damage : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public HealthSystem healthSystem;
    public int damageInflicted;
    public int cooldown;
    int maxCoolDown;

    // Start is called before the first frame update
    void Start()
    {  
        rigidbody = GetComponent<Rigidbody2D> ();
        maxCoolDown = cooldown;
    }

    // Update is called once per frame
    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            healthSystem.TakeDamage(damageInflicted);
        }

    }

    void OnCollisionStay (Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && cooldown == 0)
        {
            healthSystem.TakeDamage(damageInflicted);
            cooldown = maxCoolDown;
        }
        cooldown--;
    }
}

