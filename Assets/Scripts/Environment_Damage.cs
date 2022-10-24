using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment_Damage : MonoBehaviour
{
    public int environmentDamage = 100;
    public HealthSystem healthSystem;

    void Start()
    {

    }

    void Update()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            healthSystem.TakeDamage(environmentDamage);
        }
    }
}