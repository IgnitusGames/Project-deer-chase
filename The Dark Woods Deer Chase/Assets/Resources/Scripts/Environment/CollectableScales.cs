﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectableScales : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.game_manager.AddCollectable(SceneManager.GetActiveScene().name);
        }
    }
}