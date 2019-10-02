using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public float dirX, moveSpeed = 3f;
   public bool moveRight = true;
   public bool face_right = true;
    private Quaternion start_pos;

    //public float range = Transform.position.x - 4f;


    private void Start()
    {
        start_pos = transform.rotation;
    }

    void Update()
    {
        print(start_pos);
        //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;

        if (transform.position.x > (start_pos.x + 4f))
            moveRight = false;
        if (transform.position.x < (start_pos.x - 4f))
            moveRight = true;

        if (moveRight)
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
    }

   
    
    //void Flip()
    //{
    //    if (face_right == true)
    //    {
    //        //dirX = -1;
    //        //facingRight = !facingRight;
    //        moveRight = false;
    //        face_right = !face_right;
          
    //    }
    //    else
    //    {
    //        //// XMoveDirection = 1;
    //        // facingRight = false;
    //        face_right = true;
    //        moveRight = true;
     
    //    }
    //}
}

