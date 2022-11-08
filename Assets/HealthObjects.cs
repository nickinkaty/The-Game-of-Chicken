using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthObjects : MonoBehaviour
{
    public int healthRecovery = 10;
    public HealthSystem healthSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D obj)
    {
        if (obj.gameObject.name.Equals ("Ranger"))
        {
            healthSystem.recoverHealth(healthRecovery);
            Destroy(gameObject);
        }
            
    }
}
