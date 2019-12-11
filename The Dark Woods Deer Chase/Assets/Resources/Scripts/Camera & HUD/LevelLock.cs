using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLock : MonoBehaviour
{
    //variables
    public int required_level_index;
    public GameObject lockImage;

    private void Start()
    {
        if(GameManager.game_manager.save.level_index < this.required_level_index)
        {
            this.gameObject.GetComponent<Button>().interactable = false;
            this.lockImage.SetActive(true);
        }
    }
    public void StartThisLevel(string level_name)
    {
        SceneManager.LoadScene(level_name);
    }
}
