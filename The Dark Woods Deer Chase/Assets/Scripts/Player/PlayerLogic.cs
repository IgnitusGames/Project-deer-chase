using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerLogic : MonoBehaviour
{
    //Variables
    //public Animator animator;
    public int player_speed = 10;
    public int jump_power = 250;
    public int player_max_health;
    public int player_curr_health;
    public int player_mana;
    public int y_death_level;
    public bool is_grounded = true;
    public bool jump;
    public bool gliding = false;
    public float force = 100;
    private Rigidbody2D rb2d;
    public int amount_of_jumps = 2;
    // Update is called once per frame
    private void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Movement();
        if (player_max_health > player_curr_health)
        {
            player_curr_health = player_max_health;
        }
        //Attacks
        //Death Scenarios
        if (gameObject.transform.position.y < y_death_level)
        {
            Die();
        }
        if (player_curr_health <= 0)
        {
            Die();
        }
        //Animations
        if (is_grounded == false)
        {
           // animator.SetBool("is_jumping", true);
        }
        if (is_grounded == true)
        {
            //animator.SetBool("is_jumping", false);
        }
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
            print("jump");
            // Jump2();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Resets player jump ability when player has hit the ground
        if(collision.gameObject.tag == "Ground")
        {
            is_grounded = true;
            amount_of_jumps = 2;
        }
        if (collision.gameObject.tag == "movplat")
        {
            is_grounded = true;
            this.transform.parent = collision.transform;
            Debug.Log("op platform");
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "movplat")
            this.transform.parent = null;
        //Check if player is no longer on the ground
        if(col.gameObject.tag == "Ground" && amount_of_jumps != 2)
        {
            print("niet op grond");
            is_grounded = false;
        }
    }
    public void Glide()
    {
        if (!is_grounded)
        {
            gliding = true;
            rb2d.gravityScale = 0.1f;
        }
    }
    public void StopGlide()
    {
        gliding = false;
        rb2d.gravityScale = 1.0f;
    }
    public void Die()
    {
        //Kill the player (technically reloading the level)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Jump()
    {
        //check if jumping is allowed
        if(amount_of_jumps > 0)
        {
            amount_of_jumps -= 1;
            is_grounded = false;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(this.gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump_power);
        }
    }
    private void Movement()
    {
      
        // animator.SetFloat("Speed", Mathf.Abs(player_speed));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(player_speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
}