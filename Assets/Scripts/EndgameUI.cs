using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndgameUI : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;

    public GameObject endMenuUI;

    void Start()
    {
        score = GetComponent<Text>();
        endMenuUI.SetActive(false);
    }

    void Update()
    {
        score.text = "Bandits stopped: " + scoreValue + "/3";

        if (scoreValue == 3)
        {
            WinOverlay();
        }

        if (Input.GetKey(KeyCode.O)) 
        {
            WinOverlay();
        }
    }

    public void WinOverlay()
    {
        Time.timeScale = 0f;
        endMenuUI.SetActive(true);
        scoreValue = 0;
    }

    public void BacktoMain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex);
        endMenuUI.SetActive(false);
    }
}
