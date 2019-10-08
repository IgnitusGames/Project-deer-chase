using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public int gold_value;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerLogic>().GoldScore(gold_value);
            Destroy(this.gameObject);

            FindObjectOfType<AudioManager>().Play("Gold1");
        }
    }
}
