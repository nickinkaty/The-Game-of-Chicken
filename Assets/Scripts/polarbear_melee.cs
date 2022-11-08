using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polarbear_melee : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange, range = 5f;

    [SerializeField]
    float moveSpeed, speed = 2f;

    //public Transform target;
    public float attackRange;
    public int damage;
    private float lastAttackTime;
    public float attackDelay;

    public HealthSystem playerComponent;

    Rigidbody2D rb2d;
    public Animator Animator;

    // private bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Ranger").transform;
        agroRange = range;
        moveSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        //distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        // Flip();

        if (distToPlayer < agroRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }
        Animator.SetFloat("Speed", Mathf.Abs(moveSpeed));

        //Check if player is close enough to attack
        //float distanceToPlayer = Vector3.Distance(transform.position, player.postition);
        if (distToPlayer < attackRange)
        {
            if(Time.time > lastAttackTime + attackDelay)
            {
                //have the player take damage
                playerComponent.TakeDamage(damage);
                lastAttackTime = Time.time;
            }
        }
    }
    void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            //ememy is to the left side of the player, move right
            rb2d.velocity = new Vector2(moveSpeed, 0);
            // transform.localScale = new Vector2(-1,1);
            transform.localScale = new Vector3(-1,1,1);
            // Flip();
            if(transform.position.y > player.position.y)
            {
                rb2d.velocity = new Vector2(moveSpeed, -moveSpeed);
            }
            // Animator.SetFloat("Speed", Mathf.Abs(rb2d.velocity));
        }
        else
        {
            //ememy is to the right side of the player, move right
            rb2d.velocity = new Vector2(-moveSpeed,0);
            // transform.localScale = new Vector2(1,-1);
            transform.localScale = new Vector3(1,1,1);
            // Flip();
            if(transform.position.y > player.position.y)
            {
                rb2d.velocity = new Vector2(-moveSpeed, -moveSpeed);
            }
        }
    }

    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0,0);
    }

}

