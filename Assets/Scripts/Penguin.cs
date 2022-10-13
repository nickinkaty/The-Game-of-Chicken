using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 1f;
    // Start is called before the first frame update
    private void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public void takeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
