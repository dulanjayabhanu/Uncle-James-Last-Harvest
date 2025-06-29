using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    private Animator playerAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Animator enemyAnimator = collision.gameObject.GetComponent<Animator>();
        
        if (collision.gameObject.CompareTag("Enemy") && !enemyAnimator.GetBool("Dead") && !playerAnimator.GetBool("Dead"))
        {
            MainGameLogic.gameLogicSingleton.health -= 50;
            MainGameLogic.gameLogicSingleton.healthText.SetText("HP " + MainGameLogic.gameLogicSingleton.health);

            if (MainGameLogic.gameLogicSingleton.health <= 0)
            {
                playerAnimator.SetBool("Dead", true);

                Invoke("GameStop", 2f);
            }
        }
    }

    private void GameStop()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("GameOver");
    }
}
