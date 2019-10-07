using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    Material _material;

    // Start is called before the first frame update
    void Start()
    {
        Material _material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        float currentscroll = 0;
        float speed = 0;
        currentscroll += speed * Time.deltaTime;
        _material.mainTextureOffset = new Vector2(currentscroll, 0);
    }
}
