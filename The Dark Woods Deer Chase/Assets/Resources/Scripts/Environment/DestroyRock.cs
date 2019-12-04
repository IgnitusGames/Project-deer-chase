using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRock : MonoBehaviour
{
    public int rock_health = 1;
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
            Destroy(this.gameObject);
            StartCoroutine(player_logic.SlowDown(2.5f));
        }
    }
}
