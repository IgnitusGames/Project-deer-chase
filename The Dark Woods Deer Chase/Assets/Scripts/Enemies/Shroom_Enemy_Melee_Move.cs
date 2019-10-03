using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shroom_Enemy_Melee_Move : MonoBehaviour
{
    // Start is called before the first frame update
    public int EnemySpeed;
    public int XMoveDirection;
    public bool facingRight = true;
   // private Player_Health_Collectible player;
    public float raycast_hit_offset;
    public Animator animator;
    public float force;
    public float hitTimer = 5;
    public float hitInterval;
    public float attacktimer = 20.0f;
    public float hitDistance;
    private PlayerLogic player_logic;
    
    private void Start()
    {
        player_logic = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLogic>();
    }
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + raycast_hit_offset, transform.position.y), new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        hitTimer += Time.deltaTime;
        // Debug.Log(hit.distance);

        
        if (hit.collider.tag != "Player" && hit.distance > hitDistance)
        {
            EnemySpeed = 4;
            animator.SetBool("IsAttack", false);
            //animator.SetBool("IsAttack", false);
        }
        // Attack();

        // EnemySpeed = 4;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyCollider")
        {
            Flip();
        }
        if (collision.gameObject.tag == "Attack")
        {

            FindObjectOfType<AudioManager>().Play("EnemyShroomDashOnDmg");
            gameObject.GetComponent<Animation>().Play("shroommeleedmg");
            print("pannenkoekn");
        }
     

    }


    public void Attack()
    {
        
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + raycast_hit_offset, transform.position.y), new Vector2(XMoveDirection, 0));

        //bulletTimer >= bulletInterval

        print(hit.distance);
        print(hit.collider.tag);
        if(facingRight == true)
        {
            if (hit.collider.tag == "Player" && hit.distance < hitDistance && hitTimer >= hitInterval)
            {
                raycast_hit_offset = (1.5f);
                EnemySpeed = 0;
               // hit.collider.gameObject.GetComponent<Player_Health_Collectible>().Damage(1);
                hitTimer = 0;
                print("valalalltl aana");
                FindObjectOfType<AudioManager>().Play("ShroomEnemyAttack");
                animator.SetBool("IsAttack", true);
                //player_logic.StartCoroutine(player_logic.KnockBack(0.02f, 50, Vector2.left*200));
            }
        }
        if (facingRight == false)
        {
            raycast_hit_offset = (-1.5f);
            if (hit.collider.tag == "Player" && hit.distance < hitDistance && hitTimer >= hitInterval)
            {

                EnemySpeed = 0;
                //hit.collider.gameObject.GetComponent<Player_Health_Collectible>().Damage(1);
                hitTimer = 0;
                print("valalalltl aana");
                FindObjectOfType<AudioManager>().Play("ShroomEnemyAttack");
                animator.SetBool("IsAttack", true);
               // player_logic.StartCoroutine(player_logic.KnockBack(0.02f, 50, Vector2.right * 200));
            }
        }

  



    }


    void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
            facingRight = true;
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

}

