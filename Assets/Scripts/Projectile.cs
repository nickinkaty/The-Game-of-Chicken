using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float projectileSpeed;
    public GameObject impactEffect;
    public Animator animator;

    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody= GetComponent<Rigidbody2D>(); 
        rigidbody.velocity=transform.right *projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("Collision");
        rigidbody.velocity = Vector2.zero;
        if (collision.gameObject.TryGetComponent<Penguin>(out Penguin penguinComponent))
        {
            penguinComponent.takeDamage(1);
        }
        else if (collision.gameObject.TryGetComponent<HealthSystem>(out HealthSystem RangerHP))
        {
            RangerHP.TakeDamage(10);
        }
        //Instantiate(impactEffect, transform.position, Quaternion.identity);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("Collision");
        rigidbody.velocity = Vector2.zero;
    }

    public void collided()
    {
        Destroy(gameObject);
    }
    
}
