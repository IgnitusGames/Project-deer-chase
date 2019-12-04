using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveProgress(SaveData data_to_save)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string save_path = Application.persistentDataPath + "/the_dark_woods.save";
        FileStream file_stream = new FileStream(save_path, FileMode.Create);
        formatter.Serialize(file_stream, data_to_save);
        file_stream.Close();
    }
    public static SaveData LoadProgress()
    {
        string save_path = Application.persistentDataPath + "/the_dark_woods.save";
        if(File.Exists(save_path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file_stream = new FileStream(save_path, FileMode.Open);
            SaveData saved_data = formatter.Deserialize(file_stream) as SaveData;
            file_stream.Close();
            return saved_data;
        }
        else
        //create empty save file if one does not exist
        {
            CreateDummySave();
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream second_file_stream = new FileStream(save_path, FileMode.Open);
            SaveData saved_data = formatter.Deserialize(second_file_stream) as SaveData;
            second_file_stream.Close();
            return saved_data;
        }
    }
    public static void CreateDummySave()
    {
        string save_path = Application.persistentDataPath + "/the_dark_woods.save";
        Debug.Log("Creating empty save file");
        SaveData dummy_save = new SaveData(new string[0], true);
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file_stream = new FileStream(save_path, FileMode.Create);
        formatter.Serialize(file_stream, dummy_save);
        file_stream.Close();
    }
}
