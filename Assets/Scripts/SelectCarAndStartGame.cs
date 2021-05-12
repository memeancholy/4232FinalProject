using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCarAndStartGame : MonoBehaviour
{

    public void Start()
    {
        Time.timeScale = 0f;
        Debug.Log("Time has stopped");
    }

    public void FromDesertToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex);
    }

    public void FromCityToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void StartRacing()
    {
        Time.timeScale = 1f;
        Debug.Log("Time has started");
    }
}
