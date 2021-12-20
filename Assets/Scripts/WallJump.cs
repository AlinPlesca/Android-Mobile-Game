using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : PlayerMovement
{
    public  void activateWallJump()
    {
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position,checkRadius,groundLayer);
        if(isTouchingFront == true && isGrounded ==false && dirX != 0)
        {
            wallSliding = true;
        }
        else 
        {
            wallSliding = false;
        }

        if(wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x,Mathf.Clamp(rb.velocity.y,-SlidingSpeed,float.MaxValue));
        }

        if(Input.GetKeyDown(KeyCode.Space) && wallSliding ==true )
        {
            wallJumping = true;
            Invoke("SetWalljumpingToFalse",wallJumpTime);
        }

        if(wallJumping == true)
        {
            rb.velocity = new Vector2(xWallForce * -dirX, yWallForce);
        }
    }

    void SetWalljumpingToFalse()
    {
        wallJumping = false;
    }
}
