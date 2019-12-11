using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLock : MonoBehaviour
{
    //variables
    public int required_level_index;

    private bool is_locked = true;

    private void Start()
    {
        if(GameManager.game_manager.save.level_index >= this.required_level_index)
        {
            this.is_locked = false;
        }
        print(this.is_locked);
    }
    public void StartThisLevel(string level_name)
    {
        print("klik");
        if(!this.is_locked)
        {
            SceneManager.LoadScene(level_name);
        }
    }
}
