﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerLogic : MonoBehaviour
{
    public int gold_score = 0;
    //VariablesF
    public GameObject fire_ball;
    //public Animator animator;
    public float player_speed;
    public float current_player_speed;

    public int fire_ball_speed = 11;
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
    private float original_gravity;
    private float original_player_speed;
    public int amount_of_jumps = 2;
    public float windspeed = 100;
    public float slow_speed = 5;
    public float gold_speed_mod;
    private void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        original_gravity = this.GetComponent<Rigidbody2D>().gravityScale;
        original_player_speed = player_speed;
    }
    // Update is called once per frame
    private void Update()
    {
        Movement();
        Combat();
        if (player_max_health > player_curr_health)
        {
            player_curr_health = player_max_health;
        }
        print("player_speed :" + player_speed);

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
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "movplat")
        {
            is_grounded = true;
            amount_of_jumps = 2;
            print("GROND!!!!");
        }
        if (collision.gameObject.tag == "movplat")
        {
            player_speed = 0;
            is_grounded = true;
            this.transform.parent = collision.transform;

        }
        if (collision.gameObject.tag == "deer")
        {
            print("rekt");

        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "movplat")
            this.transform.parent = null;
        //Check if player is no longer on the ground
        if(col.gameObject.tag == "Ground" && amount_of_jumps != 2 && col.gameObject.tag == "movplat")
        {
            print("niet op grond");
            is_grounded = false;
        }
        player_speed = original_player_speed + gold_speed_mod;
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
        rb2d.gravityScale = original_gravity;
    }
    public void Die()
    {
        //Kill the player (technically reloading the level)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Jump()
    {
        //check if jumping is allowed
        if (!GameManager.game_manager.cheat_mode_is_enabled)
        {
            if (amount_of_jumps > 0)
            {
                amount_of_jumps -= 1;
                is_grounded = false;
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(this.gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump_power);
            }
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(this.gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up* jump_power);
        }
    }
    private void Movement()
    {
        //animator.SetFloat("Speed", Mathf.Abs(player_speed));
        //Automatically move the player forwards
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(player_speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        print(GetComponent<Rigidbody2D>().velocity);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wind")
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * windspeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slow" && !GameManager.game_manager.cheat_mode_is_enabled)
        {
            player_speed = original_player_speed + gold_speed_mod - 10;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Slow")
        {
            player_speed = original_player_speed + gold_speed_mod;
        }
    }
    private void Combat()
    {
        if (Input.touchCount > 0 || Input.GetButtonDown("Fire1"))
        {
            Vector2 player_pos = Camera.main.WorldToScreenPoint(this.transform.position);
            Vector2 target = new Vector2();
            
            if(Input.touchCount > 0)
            {
                target = Input.GetTouch(0).position;
            }
            else
            {
                target = Input.mousePosition;
            }
            if (target.x < (player_pos.x) * 2)
            {
                return;
            }
            else
            {
                Vector2 direction = target - player_pos;
                direction = direction.normalized;
                //Rotation is calculated with the tangent function
                float rotation = (float)Math.Atan2(target.y - player_pos.y, target.x - player_pos.x) * 100;
                GameObject fire_ball_instance = Instantiate(fire_ball, this.transform.position, Quaternion.Euler(new Vector3(0, 0, rotation)));
                print("nhnjnhjnj");
                fire_ball_instance.GetComponent<Rigidbody2D>().velocity = direction * fire_ball_speed;
            }
        }
    }
    public void GoldScore(int goldscore)
    {
        gold_score += goldscore;
        gold_speed_mod = gold_score / 100;

        Debug.Log(string.Format("MOD  = {0}", gold_speed_mod));
        print("gooldld :" + gold_score);
        //Debug.Log("Gold mod = " + gold_speed_mod.ToString());
        //
        player_speed = original_player_speed + gold_speed_mod;
        print("BLASLDSAKNDAD ASNDKASD SAJB ABS: " + player_speed);
    }
    public IEnumerator KnockBack(float knockDur, float knockBackPwr, Vector2 knockBackDirection)
    {
        float timer = 0;
        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(knockBackDirection.x * knockBackPwr, knockBackDirection.y));
            print("yeet");
        }
        yield return 0;
    }
    public IEnumerator KnockUp(float knockDur, float knockUpPwr, Vector2 knockBackDirection)
    {
        float timer = 0;
        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(knockBackDirection.x, knockBackDirection.y * knockUpPwr));
            print("yeet");
        }
        yield return 0;
    }
}