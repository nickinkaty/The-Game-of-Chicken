using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 1f;

    public HealthbarBehavior Healthbar;

    public Vector3 enemySpawnLocation;

    public bool isBossFight = false;

    public Animator animator;
    public GameObject prize;
    public Transform prizePos;


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
            animator.SetTrigger("Death");
        }
    }

    public void Death()
    {
        this.gameObject.SetActive(false);
        if (!isBossFight)
        {
            Instantiate(prize, prizePos.position, Quaternion.Euler(new Vector3(0,180,90)));
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
