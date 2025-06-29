using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetablePicker : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MainGameLogic.gameLogicSingleton.score += 1000;
            MainGameLogic.gameLogicSingleton.scoreText.SetText("Score " + MainGameLogic.gameLogicSingleton.score);

            MainGameLogic.gameLogicSingleton.pickedVegetableCount += 1;

            string message = "";

            if (MainGameLogic.gameLogicSingleton.pickedVegetableCount != 3)
            {
                message = "You picked " + MainGameLogic.gameLogicSingleton.pickedVegetableCount + " vegetable pack";
            }
            else
            {
                message = "Great job, Now deliver this packs to the van, hurray Up!!!";
            }

            MainGameLogic.gameLogicSingleton.audioSource.PlayOneShot(audioClip);

            MainGameLogic.gameLogicSingleton.messageText.SetText(message);
            Destroy(this.gameObject);
        }
    }
}
