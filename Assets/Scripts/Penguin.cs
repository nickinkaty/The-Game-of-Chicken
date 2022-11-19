using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 1f;

    public HealthbarBehavior Healthbar;

    public Vector3 enemySpawnLocation;


    // Start is called before the first frame update
    private void Start()
    {
        enemySpawnLocation = this.transform.position;
        health = maxHealth;
        Healthbar.SetHealth(health, maxHealth);
    }

    // Update is called once per frame
    public void takeDamage(float damage)
    {
        health -= damage;
        Healthbar.SetHealth(health, maxHealth);

        if (health <= 0)
        {
            this.gameObject.SetActive(false);
            Invoke("Respawn", 7);
        }
    }

    void Respawn()
    {
        this.transform.position = enemySpawnLocation;
        this.gameObject.SetActive(true);
        health = maxHealth;
        Healthbar.SetHealth(maxHealth, maxHealth);
    }
}
