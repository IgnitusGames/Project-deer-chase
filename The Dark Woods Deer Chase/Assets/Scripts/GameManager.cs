using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager game_manager { get; private set; }
    public int cheat_mode_click_counter = 4;
    public bool cheat_mode_is_enabled = false;
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
}
