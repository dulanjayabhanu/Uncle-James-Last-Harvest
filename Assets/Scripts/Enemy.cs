using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip enemyDamageAudioClip;
    public AudioClip enemyDeadAudioClip;
    private float actionDelay = 2f;
    private int hitCount = 0;

    private Animator enemyAnimator;

    private void Start()
    {
        enemyAnimator = this.GetComponent<Animator>();
    }

    public void TakeDamage()
    {
        hitCount++;

        if (hitCount >= 6)
        {
            if (MainGameLogic.gameLogicSingleton != null)
            {
                MainGameLogic.gameLogicSingleton.killCount++;

                string killCountText = "Rats " + (MainGameLogic.gameLogicSingleton.killCount < 10 ? "0" + MainGameLogic.gameLogicSingleton.killCount : "" + MainGameLogic.gameLogicSingleton.killCount);
                MainGameLogic.gameLogicSingleton.killCountText.SetText(killCountText);

                MainGameLogic.gameLogicSingleton.score += 100;
                MainGameLogic.gameLogicSingleton.scoreText.SetText("Score " + MainGameLogic.gameLogicSingleton.score);

                MainGameLogic.gameLogicSingleton.audioSource.PlayOneShot(enemyDeadAudioClip);
                
                Rigidbody enemyRigidBody = gameObject.GetComponent<Rigidbody>();
                enemyRigidBody.isKinematic = true;

                Collider enemyCollider = gameObject.GetComponent<Collider>();
                enemyCollider.isTrigger = true;
            }

            enemyAnimator.SetBool("Dead", true);

            Destroy(gameObject, actionDelay);
            hitCount = 0;
        }
    }
}
