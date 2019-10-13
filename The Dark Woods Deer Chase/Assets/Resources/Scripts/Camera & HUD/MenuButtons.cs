using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void StartLevel(string level_name)
    {
        SceneManager.LoadScene(level_name);
    }
    public void StartEndlessMode()
    {
        SceneManager.LoadScene("Endless");
    }
}
