using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Bullet : MonoBehaviour
{
   // private Player_Health_Collectible player_health;
    private PlayerLogic player;
    void Update()
    {
        Destroy(this.gameObject, 5);
    }
    private void Start()
    {
       // player_health = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health_Collectible>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLogic>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("EnemyTurretBulletHit");

          //  player_health.Damage(1);
           // player.StartCoroutine(player.KnockBack(0.02f, 100, player.transform.position));
            Destroy(this.gameObject, 1);
        }
    }
}