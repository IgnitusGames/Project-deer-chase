using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseLogic : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject PauseMenuUI;
    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        IsPaused = false;
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        IsPaused = true;
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
        IsPaused = false;
    }
    public void ToggleCheatMode()
    {
        if(!GameManager.game_manager.cheat_mode_is_enabled)
        {
            if(GameManager.game_manager.cheat_mode_click_counter == 0)
            {
                GameManager.game_manager.cheat_mode_is_enabled = true;
            }
            else
            {
                GameManager.game_manager.cheat_mode_click_counter -= 1;
            }
        }
        else
        {
            GameManager.game_manager.cheat_mode_click_counter = 4;
            GameManager.game_manager.cheat_mode_is_enabled = false;
        }
        print(GameManager.game_manager.cheat_mode_is_enabled);
    }
}