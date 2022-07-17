using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    private bool showTutorialImg;
    [SerializeField] private GameObject tutorialImg;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            showTutorialImg = !showTutorialImg;
        }

        if (showTutorialImg)
        {
            Time.timeScale = 0f;
            tutorialImg.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            tutorialImg.SetActive(false);
        }
    }
}
