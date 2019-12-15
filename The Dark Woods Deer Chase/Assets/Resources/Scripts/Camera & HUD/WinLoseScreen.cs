﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class WinLoseScreen : MonoBehaviour
{
    public GameObject edge;
    public GameObject win_screen;
    public GameObject lose_screen;
    public GameObject death_screen;
    public int next_level_index;

    private GameObject ui;
    private GameObject player;
    private GameObject deer;
    private double final_score;
    // Start is called before the first frame update
    private void Start()
    {
        ui = GameObject.FindGameObjectWithTag("UI");
        player = GameObject.FindGameObjectWithTag("Player");
        deer = GameObject.FindGameObjectWithTag("deer");
    }
    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        GameManager.game_manager.save = SaveSystem.LoadProgress();
        SceneManager.LoadScene("Menu");
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ActivateVictoryScreen()
    {
        player.GetComponent<PlayerLogic>().player_speed = 0;
        deer.GetComponent<Deerscripttest>().player_speed = 0;
        //player is replaying a level
        if (this.next_level_index <= GameManager.game_manager.save.level_index)
        {
            //if player got more collectables
            if(GameManager.game_manager.tutorial_scales > GameManager.game_manager.save.tutorial_scales || GameManager.game_manager.level1_scales > GameManager.game_manager.save.level1_scales || GameManager.game_manager.level2_scales > GameManager.game_manager.save.level2_scales || GameManager.game_manager.level3_scales > GameManager.game_manager.save.level3_scales)
            {
                SaveData new_save = new SaveData(GameManager.game_manager.save.level_index, GameManager.game_manager.tutorial_scales, GameManager.game_manager.level1_scales, GameManager.game_manager.level2_scales, GameManager.game_manager.level3_scales, false); ;
                SaveSystem.SaveProgress(new_save);
            }
            else
            {
                SaveData new_save = GameManager.game_manager.save;
                SaveSystem.SaveProgress(new_save);
            }
        }
        //first play
        else
        {
            SaveData new_save = new SaveData(this.next_level_index, GameManager.game_manager.tutorial_scales, GameManager.game_manager.level1_scales, GameManager.game_manager.level2_scales, GameManager.game_manager.level3_scales, false);
            SaveSystem.SaveProgress(new_save);
        }
        ui.SetActive(false);
        edge.SetActive(true);
        win_screen.SetActive(true);
    }
    public void ActivateDefeatScreen()
    {
        player.GetComponent<PlayerLogic>().player_speed = 0;
        deer.GetComponent<Deerscripttest>().player_speed = 0;
        GameManager.game_manager.ResetLevelCollectables(SceneManager.GetActiveScene().name);
        ui.SetActive(false);
        edge.SetActive(true);
        lose_screen.SetActive(true);
    }
    public void ActivateDeathScreen()
    {
        player.GetComponent<PlayerLogic>().player_speed = 0;
        deer.GetComponent<Deerscripttest>().player_speed = 0;
        GameManager.game_manager.ResetLevelCollectables(SceneManager.GetActiveScene().name);
        ui.SetActive(false);
        edge.SetActive(true);
        death_screen.SetActive(true);    
    }
}