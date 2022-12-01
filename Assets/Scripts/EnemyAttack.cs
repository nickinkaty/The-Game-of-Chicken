using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform FirePosition;
    public GameObject projectile;
    public Animator animator;
    public Transform player;
    [SerializeField]
    public float coolDown = 3.0f;
    [SerializeField]
    public float maxDistance = 5.0f;

    private float lastFire;
    // Start is called before the first frame update
    void Start()
    {
        lastFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - lastFire) > coolDown && Vector2.Distance(transform.position, player.position) < maxDistance)
        {
            lastFire = Time.time;
            animator.SetTrigger("Attacking");
            AudioManagerScript.PlaySound("fireball");    
        }
    }

    public void FireProjectile()
    {
        if(player.position.x < transform.position.x)
        {
            Instantiate(projectile, FirePosition.position,  Quaternion.Euler(new Vector3(0,180,0)));
        } 
        else
        {
            Instantiate(projectile, FirePosition.position, Quaternion.Euler(new Vector3(0,0,0)));
        }
    }
}
