using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxEnergy = 100;
    public int penguinDamage = 20;
    public int penguinEnergy = 20; //energy gained by ranger from hitting penguins
    public int bossDamage1 = 25;
    public int bossEnergy = 30; //energy gained by ranger from hitting boss
    public int currentHealth;
    public int currentEnergy;
    public Animator Animator;

    public HealthBar healthBar;
    public EnergyBar energyBar;

    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        currentEnergy = 0;
        energyBar.SetMaxEnergy(maxEnergy);
        SetEnergy(currentEnergy);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            TakeDamage(20);
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            GainEnergy(20);
        }
    }
    //Damage functions
    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    //Health Functions
    public void setHealth(int health)
    {
        currentHealth = health;
        healthBar.SetHealth(health);
    }

    public float GetHealthPercent(){
        return (float)currentHealth/maxHealth;
    }
    //Energy Functions
    public void GainEnergy(int energy){
        currentEnergy += energy;
        energyBar.SetEnergy(currentEnergy);
    }

    public void LoseEnergy(int energy){//used when penguin uses special attack.
        currentEnergy += energy;
        energyBar.SetEnergy(currentEnergy);
    }

    public void setEnergy(int energy)
    {
        currentEnergy = energy;
        energyBar.SetEnergy(energy);
    }

    public float GetEnergyPercent(){
        return (float)currentEnergy/maxEnergy;
    }
}
