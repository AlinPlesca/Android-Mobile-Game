using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer spriteR;
    public BoxCollider2D playerCollider;
    public Transform feet;

    [SerializeField] public LayerMask CanJumpOnTheGround;
    public LayerMask groundLayer;

    public float dirX = 0f;


    public float playerSpeed = 7f;
    public float jumpForce = 12f;
    public int extraJumps = 0;
    int jumpCount = 0;
    public bool isGrounded;

    public  bool isTouchingFront;
    public Transform frontCheck;
    public  bool wallSliding;
    public float SlidingSpeed;
    public float checkRadius;

    public bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;
  
    public float jumpCooldown;

    public enum moveState { Idle, Running, Jumping, Falling }

    public WallJump WJ;
    
    public bool ActivateDoubleJumpForever;

    [SerializeField]
    private AudioSource JumpEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteR = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<BoxCollider2D>();
        WJ.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //dirX = SimpleInput.GetAxisRaw("Horizontal");
        dirX = CrossPlatformInputManager.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * playerSpeed, rb.velocity.y);

        /*
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        */

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Jump();
        }

        checkGround();
        UpdateAnimation();
        WJ.activateWallJump();
    }

    public void Jump()
    {
        if (isGrounded == true || jumpCount < extraJumps)
        {
            jumpCount++;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
            JumpEffect.Play();
        }
    }

    public void UpdateAnimation()
    {
        moveState state;
        if (dirX > 0f)
        {
            state = moveState.Running;
            spriteR.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = moveState.Running;
            spriteR.flipX = true;
        }
        else
        {
            state = moveState.Idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = moveState.Jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = moveState.Falling;
        }
        anim.SetInteger("State", (int) state);
    }

    //private bool IsOnTheGround()
    //{
    //   return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, 0.1f, CanJumpOnTheGround);
    
    //}

    public  void checkGround()
    {
        if (Physics2D.OverlapCircle(feet.position, 0.3f, groundLayer))
        {
            isGrounded = true;
            jumpCount = 0;
            jumpCooldown = Time.time + 0.09f;
        }
        else if (Time.time < jumpCooldown)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
