using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMan2 : MonoBehaviour
{
    public GameObject gameOverUI;
    public bool death = false;
    void Update()
    {
        if(death == true)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RetryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}