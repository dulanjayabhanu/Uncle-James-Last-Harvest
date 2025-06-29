using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCheckPoint : MonoBehaviour
{
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (MainGameLogic.gameLogicSingleton.pickedVegetableCount == 3)
            {
                MainGameLogic.gameLogicSingleton.killCount = 0;
                MainGameLogic.gameLogicSingleton.killCountText.SetText("Rats 00");

                MainGameLogic.gameLogicSingleton.pickedVegetableCount = 0;

                MainGameLogic.gameLogicSingleton.currentLevel += 1;
                MainGameLogic.gameLogicSingleton.levelText.SetText("Level " + MainGameLogic.gameLogicSingleton.currentLevel);

                MainGameLogic.gameLogicSingleton.health = 100;
                MainGameLogic.gameLogicSingleton.healthText.SetText("HP " + MainGameLogic.gameLogicSingleton.health);

                MainGameLogic.gameLogicSingleton.score += 2000;
                MainGameLogic.gameLogicSingleton.scoreText.SetText("Score " + MainGameLogic.gameLogicSingleton.score);

                MainGameLogic.gameLogicSingleton.audioSource.PlayOneShot(audioClip);
                
                if (MainGameLogic.gameLogicSingleton.currentLevel <= 3)
                {
                    MainGameLogic.gameLogicSingleton.messageText.SetText("Mission complete!!! Mission " + MainGameLogic.gameLogicSingleton.currentLevel + " : Rady for next fight...go! go!!!");
                    MainGameLogic.gameLogicSingleton.LoadLevel(MainGameLogic.gameLogicSingleton.currentLevel);
                }
                else
                {
                    MainGameLogic.gameLogicSingleton.messageText.SetText("Hurrayyy....!!!!. You beat all the rats...Happy harvesting James...!!!");

                    Invoke("SwitchToGameWin", 1f);
                }
            }
            else
            {
                MainGameLogic.gameLogicSingleton.messageText.SetText("You must have to picked all the vegetable packs...go! go!! go!!!");
            }
        }
    }

    private void SwitchToGameWin()
    {
        SceneManager.LoadScene("GameWin");
    }
}
