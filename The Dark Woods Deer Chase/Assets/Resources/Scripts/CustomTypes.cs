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
    public int level_index;
    public bool is_dummy_save;
    public int tutorial_scales;
    public int level1_scales;
    public int level2_scales;
    public int level3_scales;

    public SaveData(int level_index, int levelt_scales, int level1_scales, int level2_scales, int level3_scales, bool is_dummy)
    {
        this.level_index = level_index;
        this.is_dummy_save = is_dummy;
        this.tutorial_scales = levelt_scales;
        this.level1_scales = level1_scales;
        this.level2_scales = level2_scales;
        this.level3_scales = level3_scales;
    }
}