using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatTrigger : MonoBehaviour
{
    public float dirX, moveSpeed = 3f;
    public bool moveRight = true;
    public bool face_right = true;
    private Vector2 start_pos;
    public float range = 4;
    public bool open = false;


    //public float range = Transform.position.x - 4f;


    private void Start()
    {
        start_pos = gameObject.transform.position;
    }

    void Update()
    {

        {
            if (open == true)
            {
                if (transform.position.y > (start_pos.y + range))
                    moveRight = false;
                if (transform.position.y < (start_pos.y - range))
                    moveRight = true;

                if (moveRight)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);


                }
                else
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
                }
            }




        }
       
        //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;


    }
    public void Open()
    {
        open = true;
    }


}
