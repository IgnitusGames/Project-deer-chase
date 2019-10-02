using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shroom_Melee_Cone : MonoBehaviour
{
    public Shroom_Enemy_Melee_Move enemy_move;
    public Animator animator;

    private void Awake()
    {

        enemy_move = gameObject.GetComponentInParent<Shroom_Enemy_Melee_Move>();

    }


    void OnTriggerStay2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            print("inrange");
            enemy_move.Attack();
            enemy_move.EnemySpeed = 0;
            //animator.SetBool("attack", true);
            // print("inrange");
            //animator.SetBool("attack", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        {
            if (collision.gameObject.tag == "Player")
            {
                enemy_move.EnemySpeed = 4;

            }
        }
    }





}

