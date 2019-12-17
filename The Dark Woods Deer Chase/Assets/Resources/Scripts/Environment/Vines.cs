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
        print("asdnasjdaskdasndja");
        gameObject.GetComponent<Animation>().Play("ShroomDmg");
        FindObjectOfType<AudioManager>().Play("VineDmg");
        StartCoroutine(WaitForAnimation());

        fire.Play();
        if (collision.gameObject.tag == "Player")
        {
           
            StartCoroutine(player_logic.SlowDown(0.5f));
        }
    }

    public IEnumerator WaitForAnimation()
    {
        
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);

    }
}