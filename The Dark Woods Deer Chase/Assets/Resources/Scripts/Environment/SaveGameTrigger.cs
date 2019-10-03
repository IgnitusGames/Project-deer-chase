using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGameTrigger : MonoBehaviour
{
    public bool is_checkpoint = true;

    private string current_level;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            current_level = SceneManager.GetActiveScene().name;
            if(is_checkpoint)
            {
                //save game met positie
            }
            else
            {
                //save game zonder positie
            }
        }
    }
}