using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Shroom_Dash_Enemy_Move : MonoBehaviour
{
    // Start is called before the first frame update
    public int EnemySpeed;
    public int XMoveDirection;
    public bool facingRight = true;
    //private Player_Health_Collectible player;

    public float force;
    public float hitTimer = 5;
    public float hitInterval;
    public float dash_time;
    public Animator animator;
    public float hitDistance;
    //Vector2 currpos = transform.position;

    private PlayerLogic player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLogic>();
    }

    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        hitTimer += Time.deltaTime;
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
        if (collision.gameObject.tag == "EnemyCollider")
        {

            Flip();
        }
        if (collision.gameObject.tag == "Attack")
        {

            FindObjectOfType<AudioManager>().Play("EnemyShroomDashOnDmg");
            gameObject.GetComponent<Animation>().Play("dmgtaken");
        }
        if (collision.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<Player_Health_Collectible>().Damage(1);
          //  player.StartCoroutine(player.KnockBack(0.02f, 100, player.transform.position));

        }
    }
    public void Attack()
    {
        if (facingRight == true && hitTimer >= hitInterval)
        {
            hitTimer = 0;
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
            FindObjectOfType<AudioManager>().Play("EnemyShroomDashSound");
            StartCoroutine(DashBack());
        }
        else if (facingRight == false && hitTimer >= hitInterval)
        {
            hitTimer = 0;
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);      
            StartCoroutine(DashBack2());
        }
    }

    void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
            facingRight = !facingRight;
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
    IEnumerator DashBack()
    {
        yield return new WaitForSeconds(dash_time);
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * (force * 2));
    }
    IEnumerator DashBack2()
    {
        yield return new WaitForSeconds(dash_time);
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * (force* 2));
    }
}
