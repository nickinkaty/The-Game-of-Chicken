using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    /*public void Setup(){
        this.healthsys = healthsys;
    }*/

    void Update(){
        //slider.value = healthsys.GetHealthPercent();
    }

    public void SetMaxHealth(float health){
        //slider.maxValue = health;
        //slider.value = health;
    }
    
    public void SetUIHealthBar(float health){
        slider.value = health;
    }
    
}
