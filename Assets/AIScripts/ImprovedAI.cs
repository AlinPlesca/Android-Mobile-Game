using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float huntView;
    [SerializeField] private Animator anim;

    public enum moveState
    {
        Idle, Running
    }

    moveState state;

    private bool facingRight;
    public PlayerMovement PM;
   
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y < 0.5)
        {
            if (Vector3.Distance(player.position, transform.position) < huntView && PM.isGrounded)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

                if (player.position.x > transform.position.x && !facingRight) //if the target is to the right of enemy and the enemy is not facing right
                    Flip();

                if (player.position.x < transform.position.x && facingRight)
                    Flip();
            }
        }
        UpdateAnims();
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingRight = !facingRight;
    }

    public void UpdateAnims()
    {
        if (PM.isGrounded)
        {
            state = moveState.Running;
        }
        else if (!PM.isGrounded)
        {
            state = moveState.Idle;
        }
        anim.SetInteger("State", (int)state);
    }
}

