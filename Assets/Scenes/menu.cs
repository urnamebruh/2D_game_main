using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void LoadScene(string SampleScene)
    {
        SceneManager.LoadScene(SampleScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
