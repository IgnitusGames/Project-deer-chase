using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockbackside : MonoBehaviour
{
    private PlayerLogic player_logic;
    private HealthComponent health;
    public int knock_back_pwr;
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


            if (contact_point == new Vector2(1.0f, 0.0f))
            {
                //StartCoroutine(player_logic.SlowDown(2.5f));
                StartCoroutine(player_logic.SlowDown(1.8f));
                StartCoroutine(player_logic.KnockBack(0.2f, knock_back_pwr, Vector2.left));
                FindObjectOfType<AudioManager>().Play("LoseSound");
                //StartCoroutine(player_logic.KnockUp(0.2f, 300, Vector2.up));
                // FindObjectOfType<AudioManager>().Play("ShroomKnockBack");

            }
        }
    }
}