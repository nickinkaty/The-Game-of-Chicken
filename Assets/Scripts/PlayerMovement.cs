using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public PlayerManager playerManager;

    private new Camera camera;
    private new Rigidbody2D rigidbody;

    private Vector3 respawnPoint;
    private Vector2 velocity;
    private float inputAxis;

    public bool isFacingRight;
    public float moveSpeed = 3f;
    public float maxJumpHeight = 5f;
    public float maxJumpTime = 1f;
    public float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f);
    public float gravity => (-2f * maxJumpHeight) / Mathf.Pow(maxJumpTime / 2f, 2f);
    public Animator Animator;

    public bool grounded { get; private set; }
    public bool jumping { get; private set; }

    void Start()
    {
        respawnPoint = transform.position;
    }

    private void Awake()
    {
        camera = Camera.main;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!playerManager.isDead)
        {
            HorizontalMovement();

            grounded = rigidbody.Raycast(Vector2.down);

            if (grounded)
            {
                GroundedMovement();
            }
        }
        else
        {
            // PREVENT MOVING WHEN DEAD
            velocity.x = 0;
        }
        ApplyGravity();
    }

    private void HorizontalMovement()
    {
        inputAxis = Input.GetAxisRaw("Horizontal");
        velocity.x = inputAxis * moveSpeed;
        Animator.SetFloat("Speed", Mathf.Abs(inputAxis));
        if (jumping)
        {
            Animator.SetBool("isJumping", true);
            velocity.x *= 0.5f;
        }
        else
        {
            Animator.SetBool("isJumping", false);
        }


        flipSprite();
    }

    private void GroundedMovement()
    {
        // prevent gravity from infinitly building up
        velocity.y = Mathf.Max(velocity.y, 0f);
        jumping = velocity.y > 0f;

        // perform jump
        if (Input.GetButtonDown("Jump"))
        {
            AudioManagerScript.PlaySound("jump");
            velocity.y = jumpForce;
            jumping = true;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            AudioManagerScript.PlaySound("walk");
        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            AudioManagerScript.PlaySound("stop");
        }
    }

    private void ApplyGravity()
    {
        // check if falling
        bool falling = velocity.y < 0f || !Input.GetButton("Jump");
        float multiplier = falling ? 2f : 1f;

        // apply gravity and terminal velocity
        velocity.y += gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        position += velocity * Time.fixedDeltaTime;

        // clamp within the screen bounds
        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        position.x = Mathf.Clamp(position.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f);

        rigidbody.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("PowerUp"))
        {
            // stop vertical movement if RANGER bonks his head
            if (transform.DotTest(collision.transform, Vector2.up))
            {
                velocity.y = 0f;
            }
        }
    }


    private void flipSprite()
    {
        if ((inputAxis > 0 && isFacingRight) || (inputAxis < 0 && !isFacingRight))
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        FindStartPos();
    }

    void FindStartPos()
    {
        transform.position = GameObject.FindWithTag("StartPos").transform.position;
    }

}
