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

    void OnTriggerStay2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            print("trigtrog");
            gate_trigger.Open();

        }
    }
}
