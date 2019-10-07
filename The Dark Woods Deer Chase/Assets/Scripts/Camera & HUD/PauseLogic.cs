using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseLogic : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
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