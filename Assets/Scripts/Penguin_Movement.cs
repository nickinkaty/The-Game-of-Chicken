using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin_Movement : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    private bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        Flip();
        
        if (distToPlayer < agroRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
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

    void Flip()
    {
        // facingRight = !facingRight;
        // transform.Rotate(0,180,0);

    }
    
    
}

