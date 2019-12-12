using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLock : MonoBehaviour
{
    //variables
    public Level level;
    public bool isTutorial;
    public bool isFinalLevel;
    public int required_level_index;
    public GameObject lockImage;
    public GameObject emptyCrystal;
    public Sprite crystalImage;
    public GameObject scaleScore;
    public Sprite[] numbers;

    private void Start()
    {
        if(GameManager.game_manager.save.level_index < this.required_level_index)
        {
            this.gameObject.GetComponent<Button>().interactable = false;
            this.lockImage.SetActive(true);
        }
        if(!this.isTutorial)
        {
            if (GameManager.game_manager.save.level_index > this.required_level_index)
            {
                this.emptyCrystal.GetComponent<Image>().sprite = this.crystalImage;
            }
            switch(level)
            {
                case Level.Level1:
                    this.scaleScore.GetComponent<Image>().sprite = this.numbers[GameManager.game_manager.level1_scales];
                    break;
                case Level.Level2:
                    this.scaleScore.GetComponent<Image>().sprite = this.numbers[GameManager.game_manager.level2_scales];
                    break;
                case Level.Level3:
                    this.scaleScore.GetComponent<Image>().sprite = this.numbers[GameManager.game_manager.level3_scales];
                    break;
                default:
                    break;
            }
        }
    }
    public void StartThisLevel(string level_name)
    {
        SceneManager.LoadScene(level_name);
    }
}
