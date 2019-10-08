using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Vlinder : MonoBehaviour
{
    // Start is called before the first frame update
    public int EnemySpeed;
    public int XMoveDirection;
    //public bool facingRight = true;
    //private Player_Health_Collectible player_health;
    private PlayerLogic player;
    public float force = 5000;

    //public Player_health player_Health;

    [SerializeField]
    float moveSpeed = 5f;

    [SerializeField]
    float frequency = 20f;

    [SerializeField]
    float magnitude = 0.5f;

    bool facingRight = false;

    Vector3 pos, localScale;

    // Use this for initialization
    void Start()
    {

        pos = transform.position;

        localScale = transform.localScale;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLogic>();
    }

    // Update is called once per frame
    void Update()
    {

        CheckWhereToFace();

        if (facingRight)
            MoveRight();
        else
            MoveLeft();

    }

    void CheckWhereToFace()
    {
        if (pos.x < -7f)
            facingRight = true;

        else if (pos.x > 7f)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;

    }

    void MoveRight()
    {
        pos += transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    void MoveLeft()
    {
        pos -= transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }
    private void OnCollisionEnter2D(Collision2D collision2d)
    {



        if (collision2d.gameObject.tag == "Player" && facingRight == true)
        {
          
           // collision2d.gameObject.GetComponent<Player_Health_Collectible>().Damage(1);
            MoveLeft();

        }
        if (collision2d.gameObject.tag == "Player" && facingRight == false)
        {
           
            //collision2d.gameObject.GetComponent<Player_Health_Collectible>().Damage(1);
            MoveRight();

        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Attack")
        {

            FindObjectOfType<AudioManager>().Play("EnemyShroomDashOnDmg");
            //player.StartCoroutine(player.KnockBack(0.02f, 100, player.transform.position));
        }


    }
}

