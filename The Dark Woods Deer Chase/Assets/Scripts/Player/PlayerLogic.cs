﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerLogic : MonoBehaviour
{
    public float doublejumptimer;
    public float timer = 0;
    
    public int gold_score = 0;
    //VariablesF
    public GameObject fire_ball;
    public Animator animator;
    public float player_speed;
    public float current_player_speed;

    public int fire_ball_speed = 11;
    public int jump_power = 250;
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

    private GameObject win_lose_canvas;
    private HealthComponent enemy_health;
    private bool can_fire = true;
    private void Start()
    {
        StartCoroutine(DeathCheck());
        Time.timeScale = 1;
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        original_gravity = this.GetComponent<Rigidbody2D>().gravityScale;
        original_player_speed = player_speed;
        win_lose_canvas = GameObject.FindGameObjectWithTag("WinLose");
    }
    // Update is called once per frame
    private void Update()
    {
        Movement();
        Combat();
        timer += Time.deltaTime;
    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Resets player jump ability when player has hit the ground
        if ((collision.gameObject.tag == "Ground" || collision.gameObject.tag == "movplat"))
        {
            is_grounded = true;
            amount_of_jumps = 2;
            animator.SetBool("is_gliding", false);
            animator.SetBool("is_jumping", false);
            animator.SetBool("is_double_jumping", false);
        }
        if (collision.gameObject.tag == "movplat")
        {
            player_speed = 0;
            is_grounded = true;
            this.transform.parent = collision.transform;

        }
        if (collision.gameObject.tag == "deer")
        {
            win_lose_canvas.GetComponent<WinLoseScreen>().ActivateVictoryScreen();
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "movplat")
            this.transform.parent = null;
        //Check if player is no longer on the ground
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "movplat" )
        {
            animator.SetBool("is_jumping", true);
            is_grounded = false;
            player_speed = original_player_speed + gold_speed_mod;
        }
        //  player_speed = original_player_speed + gold_speed_mod;
    }
    public void Glide()
    {
        if (!is_grounded)
        {
            gliding = true;
            rb2d.gravityScale = 0.1f;
            animator.SetBool("is_gliding", true);
        }
    }
    public void StopGlide()
    {
        gliding = false;
        rb2d.gravityScale = original_gravity;
        animator.SetBool("is_gliding", false);
    }
    public void Die()
    {
        win_lose_canvas.GetComponent<WinLoseScreen>().ActivateDefeatScreen();
    }
    public void Jump()
    {
        if(amount_of_jumps > 1)
        {
            animator.SetBool("is_gliding", false);
            animator.SetBool("is_jumping", true);
            animator.SetBool("is_double_jumping", false);
        }
        if (amount_of_jumps == 1)
        {
            animator.SetBool("is_gliding", false);
            animator.SetBool("is_jumping", false);
            animator.SetBool("is_double_jumping", true);
            FindObjectOfType<AudioManager>().Play("Wing");
        }
        if (amount_of_jumps < 1)
        {
            animator.SetBool("is_jumping", true);
            animator.SetBool("is_double_jumping", false);
        }

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
        animator.SetFloat("Speed", Mathf.Abs(player_speed));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(player_speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Glide();
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            StopGlide();
        }
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
       
        

        if (((Input.touchCount > 0 || Input.GetButtonDown("Fire1")) && !PauseLogic.is_paused && timer > 0.3f))
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
            if (target.x < (player_pos.x) * 3)
            {
                return;
            }
            else
            {

                timer = 0;
            
                Vector2 direction = target - player_pos;
                direction = direction.normalized;
                //Rotation is calculated with the tangent function
                float rotation = (float)Math.Atan2(target.y - player_pos.y, target.x - player_pos.x) * 100;
                GameObject fire_ball_instance = Instantiate(fire_ball, this.transform.position, Quaternion.Euler(new Vector3(0, 0, rotation)));
                FindObjectOfType<AudioManager>().Play("Fireball");
                fire_ball_instance.GetComponent<Rigidbody2D>().velocity = direction * fire_ball_speed;
              //  StartCoroutine(FireCooldown());
            }
        }
    }
    public void GoldScore(int goldscore)
    {
        gold_score += goldscore;
        gold_speed_mod = gold_score / 100;
        Debug.Log(string.Format("MOD  = {0}", gold_speed_mod));
     
        player_speed = original_player_speed + gold_speed_mod;
        print(gold_score);
        if (gold_score > 25 && gold_score < 28)
        {
            print("gold tussen 25 en 28");
            FindObjectOfType<AudioManager>().Play("100gold");
        }
        if (gold_score > 50 && gold_score < 53)
        {
            FindObjectOfType<AudioManager>().Play("200gold");
        }
        if (gold_score > 75 && gold_score < 88)
        {
            FindObjectOfType<AudioManager>().Play("300gold");
        }
        if (gold_score > 100 && gold_score < 103)
        {
            FindObjectOfType<AudioManager>().Play("400gold");
        }
        if (gold_score > 125 && gold_score < 128)
        {
            FindObjectOfType<AudioManager>().Play("500gold");
        }
        if (gold_score > 150 && gold_score < 153)
        {
            FindObjectOfType<AudioManager>().Play("600gold");
        }
    }
    public IEnumerator KnockBack(float knockDur, float knockBackPwr, Vector2 knockBackDirection)
    {

       // player_speed = original_player_speed + gold_speed_mod - 10;


         float timer = 0;

        while (knockDur > timer)
        {
            timer += Time.deltaTime;
        
            print(timer);
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(knockBackDirection.x * knockBackPwr, knockBackDirection.y));
        }
        yield return 0;
    }
    public IEnumerator KnockUp(float knockDur, float knockUpPwr, Vector2 knockBackDirection)
    {
        player_speed = original_player_speed +  gold_speed_mod;
        float timer = 0;
        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(knockBackDirection.x, knockBackDirection.y * knockUpPwr));
        }
        yield return 0;
    }

    public IEnumerator SlowDown(float duration)
    {

        player_speed = 5;
        print("geslowd");
        yield return new WaitForSeconds(duration);

        player_speed = original_player_speed;
    }
    public IEnumerator DeathCheck()
    {
        for(; ; )
        {
            if(this.transform.position.y < y_death_level)
            {
                win_lose_canvas.GetComponent<WinLoseScreen>().ActivateDeathScreen();
                break;
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
    //private IEnumerator FireCooldown()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    can_fire = true;
    //}
}