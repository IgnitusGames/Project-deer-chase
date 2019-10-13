using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform portal_2_pos;
    private PlayerLogic player;
   // private Vector2 portal2_pos;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLogic>();
        //portal2_pos = GameObject.FindGameObjectWithTag("Portal2").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * -3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Portal");
            // player.transform.position = portal2_pos;
            player.transform.position = portal_2_pos.position;
        }
    }
}
