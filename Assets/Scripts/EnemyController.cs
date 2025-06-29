using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject flipEnemy;
    public AudioClip enemyDetectedAudioClip;

    public float detectionTime = 1f;
    public float startRun = 1f;
    private bool firstDetection;

    public float runSpeed = 4f;
    public float walkSpeed = 1.5f;
    public bool isLookForward = true;

    private float moveSpeed;
    private bool running;

    private Rigidbody enemyRigidbody;
    private Animator enemyAnimator;
    private Transform detectedPlayer;

    private bool detected;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = this.GetComponent<Animator>();
        enemyRigidbody = this.GetComponent<Rigidbody>();

        running = false;
        detected = false;
        firstDetection = false;
        moveSpeed = walkSpeed;
    }

    private void FixedUpdate()
    {
        if (detected)
        {
            if (detectedPlayer.position.x < transform.position.x && isLookForward)
            {
                EnemyFlip();
            }
            else if (detectedPlayer.position.x > transform.position.x && !isLookForward)
            {
                EnemyFlip();
            }

            if (!firstDetection)
            {
                startRun = Time.time + detectionTime;
                firstDetection = true;
            }

            if (isLookForward)
            {
                enemyRigidbody.velocity = new Vector3(moveSpeed, enemyRigidbody.velocity.y, 0);
            }
            else
            {
                enemyRigidbody.velocity = new Vector3(-moveSpeed, enemyRigidbody.velocity.y, 0);
            }

            if (!running && Time.time >= startRun)
            {
                moveSpeed = runSpeed;
                enemyAnimator.SetTrigger("Run");
                running = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !detected)
        {
            detected = true;
            detectedPlayer = other.transform;
            enemyAnimator.SetBool("Detected", true);

            if (detectedPlayer.position.x < this.transform.position.x && isLookForward)
            {
                EnemyFlip();
            }
            else if (detectedPlayer.position.x > this.transform.position.x && !isLookForward)
            {
                EnemyFlip();
            }

            MainGameLogic.gameLogicSingleton.audioSource.PlayOneShot(enemyDetectedAudioClip);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            firstDetection = false;

            if (running)
            {
                enemyAnimator.SetTrigger("Run");
                moveSpeed = walkSpeed;
                running = false;
            }
        }
    }

    void EnemyFlip()
    {
        // toggle the facing direction
        isLookForward = !isLookForward;

        // rotate arounf Y axis by 180 degrees
        Vector3 currentRoration = this.transform.localEulerAngles;
        currentRoration.y += 180f;
        
        this.transform.localEulerAngles = currentRoration;
    }
}
