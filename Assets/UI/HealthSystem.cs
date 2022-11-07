using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int penguinDamage = 20;
    public int bossDamage1 = 25;
    public int currentHealth;

    public HealthBar healthBar;

    public Animator Animator;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {

        healthBar.SetUIHealthBar(currentHealth);
    }

    //Damage functions
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        healthBar.SetUIHealthBar(currentHealth);
    }

    //Health Functions
    public void setHealth(int health)
    {
        currentHealth = health;
        healthBar.SetUIHealthBar(currentHealth);
    }

    public float GetHealthPercent(){
        return (float)currentHealth/maxHealth;
    }

}
