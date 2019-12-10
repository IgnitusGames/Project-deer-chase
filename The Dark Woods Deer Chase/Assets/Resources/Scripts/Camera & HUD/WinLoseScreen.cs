using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class WinLoseScreen : MonoBehaviour
{
    public GameObject win_screen;
    public GameObject lose_screen;
    public GameObject death_screen;

    private GameObject ui;
    private GameObject player;
    private GameObject score_text;
    private double final_score;
    // Start is called before the first frame update
    private void Start()
    {
        ui = GameObject.FindGameObjectWithTag("UI");
        player = GameObject.FindGameObjectWithTag("Player");
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
        //SaveData new_save = new SaveData(NewCompletedLevels(), GameManager.game_manager.tutorial_scales, GameManager.game_manager.level1_scales, GameManager.game_manager.level2_scales, false);
        //SaveSystem.SaveProgress(new_save);
        ui.SetActive(false);
        win_screen.SetActive(true);
        Time.timeScale = 0;
        score_text = GameObject.FindGameObjectWithTag("FinalScore");
        final_score = 3000 - Math.Floor(ui.GetComponentInChildren<TimeScoreDisplay>().time_counter) + player.GetComponent<PlayerLogic>().gold_score;
        score_text.GetComponent<Text>().text = "Final score: " + final_score;
    }
    public void ActivateDefeatScreen()
    {
        GameManager.game_manager.ResetLevelCollectables(SceneManager.GetActiveScene().name);
        ui.SetActive(false);
        lose_screen.SetActive(true);
        Time.timeScale = 0;
    }
    public void ActivateDeathScreen()
    {
        GameManager.game_manager.ResetLevelCollectables(SceneManager.GetActiveScene().name);
        ui.SetActive(false);
        death_screen.SetActive(true);
        Time.timeScale = 0;       
    }
    //private string[] NewCompletedLevels()
    //{
    //    string[] result = new string[GameManager.game_manager.save.completed_levels.Length];
    //    for(int current_level = 0; current_level < GameManager.game_manager.save.completed_levels.Length; current_level++)
    //    {
    //        result[current_level] = GameManager.game_manager.save.completed_levels[current_level];
    //    }
    //    result[result.Length - 1] = SceneManager.GetActiveScene().name;
    //    return result;
    //}
}