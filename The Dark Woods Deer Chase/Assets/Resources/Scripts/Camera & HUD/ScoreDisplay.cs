using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreDisplay : MonoBehaviour



{
    public static int score_value = 0;
    public float time_counter;
    public GameObject time_ui;
    public GameObject score_ui;
    private PlayerLogic player;
    Text gold_score;
   // Text time_score;

    // Start is called before the first frame update
    void Start()
    {
        gold_score = GetComponent<Text>();
       // time_score = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        //time_counter -= Time.deltaTime;

        gold_score.text = "Gold Score: " + player.gold_score;
       // time_score.text = "Time :" + time_counter;

    }
}
