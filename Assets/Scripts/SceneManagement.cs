using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void StartGameWin()
    {
        SceneManager.LoadScene("GameWin");
    }

    public void StartMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
