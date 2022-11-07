using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    public int energyRecoveryRate = 10;
    public float maxEnergy = 100.0f;
    public float currentEnergy = 100.0f;

    private float energyRegenTimer = 0.0f;

    public EnergyBar energyBar;

    void Start()
    {
        energyBar.SetMaxEnergy(maxEnergy);
        setEnergy(currentEnergy);
    }

    void Update()
    {
        EnergyRecovery();
    }

    public void EnergyRecovery()
    {
        if (maxEnergy >= currentEnergy)
        {
            energyRegenTimer += Time.deltaTime;
            if (energyRegenTimer > 1f)
            {
                GainEnergy(energyRecoveryRate);
                energyRegenTimer = 0; //reset timer
            }
        }
    }

    //Energy Functions
    public void GainEnergy(int energy)
    {
        currentEnergy += energy;
        energyBar.setUIEnergyBar(currentEnergy);
    }

    public void LoseEnergy(float energy)
    {//used when penguin uses special attack.
        currentEnergy -= energy;
        setEnergy(currentEnergy);
    }

    public void setEnergy(float energy)
    {
        currentEnergy = energy;
        energyBar.setUIEnergyBar(energy);
    }

    public float GetEnergyPercent()
    {
        return (float)currentEnergy / maxEnergy;
    }
}
