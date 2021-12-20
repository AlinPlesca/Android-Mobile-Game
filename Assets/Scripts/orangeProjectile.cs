using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orangeProjectile : MonoBehaviour
{

    public float projectileSpeed;
    private Rigidbody2D rb;
    public PlayerMovement PL;
    public GameObject ImpactEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * projectileSpeed;

        if(PL.spriteR.flipX == true)
        {
             rb.velocity = -transform.right * projectileSpeed;
        }
    }
     
     void OnTriggerEnter2D(Collider2D collision)
     {
      Instantiate(ImpactEffect,transform.position,Quaternion.identity);
      Destroy(gameObject);
     }
}
