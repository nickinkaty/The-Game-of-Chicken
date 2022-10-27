using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int rangerAttack1 = 20;
    public int rangerAttack2 = 20;
    public int rangerAttack3 = 20;
    public int currentHealth;

    public HealthBar healthBar;

    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            TakeDamage(20);
        }
    }
    void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
