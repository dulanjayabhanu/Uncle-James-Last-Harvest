using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // movement speed
    public float runSpeed = 4f;
    public float walkSpeed = 2f;

    // assign the player rigidbody and animator objects
    private Rigidbody playerRigidBody;
    private Animator playerAnimator;

    // look forward or backward status
    private bool isLookForward;

    void Start()
    {
        playerRigidBody = this.GetComponent<Rigidbody>();
        playerAnimator= this.GetComponent<Animator>();

        isLookForward = true;
    }

    private void FixedUpdate()
    {
        float moveValue = Input.GetAxis("Horizontal");
        playerAnimator.SetFloat("Speed", Mathf.Abs(moveValue));

        float walkValue = Input.GetAxisRaw("Fire3");
        playerAnimator.SetFloat("Walk", walkValue);

        if (walkValue > 0)
        {
            playerRigidBody.velocity = new Vector3(moveValue * walkSpeed, playerRigidBody.velocity.y, 0);
        }
        else
        {
            playerRigidBody.velocity = new Vector3(moveValue * runSpeed, playerRigidBody.velocity.y, 0);
        }

        if (moveValue > 0 && !isLookForward)
        {
            PlayerFlip();
        }
        else if (moveValue < 0 && isLookForward)
        {
            PlayerFlip();
        }
    }

    private void PlayerFlip()
    {
        // toggle the facing direction
        isLookForward = !isLookForward;

        // rotate around Y axis by 180 degrees
        Vector3 currentRotation = this.transform.localEulerAngles;
        currentRotation.y += 180f;

        this.transform.localEulerAngles = currentRotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            Animator enemyAnimator = enemy.GetComponent<Animator>();

            if (!enemyAnimator.GetBool("Dead"))
            {
                MainGameLogic.gameLogicSingleton.audioSource.PlayOneShot(enemy.enemyDamageAudioClip);
            }

        }
    }
}
