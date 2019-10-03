using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windtest : MonoBehaviour
{
    private PlayerLogic player;
    float windspeed = 100;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        ;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

        }
    }
}
