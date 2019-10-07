using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScreen : MonoBehaviour
{
    public GameObject win_screen;
    public GameObject lose_screen;
    public GameObject death_screen;
    // Start is called before the first frame update
    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        print("GNAR" + Time.timeScale);
    }
    public void ActivateVictoryScreen()
    {
        win_screen.SetActive(true);
        Time.timeScale = 0;
    }
    public void ActivateDefeatScreen()
    {
        lose_screen.SetActive(true);
        Time.timeScale = 0;
    }
    public void ActivateDeathScreen()
    {
        death_screen.SetActive(true);
        Time.timeScale = 0;
    }
}