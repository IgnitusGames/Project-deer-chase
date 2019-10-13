using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FireBallLogic : MonoBehaviour
{
    //Variables
    public float Damage = 10;

    private string[] destroy_on_collide;
    //Unity functions
    private void Start()
    {
        destroy_on_collide = new string[4] { "enemy", "Ground", "movplat" , "Slow"};
    }
    private void Update()
    {
        Destroy(this.gameObject, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Code below is executed when the fire prefab this script is attatched to comes in contact with an enemy
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "Slow")
        {
            collision.GetComponent<HealthComponent>().TakeDamage(Damage);
        }
        foreach(string tag in destroy_on_collide)
        {
            if(collision.gameObject.tag == tag)
            {
                Destroy(this.gameObject);
            }
        }
    }
}