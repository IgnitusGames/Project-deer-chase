﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Damage : MonoBehaviour
{
    private PlayerLogic player_logic;
    // Start is called before the first frame update
    void Start()
    {
        player_logic = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLogic>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector2 contact_point = collision.GetContact(0).normal;
            player_logic.player_speed = 0;
            if (contact_point == new Vector2(0.0f, -1.0f))
            {
                StartCoroutine(player_logic.SlowDown(0.5f));
                StartCoroutine(player_logic.KnockUp(0.2f, 150, Vector2.up));
                StartCoroutine(player_logic.KnockBack(0.2f, 750, Vector2.left));

            }
            else if (contact_point == new Vector2(1.0f, 0.0f))
            {
                StartCoroutine(player_logic.SlowDown(0.5f));
                StartCoroutine(player_logic.KnockUp(0.2f, 150, Vector2.up));
                StartCoroutine(player_logic.KnockBack(0.2f, 750, Vector2.left));
                // StartCoroutine(player_logic.KnockUp(0.2f, 150, Vector2.up));

                FindObjectOfType<AudioManager>().Play("LoseSound");
               

            }
        }
    }
}