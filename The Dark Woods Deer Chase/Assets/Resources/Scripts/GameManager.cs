using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Level
{
    Tutorial,
    Level1,
    Level2,
    Level3
}
public class GameManager : MonoBehaviour
{
    public AudioSource ploink;
    public AudioSource powerPloink;
    public static GameManager game_manager { get; private set; }
    public int cheat_mode_click_counter = 4;
    public bool cheat_mode_is_enabled = false;
    public SaveData save;
    public int tutorial_scales;
    public int level1_scales;
    public int level2_scales;
    public int level3_scales;

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
        this.level3_scales = this.save.level3_scales;
        this.ResetLevelCollectables(SceneManager.GetActiveScene().name);
        Application.targetFrameRate = 300;
    }
    public void AddCollectable(string current_scene)
    {
        switch(current_scene)
        {
            case "Tutorial Level":
                this.tutorial_scales++;
                break;
            case "Level 1":
                this.level1_scales++;
                break;
            case "Level 2":
                this.level2_scales++;
                break;
            case "level3":
                this.level3_scales++;
                break;
            default:
                break;
        }
        int scale_amount = game_manager.GetCollectableAmount(SceneManager.GetActiveScene().name);
        if (scale_amount > 3)
        {
            powerPloink.Play();
        }
        else
        {
            ploink.Play();
        }
    }
    public void ResetLevelCollectables(string current_scene)
    {
        switch (current_scene)
        {
            case "Tutorial Level":
                this.tutorial_scales = 0;
                break;
            case "Level 1":
                this.level1_scales = 0;
                break;
            case "Level 2":
                this.level2_scales = 0;
                break;
            case "level3":
                this.level3_scales = 0;
                break;
            default:
                break;
        }
    }
    public int GetCollectableAmount(string current_scene)
    { 
        switch(current_scene)
        {
            case "Tutorial Level":
                return this.tutorial_scales;
            case "Level 1":
                return this.level1_scales;
            case "Level 2":
                return this.level2_scales;
            case "Level 3":
                return this.level3_scales;
            default:
                return 0;
        }
    }
}