using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineUpward : MonoBehaviour
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
        gameObject.GetComponent<Animation>().Play("VineUpwardAnim");
        //gameObject.GetComponent<Animation>().Play("VineDie");
        FindObjectOfType<AudioManager>().Play("VineDmg");
        StartCoroutine(WaitForAnimation());
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        fire.Play();
    }

    public IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }
}