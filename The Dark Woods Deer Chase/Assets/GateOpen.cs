using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour
{


    public float moveSpeed = 3f;
    public bool open = false;
    private Vector2 start_pos;
    public float range = 4;

    public GateTrigger gate_trigger;


    private void Awake()
    {
        gate_trigger = gameObject.GetComponentInParent<GateTrigger>();
    }

    private void Start()
    {
        start_pos = gameObject.transform.position;
    }

    void Update()
    {
        if (open == true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        if (transform.position.y > (start_pos.y + range))
            open = false;
    }

    public void Open()
    {
        open = true;
    }
    void Stop()
    {
        moveSpeed = 0;
    }
}