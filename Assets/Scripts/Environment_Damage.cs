using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment_Damage : MonoBehaviour
{
    public int environmentDamage = 100;
    public HealthSystem healthSystem;

    void Start()
    {

    }

    void Update()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            //var healthSystem = collision.GetComponent<HealthSystem>();

            //if (healthSystem != null)
            //{
            Debug.Log("COLLISION");
            healthSystem.TakeDamage(environmentDamage);
            //}
        }
    }
}