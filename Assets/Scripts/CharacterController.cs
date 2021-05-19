using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Rigidbody2D playerRigidBody;
    public Animator playerAnimator;
    Vector2 movement;

    /// <summary>
    /// Used for input from the player
    /// </summary>
    public void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        playerAnimator.SetFloat("Horizontal", movement.x);
        playerAnimator.SetFloat("Vertical", movement.y);
        playerAnimator.SetFloat("Speed", movement.sqrMagnitude);
        // if moving right
        if(movement.x > 0)
        {
            playerAnimator.SetInteger("Direction",1);
        }
        // if moving left
        else if(movement.x < 0)
        {
            playerAnimator.SetInteger("Direction",3);
        }
        // if moving up
        else if(movement.y > 0)
        {
            playerAnimator.SetInteger("Direction",0);
        }
        // if moving down
        else if(movement.y < 0)
        {
            playerAnimator.SetInteger("Direction",2);
        }
        Debug.Log(movement);
    }
    /// <summary>
    /// Used to execute the input
    /// </summary>
    public void FixedUpdate()
    {
        playerRigidBody.MovePosition(playerRigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
