using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour
{


    public float moveSpeed = 3f;
    




    void Update()
    {

            
            
      }

    private void OnTriggerEnter2D(Collider2D trig)
    {

        if (trig.gameObject.tag == "EnemyCollider")
        {
            Stop();
            print("asdasd");
        }

    }
    public void Open()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
    }
    void Stop()
    {
        moveSpeed = 0;
    }
}