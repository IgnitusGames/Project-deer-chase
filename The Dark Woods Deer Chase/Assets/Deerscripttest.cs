using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deerscripttest : MonoBehaviour
{
    //Variables

    //public Animator animator;
    public int player_speed = 15;

    public int jump_power = 250;
    public int jump_power2 = 500;
    public int jump_power3 = 750;

    public bool is_grounded = true;
    public bool jump;
    public bool gliding = false;
   
  

    public float windspeed = 100;
    public float slow_speed = 5;
    // Update is called once per frame
    private void Start()
    {

    }
    private void Update()
    {
        Movement();
 
     

        //Attacks
        //Death Scenarios
   
        ////Animations
        //if (is_grounded == false)
        //{
        // //   animator.SetBool("is_jumping", true);
        //}
        //if (is_grounded == true)
        //{
        // //  animator.SetBool("is_jumping", false);
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Resets player jump ability when player has hit the ground
        if (collision.gameObject.tag == "Ground" && collision.gameObject.tag == "movplat")
        {
            is_grounded = true;
            
        }
        if (collision.gameObject.tag == "movplat")
        {
            player_speed = 0;
            is_grounded = true;
            this.transform.parent = collision.transform;
            Debug.Log("op platform");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "jump_deer")
        {
            print("lekkerspringen");
            Jump();
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "movplat")
            this.transform.parent = null;
        //Check if player is no longer on the ground
        if (col.gameObject.tag == "Ground" && col.gameObject.tag == "movplat")
        {
            print("niet op grond");
            is_grounded = false;
        }
        player_speed = 15;
    }


   
    public void Jump()
    {
        //check if jumping is allowed
        
          is_grounded = false;
          this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(this.gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
          this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump_power);
       
    }
    public void Jump2()
    {
        //check if jumping is allowed

        is_grounded = false;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(this.gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump_power2);

    }
    public void Jump3()
    {
        //check if jumping is allowed

        is_grounded = false;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(this.gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump_power3);

    }
    private void Movement()
    {
        //animator.SetFloat("Speed", Mathf.Abs(player_speed));
        //Automatically move the player forwards
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(player_speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
   

}