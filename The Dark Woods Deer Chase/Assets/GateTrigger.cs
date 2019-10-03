using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    public GateOpen gate_trigger;
    private void Awake()
    {
        gate_trigger = gameObject.GetComponentInParent<GateOpen>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)



    {
        if (collision.gameObject.tag == "Attack")
            print("SESAM OPEN NU");
            gate_trigger.Open();
        Destroy(gameObject);


    }
 
}
