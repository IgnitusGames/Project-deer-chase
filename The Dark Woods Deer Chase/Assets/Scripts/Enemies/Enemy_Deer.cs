using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Deer : MonoBehaviour
{
    public bool awake = false;
    public float distance;
    public float wakeRange;
    public bool is_grounded = false;
    public int jump_power = 500;
    public int jump_power2 = 800;
    public int EnemySpeed;
    public int XMoveDirection;
    public bool facingRight = false;
    private PlayerLogic player;
    public float wait =5;
    public Transform target;
    public int jump_power3 = 200;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLogic>();
        Flip();
    }

    void Update()
    {
        RangeCheck();
      if(is_grounded == true && awake == true)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        }
        
    }

    //Flip op collision met muur, damage op collision player
    //private void OnCollisionEnter2D(Collision2D collision2d)
    //{
    //    if (collision2d.gameObject.tag == "Player")
    //    {

    //        collision2d.gameObject.GetComponent<Player_Health_Collectible>().Damage(1);
    //    }


    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Attack")
        {

            FindObjectOfType<AudioManager>().Play("EnemyShroomDashOnDmg");
            print("pannenkoekn");
            gameObject.GetComponent<Animation>().Play("dmgtaken");
        }
     
        if (collision.gameObject.tag == "jump_deer")
        {
            //is_grounded = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
            print(collision.gameObject.tag);
            is_grounded = false;
            // EnemySpeed = 0;
            print("jump1");
            Jump();
            //  is_grounded = false;
            // Debug.Log("op de grond");
        }
        if (collision.gameObject.tag == "jump_deer2")
        {
            //is_grounded = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
            print(collision.gameObject.tag);
            is_grounded = false;
            // EnemySpeed = 0;
            print("jump2");
            Jump2();
            //  is_grounded = false;
            // Debug.Log("op de grond");\
        }

            if (collision.gameObject.tag == "jump_deer3")
            {
                //is_grounded = true;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
                print(collision.gameObject.tag);
                is_grounded = false;

            print("jump3");
                // EnemySpeed = 0;
                Jump3();
                //  is_grounded = false;
                // Debug.Log("op de grond");
            }


        }


   
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
 
        if (collision.gameObject.tag == "Ground")
        {
            //is_grounded = true;
            //  gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
            // print(collision.gameObject.tag);
            //EnemySpeed = 0;
            is_grounded = true;
            print(" awtawtetw");
            // Debug.Log("op de grond");
        }
    }

    private void Wake()
    {
        
    }

    void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
            facingRight = false;
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
        else
        {
            XMoveDirection = 1;
            facingRight = false;
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

      //  print(distance);

        if (distance < wakeRange)
        {


            awake = true;
           
            //lookingRight = true;
           


            if (target.transform.position.x < transform.position.x)
            {
                //animator.SetBool("attackleft", true);
                //animator.SetBool("attackright", false);
                //animator.SetBool("idle", false);

            }
            else if (target.transform.position.x > transform.position.x)
            {
                //animator.SetBool("attackright", true);
                //animator.SetBool("attackleft", false);
                //animator.SetBool("idle", false);
            }


            //Attack(true);
        }
        //else animator.SetBool("idle", true);
        // animator.SetBool("attackleft", false);
        // animator.SetBool("attackright", false);


        if (distance > wakeRange)
        {
            awake = false;
        //   animator.SetBool("idle", true);
        }


    }

    void Jump()
    {

       
 
            is_grounded = false;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump_power);
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 50);
   

    }
    void Jump2()
    {

            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump_power2);
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 50);

    }
    void Jump3()
    {

     
            is_grounded = false;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump_power3);
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 50);
 

    }
    public IEnumerator MoveUitzetten()
    {
        yield return new WaitForSeconds(wait);


    }
}

