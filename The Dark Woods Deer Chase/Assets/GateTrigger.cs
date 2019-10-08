using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    public GateOpen gate_trigger;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
         gate_trigger = gameObject.GetComponentInChildren<GateOpen>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            print("SESAM OPEN NU");
            gate_trigger.Open();
            FindObjectOfType<AudioManager>().Play("Trigger");
            animator.SetBool("is_open", true);
        }

    }

 



    //private void OnTriggerEnter2D(Collider2D collision)



    //{
    //    if (collision.gameObject.tag == "Attack")
    //        print("SESAM OPEN NU");
    //        gate_trigger.Open();
    //   // Destroy(gameObject);


    //}
 
}
