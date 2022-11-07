using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;
    //private HealthSystem healthsys;

    public void Setup(){
        //this.healthsys = healthsys;
    }

    void Update(){
        //slider.value = healthsys.GetHealthPercent();
    }

    public void SetMaxEnergy(float energy){
        slider.maxValue = energy;
        slider.value = energy;
    }
    
    public void setUIEnergyBar(float energy){
        slider.value = energy;
    }
    
}
