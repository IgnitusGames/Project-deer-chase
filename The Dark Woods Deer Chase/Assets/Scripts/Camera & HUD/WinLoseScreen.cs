using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScreen : MonoBehaviour
{
    public GameObject win_screen;
    public GameObject lose_screen;
    public GameObject death_screen;
    private GameObject ui;
    // Start is called before the first frame update
    private void Start()
    {
        ui = GameObject.FindGameObjectWithTag("UI");
    }
    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ActivateVictoryScreen()
    {
        ui.SetActive(false);
        win_screen.SetActive(true);
        Time.timeScale = 0;
    }
    public void ActivateDefeatScreen()
    {
        ui.SetActive(false);
        lose_screen.SetActive(true);
        Time.timeScale = 0;
    }
    public void ActivateDeathScreen()
    {
        ui.SetActive(false);
        death_screen.SetActive(true);
        Time.timeScale = 0;
    }
}