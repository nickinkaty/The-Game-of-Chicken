using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Patrol : MonoBehaviour
{
    [Header ("Patrol Points")]    
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameter")]
    [SerializeField] private float speed;
    [SerializeField] private float speed2;
    private Vector3 initScale;
    private bool movingLeft;

    public Transform player;
    public float range;
    private float distToPlayer;
    public float timeBTWShots;
    public GameObject bullet;
    public Transform shootPos;
    public float shootSpeed;

    public Animator Animator;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer <= range)
        {
            if(player.position.x > transform.position.x && transform.localScale.x < 0 || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                DirectionChange();
            }
            
            speed = 0;
            Instantiate(bullet, shootPos.position, shootPos.rotation);
            //StartCoroutine(Shoot());
        }
        else 
        {
            speed = 1;
        }
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
                
            else
            {
                DirectionChange();
            }
                
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
                
            else
            {
                DirectionChange();
            }
                
        }
        Animator.SetFloat("Speed", Mathf.Abs(speed2));
    }

    private void DirectionChange()
    {
        movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(timeBTWShots);
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * speed2 * Time.fixedDeltaTime, 0f);
        //Instantiate(bullet,shootPos.position, shootPos.rotation);
    }
}
