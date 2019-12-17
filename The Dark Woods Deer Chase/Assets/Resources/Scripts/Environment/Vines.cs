using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vines : MonoBehaviour
{
    private PlayerLogic player_logic;
    public Animator animator;
    private ParticleSystem fire;
    // Start is called before the first frame update
    void Start()
    {
        player_logic = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLogic>();
        fire = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<Animation>().Play("ShroomDmg");
        FindObjectOfType<AudioManager>().Play("VineDmg");
        StartCoroutine(WaitForAnimation());

        fire.Play();
        if (collision.gameObject.tag == "Player")
        {    
            // Deze timer MOET korter zijn dan de wait for animation
            StartCoroutine(player_logic.SlowDown(0.7f));
        }
    }

    public IEnumerator WaitForAnimation()
    {      
        yield return new WaitForSeconds(0.8f);
        Destroy(this.gameObject);
    }
}