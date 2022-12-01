using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int penguinDamage = 20;
    public int bossDamage1 = 25;
    public int icicleDamage = 10;
    public int currentHealth;

    public HealthBar healthBar;

    public Animator Animator;

    private Rigidbody2D rigidbody;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        healthBar.SetUIHealthBar(currentHealth);
    }

    void OnCollisionEnter2D(Collision2D obj)
    {

    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag.Equals("Icicle"))
        {
            //TakeDamage(icicleDamage);
        }
    }

    //Damage functions
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetUIHealthBar(currentHealth);
    }

    //Recovery function
    public void recoverHealth(int recovery)
    {
        currentHealth += recovery;
        if(currentHealth > maxHealth)
            currentHealth = maxHealth;
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
