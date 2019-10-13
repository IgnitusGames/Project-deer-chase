using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelreset : MonoBehaviour
{

    private PlayerLogic player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLogic>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.position = Vector3.zero;

        }
    }
}
