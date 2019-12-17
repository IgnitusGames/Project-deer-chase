using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlockCheat : MonoBehaviour
{
    public GameObject[] levels;

    private int canUnlockCounter = 0;
    public void UnlockAllLevels()
    {
        if(canUnlockCounter < 2)
        {
            canUnlockCounter++;
        }
        else
        {
            SaveSystem.CreateCheatSave();
            GameManager.game_manager.save = SaveSystem.LoadProgress();
            foreach (GameObject level in levels)
            {
                level.GetComponent<LevelLock>().Unlock();
            }
        }
    }
}
