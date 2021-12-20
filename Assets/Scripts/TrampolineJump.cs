using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineJump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float JumpVelocity = 20f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BoosterElements"))
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpVelocity);
        }
    }
}
