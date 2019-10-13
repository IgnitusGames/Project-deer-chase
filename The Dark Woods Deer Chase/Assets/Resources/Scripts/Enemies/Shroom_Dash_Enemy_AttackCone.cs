using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shroom_Dash_Enemy_AttackCone : MonoBehaviour
{
    // Start is called before the first frame update
    //public Enemy_move enemy;
    public bool isLeft = false;
    public Shroom_Dash_Enemy_Move enemy_move;
    public Animator animator;

    private void Awake()
    {

        enemy_move = gameObject.GetComponentInParent<Shroom_Dash_Enemy_Move>();

    }


    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            enemy_move.EnemySpeed = 0;
            enemy_move.Attack();
            animator.SetBool("attack", true);
            //animator.SetBool("attack", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        {
            if (collision.gameObject.tag == "Player")
            {
                enemy_move.EnemySpeed = 4;
                animator.SetBool("attack", false);
            }
        }
    }





}

