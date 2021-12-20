using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatformScript : MonoBehaviour
{
    public Rigidbody2D fallingPlatformRb;
    // Start is called before the first frame update
    void Start()
    {
        fallingPlatformRb.mass = 0;
        fallingPlatformRb.gravityScale = 0;
        fallingPlatformRb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
