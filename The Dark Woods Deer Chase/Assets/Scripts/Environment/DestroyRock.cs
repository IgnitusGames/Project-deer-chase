using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRock : MonoBehaviour
{
    private int rock_health = 1;
    // Start is called before the first frame update
    void Start()
    {
        
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
                rock_health -= 1;
            }
        }
    }
}
