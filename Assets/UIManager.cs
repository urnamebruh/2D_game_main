using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool isPaused = false;
    public static bool isSlowed = false;
    public bool FixedVoid = true;
    void Update()
    {
        if(FixedVoid == true)
        {
            pauseMenuUI.SetActive(false);
            FixedVoid = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused) ResumeGame();
            else PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isSlowed) ResumeTime();
            else PauseTime();
        }
    }
    // SLOWSLOWSLOWSLOWSLOWSLOWSLOWSLOWSLOWSLOWSLOWSLOWSLOWSLOWSLOWSLOWSLOWSLOWSLOWSLOWSLOWSLOWSLOWSLOWSLOW
    public void ResumeTime()
    {
        Time.timeScale = 1f;
        isSlowed = false;
    }
    void PauseTime()
    {
        Time.timeScale = 0.4f;
        isSlowed = true;
    }


    // PAUSEPAUSEPAUSEPAUSEPAUSEPAUSEPAUSEPAUSEPAUSEPAUSEPAUSEPAUSEPAUSEPAUSEPAUSEPAUSEPAUSEPAUSEPAUSEPAUSE
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game");
        Application.Quit();
    }
}
