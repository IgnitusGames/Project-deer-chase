using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager game_manager { get; private set; }

    public Vector3 player_position;
    public int player_health;
    public int player_level;
    public int crystal_score;
    public int gold_score;
    public bool player_has_reached_checkpoint;

    private void Awake()
    {
        if(game_manager == null)
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
