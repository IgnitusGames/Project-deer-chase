using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRock : MonoBehaviour
{
    private int rock_health = 1;
    private PlayerLogic player_logic;
    // Start is called before the first frame update
    void Start()
    {
        player_logic = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLogic>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (rock_health == 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                StartCoroutine(collision.gameObject.GetComponent<PlayerLogic>().KnockBack(0.2f, 1500, Vector2.left));
                StartCoroutine(player_logic.SlowDown(2.0f));
                StartCoroutine(player_logic.KnockBack(0.2f, 750, Vector2.left));
                rock_health -= 1;
            }
        }
    }
}
