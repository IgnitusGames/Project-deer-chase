using System.Collections;
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

    // Update is called once per frame
    void Update()
    {
        //print(player_logic.transform.position);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<Player_Health_Collectible>().Damage(1);

            //StartCoroutine(player_logic.KnockBack(0.02f, 350, player_logic.transform.position));


        }
    }
}