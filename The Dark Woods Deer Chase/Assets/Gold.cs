using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public int gold_value;
    private PlayerLogic player_logic;
    // Start is called before the first frame update
    void Start()
    {
        player_logic = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLogic>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerLogic>().GoldScore(gold_value);
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().Play("Gold1");
        }
        //    print(player_logic.gold_score);
        //}
        //if (collision.gameObject.tag == "Player" && player_logic.gold_score > 25 && player_logic.gold_score < 28)
        //{
        //    FindObjectOfType<AudioManager>().Play("100gold");
        //}
        //if (collision.gameObject.tag == "Player" && player_logic.gold_score > 50 && player_logic.gold_score < 53)
        //{
        //    FindObjectOfType<AudioManager>().Play("200gold");
        //    print("50 plus");
        //}
        //if (collision.gameObject.tag == "Player" && player_logic.gold_score > 75 && player_logic.gold_score < 78)
        //{
        //    FindObjectOfType<AudioManager>().Play("300gold");
        //}
        //if (collision.gameObject.tag == "Player" && player_logic.gold_score > 100 && player_logic.gold_score < 103)
        //{
        //    FindObjectOfType<AudioManager>().Play("400gold");
        //}
        //if (collision.gameObject.tag == "Player" && player_logic.gold_score > 125 && player_logic.gold_score < 128)
        //{
        //    FindObjectOfType<AudioManager>().Play("500gold");
        //}
        //if (collision.gameObject.tag == "Player" && player_logic.gold_score > 150 && player_logic.gold_score < 153)
        //{
        //    FindObjectOfType<AudioManager>().Play("600gold");
        //}



    }
}
