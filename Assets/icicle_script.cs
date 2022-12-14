using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
    


public class icicle_script : MonoBehaviour
{
    public float projectileSpeed;
    public GameObject impactEffect;

    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody= GetComponent<Rigidbody2D>(); 
        rigidbody.velocity=transform.right *projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<HealthSystem>(out HealthSystem playerComponent))
        {
            playerComponent.TakeDamage(10);
        }
        //Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
