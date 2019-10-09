using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBackground : MonoBehaviour
{
    private Vector3 player_position;

    public float wait_dur;
    public Vector3 distance;
    private void Start()
    {
        StartCoroutine(DeleteDelay());
        //player_start_position = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
    private IEnumerator DeleteDelay()
    {
        for (; ; )
        {
            DeleteCheck();
            yield return new WaitForSeconds(wait_dur);
        }
    }
    private void DeleteCheck()
    {


        player_position = GameObject.FindGameObjectWithTag("Player").transform.position;

        print("player ps" + player_position.x);
        print("dit object" + this.gameObject.transform.position.x );


        if (this.gameObject.transform.position.x < player_position.x + distance.x)
        {
            Destroy(this.gameObject);
        }
    }
}