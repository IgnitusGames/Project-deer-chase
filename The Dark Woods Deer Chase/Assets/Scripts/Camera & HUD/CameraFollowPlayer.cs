using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    // Variables
    public GameObject Player;
    public float x_min;
    public float x_max;
    public float y_min;
    public float y_max;

    private Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        //Offset = transform.position - Player.transform.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        float x = Mathf.Clamp(Player.transform.position.x, x_min, x_max);
        float y = Mathf.Clamp(Player.transform.position.y, y_min, y_max);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}