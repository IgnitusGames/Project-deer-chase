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
    public string[] completed_levels;
    public bool is_dummy_save;

    public SaveData(string[] completed_levels,bool is_dummy)
    {
        this.completed_levels = completed_levels;
        this.is_dummy_save = is_dummy;
    }
    //private float[] ConvertPosition(Vector3 player_position)
    //{
    //    if (player_position != null)
    //    {
    //        float[] converted_position = new float[3];
    //        converted_position[0] = player_position.x;
    //        converted_position[1] = player_position.y;
    //        converted_position[2] = player_position.z;
    //        return converted_position;
    //    }
    //    else
    //    {
    //        return new float[3];
    //    }
    //}
}