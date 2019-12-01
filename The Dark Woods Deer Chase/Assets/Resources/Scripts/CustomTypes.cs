using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tutorial
{
    public string tutorial_name;
    public Sprite action_image;
    public Sprite result_image;
    [TextArea(3, 10)]
    public string[] sentences;
}
[System.Serializable]
public class SaveData
{
    public string world_level;
    public float[] player_poition;
    public bool[] collected_crystals;
    public int crystal_score;
    //public int player_level;
    public int player_health;
    public int gold_score;
    public bool save_is_checkpoint;
    public bool is_dummy_save;

    public SaveData(string level_name, Vector3 position, int crystal_score, int player_health, int gold_score, bool player_has_reached_checkpoint, bool[] collected_crystals, bool is_dummy)
    {
        this.world_level = level_name;
        this.player_poition = ConvertPosition(position);
        this.crystal_score = crystal_score;
        //this.player_level = player_level;
        this.player_health = player_health;
        this.gold_score = gold_score;
        this.save_is_checkpoint = player_has_reached_checkpoint;
        this.collected_crystals = collected_crystals;
        this.is_dummy_save = is_dummy;
    }
    private float[] ConvertPosition(Vector3 player_position)
    {
        if (player_position != null)
        {
            float[] converted_position = new float[3];
            converted_position[0] = player_position.x;
            converted_position[1] = player_position.y;
            converted_position[2] = player_position.z;
            return converted_position;
        }
        else
        {
            return new float[3];
        }
    }
}