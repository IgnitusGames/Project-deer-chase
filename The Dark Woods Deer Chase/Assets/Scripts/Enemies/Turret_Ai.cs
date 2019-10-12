using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Ai : MonoBehaviour
{
    public int cur_Health;
    public int max_Health;

    public float distance;
    public float wakeRange;
    public float shoot;
    public float bulletSpeed = 200;
    public float bulletTimer;
    public float bulletInterval;

    public bool awake = false;
    public bool lookingRight;

    public GameObject bullet;
    public Transform target;
    public Animator animator;
    public Transform shootPointLeft, shootPointRight;
    AudioSource audioSource;
    public HealthComponent enemy_health_component;


  //  private Player_Health_Collectible player;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();

        enemy_health_component = gameObject.GetComponentInParent<HealthComponent>();

    }

    private void Start()
    {
       // player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health_Collectible>();
        audioSource = GetComponent<AudioSource>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }
    private void Update()
    {

        RangeCheck();
       

    }


    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance < wakeRange)
        {
            

            awake = true;
            


            if (target.transform.position.x < transform.position.x)
            {
                animator.SetBool("attackright", false);
                animator.SetBool("attackleft", true);
                animator.SetBool("idle", false);
            }
            else if (target.transform.position.x > transform.position.x)
            {
           

                animator.SetBool("attackright", true);
                animator.SetBool("attackleft", false);
                animator.SetBool("idle", false);

            }


            //Attack(true);
        }
       // else animator.SetBool("idle", true);
       // animator.SetBool("attackleft", false);
       // animator.SetBool("attackright", false);


        if (distance > wakeRange)
        {
            awake = false;
            animator.SetBool("idle", true);
            // animator.SetBool("idle", true);
        }
  
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
   
        if (collision.gameObject.tag == "Attack")
        {

            FindObjectOfType<AudioManager>().Play("EnemyTurretDmg");
            gameObject.GetComponent<Animation>().Play("ShroomDmg");
        }

    }

    public void Attack(bool attackingRight)
    {
        bulletTimer += Time.deltaTime;

        if (bulletTimer >= bulletInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            if(!attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                FindObjectOfType<AudioManager>().Play("EnemyTurretShoot");
                bulletTimer = 0;
             


            }
            if (attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                FindObjectOfType<AudioManager>().Play("EnemyTurretShoot");
                bulletTimer = 0;

                
            }
        }
    }
}
