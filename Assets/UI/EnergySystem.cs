using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    public int maxEnergy = 100;
    public int currentEnergy;

    public EnergyBar energyBar;

    void Start()
    {
        energyBar.SetMaxEnergy(maxEnergy);
        setEnergy(currentEnergy);
    }

    void Update()
    {

    }

    //Energy Functions
    public void GainEnergy(int energy)
    {
        currentEnergy += energy;
        energyBar.setUIEnergyBar(currentEnergy);
    }

    public void LoseEnergy(int energy)
    {//used when penguin uses special attack.
        currentEnergy += energy;
        setEnergy(currentEnergy);
    }

    public void setEnergy(int energy)
    {
        currentEnergy = energy;
        energyBar.setUIEnergyBar(energy);
    }

    public float GetEnergyPercent()
    {
        return (float)currentEnergy / maxEnergy;
    }
}
