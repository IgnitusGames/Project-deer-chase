using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public HorizonPlatTrigger plat_trigger;
    private void Awake()
    {
        plat_trigger = gameObject.GetComponentInParent<HorizonPlatTrigger>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)



    {
        if (collision.gameObject.tag == "Attack")

        plat_trigger.Open();
        Destroy(gameObject);


    }
}