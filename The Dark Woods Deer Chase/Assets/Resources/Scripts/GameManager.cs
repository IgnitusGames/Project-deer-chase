using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager game_manager { get; private set; }
    public int cheat_mode_click_counter = 4;
    public bool cheat_mode_is_enabled = false;
    public SaveData save;
    public int tutorial_scales;
    public int level1_scales;
    public int level2_scales;

    private string[] unlocked_levels = new string[0];
    private void Awake()
    {
        if (game_manager == null)
        {
            game_manager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        this.save = SaveSystem.LoadProgress();
        this.tutorial_scales = this.save.tutorial_scales;
        this.level1_scales = this.save.level1_scales;
        this.level2_scales = this.save.level2_scales;
        Application.targetFrameRate = 300;
    }
    public void AddCollectable(string current_scene)
    {
        switch(current_scene)
        {
            case "tutorial":
                this.tutorial_scales++;
                break;
            case "level1":
                this.level1_scales++;
                break;
            case "level2":
                this.level2_scales++;
                break;
            default:
                break;
        }
    }
    public void ResetLevelCollectables(string current_scene)
    {
        switch (current_scene)
        {
            case "tutorial":
                this.tutorial_scales = 0;
                break;
            case "level1":
                this.level1_scales = 0;
                break;
            case "level2":
                this.level2_scales = 0;
                break;
            default:
                break;
        }
    }
}