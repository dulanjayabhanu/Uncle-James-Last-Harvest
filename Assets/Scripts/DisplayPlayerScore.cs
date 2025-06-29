using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayPlayerScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.SetText("Score " + MainGameLogic.gameLogicSingleton.score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
