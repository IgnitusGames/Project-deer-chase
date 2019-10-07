using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deerscripttest : MonoBehaviour
{
    //Variables

    public Animator animator;
    public int player_speed = 15;

    public int jump_power = 250;
    public int jump_power2 = 500;
    public int jump_power3 = 750;
    public int XMoveDirection;
    public bool facingRight = false;
    public bool is_grounded = true;
    public bool jump;
    public bool gliding = false;
   
  

    public float windspeed = 100;
    public float slow_speed = 5;

    private GameObject win_lose_canvas;
    // Update is called once per frame
    private void Start()
    {
        Flip();
        StartCoroutine(CheckDistance());
        win_lose_canvas = GameObject.FindGameObjectWithTag("WinLose");
    }
    private void Update()
    {
        Movement();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Resets player jump ability when player has hit the ground
        if (collision.gameObject.tag == "Ground")
        {
            is_grounded = true;
            animator.SetBool("is_walking", true);
            animator.SetBool("is_jumping", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "jump_deer")
        {
            
            Jump();
        }
        if (collision.gameObject.tag == "jump_deer2")
        {
        
            Jump2();

        }
        if (collision.gameObject.tag == "jump_deer3")
        {
           
            Jump3();
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

        animator.SetBool("is_jumping", true);
        animator.SetBool("is_walking", false);
    }
    public void Jump2()
    {
        //check if jumping is allowed

        is_grounded = false;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(this.gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump_power2);
        animator.SetBool("is_jumping", true);
        animator.SetBool("is_walking", false);

    }
    public void Jump3()
    {
        //check if jumping is allowed

        is_grounded = false;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(this.gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump_power3);
        animator.SetBool("is_jumping", true);
        animator.SetBool("is_walking", false);

    }
    private void Movement()
    {
        //animator.SetFloat("Speed", Mathf.Abs(player_speed));
        //Automatically move the player forwards
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(player_speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
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
    //Make the player lose if the distance between player and deer becomes too large
    private IEnumerator CheckDistance()
    {
        for (; ; )
        {
            Vector3 player_position = GameObject.FindGameObjectWithTag("Player").transform.position;
            if (this.transform.position.x - player_position.x > 100 && !GameManager.game_manager.cheat_mode_is_enabled)
            {
                //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLogic>().Die();
                win_lose_canvas.GetComponent<WinLoseScreen>().ActivateDefeatScreen();
            }
            yield return new WaitForSeconds(2.0f);
        }
    }
}