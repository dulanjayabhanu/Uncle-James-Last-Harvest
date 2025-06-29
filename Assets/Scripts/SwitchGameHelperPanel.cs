using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGameHelperPanel : MonoBehaviour
{
    public GameObject[] gameHelperPanels;
    
    private int currentPanelPosition = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchHelperPage()
    {
        if (currentPanelPosition < gameHelperPanels.Length)
        {
            // get the current active panel
            GameObject currentActivePanel = gameHelperPanels[currentPanelPosition];
            currentActivePanel.SetActive(false);

            // get the next panel
            GameObject nextHelperPanel = gameHelperPanels[currentPanelPosition + 1];
            nextHelperPanel.SetActive(true);
            
            currentPanelPosition++;
            
            if (currentPanelPosition == (gameHelperPanels.Length - 1))
            {
                currentPanelPosition = 0;
            }
        }
    }
}
