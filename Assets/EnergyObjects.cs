using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyObjects : MonoBehaviour
{
    [SerializeField]
    public int energyRecovery = 20;
    public EnergySystem energy;
    public Animator animator;
    // Start is called before the first frame update

    void Start()
    {
        energy = GetComponent<EnergySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D obj)
    {
        if (obj.gameObject.name.Equals ("Ranger"))
        {
            animator.SetTrigger("Collision");
            energy.GainEnergy(energyRecovery);
        }
    }

    public void collided()
    {
        Destroy(gameObject);
    } 
}