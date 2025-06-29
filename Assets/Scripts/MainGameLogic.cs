using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainGameLogic : MonoBehaviour
{
    public int currentLevel = 1;
    public int killCount = 0;
    public int score = 0;
    public int health = 100;
    public int pickedVegetableCount = 0;

    public static MainGameLogic gameLogicSingleton;

    private GameObject currentPrefab;
    public Transform spawnPoint;
    public GameObject[] prefabLevels;
    public AudioSource audioSource;

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI killCountText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI messageText;

    public void Awake()
    {
        if (gameLogicSingleton == null)
        {
            gameLogicSingleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        LoadLevel(1);
    }

    public void LoadLevel(int targetLevelNumber)
    {
        switch (targetLevelNumber)
        {
            case (1):
                currentLevel = 1;
                killCount = 0;
                score = 0;
                health = 100;
                pickedVegetableCount = 0;

                LevelSpawn((targetLevelNumber - 1), 33.2f, 0f, 0f);
                
                levelText.SetText("Level " + currentLevel);
                scoreText.SetText("Score " + score);
                killCountText.SetText("Rats " + killCount);
                healthText.SetText("HP " + health);
                messageText.SetText("Your objective is get back vegetables from rats...");

                break;

            case (2):
                LevelSpawn((targetLevelNumber - 1), 1.85f, -0.05f, 0.06f);
                currentLevel = 2;
                break;

            case (3):
                LevelSpawn((targetLevelNumber - 1), 97.7f, 0.02f, 0.13f);
                currentLevel = 3;
                break;
        }
    }

    private void LevelSpawn(int prefabIndex, float offsetX, float offsetY, float offsetZ)
    {
        if (currentPrefab != null)
        {
            Destroy(currentPrefab);
            currentPrefab = null;
        }

        Vector3 spawnPosition = new Vector3(
            spawnPoint.transform.position.x + offsetX,
            spawnPoint.transform.position.y + offsetY,
            spawnPoint.transform.position.z + offsetZ);

        currentPrefab = Instantiate(prefabLevels[prefabIndex], spawnPosition, spawnPoint.rotation);
    }
}
