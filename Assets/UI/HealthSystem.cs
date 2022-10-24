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

    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update(){
        /*if(Input.GetKeyDown(KeyCode.Space)){
            TakeDamage(20);
        }*/
    }
    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void setHealth(int health)
    {
        currentHealth = health;
        healthBar.SetHealth(health);
    }
}
