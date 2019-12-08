﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vines : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            gameObject.GetComponent<Animation>().Play("ShroomDmg");
            FindObjectOfType<AudioManager>().Play("VineDmg");
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}