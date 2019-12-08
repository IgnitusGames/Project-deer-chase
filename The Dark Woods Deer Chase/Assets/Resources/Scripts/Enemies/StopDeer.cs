using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopDeer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "deer")
        {
            other.gameObject.GetComponent<Deerscripttest>().player_speed = 0;
        }
    }
}