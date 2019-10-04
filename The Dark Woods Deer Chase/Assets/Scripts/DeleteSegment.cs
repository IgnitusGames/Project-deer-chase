﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSegment : MonoBehaviour
{
    private Vector3 player_position;
    private void Start()
    {
        StartCoroutine(DeleteDelay());
    }
    // Update is called once per frame
    void Update()
    {
    }
    private IEnumerator DeleteDelay()
    {
        for(; ; )
        {
            DeleteCheck();
            yield return new WaitForSeconds(10.0f);
        }
    }
    private void DeleteCheck()
    {
        player_position = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (this.gameObject.transform.position.x + 350 < player_position.x)
        {
            Destroy(this.gameObject);
        }
    }
}
