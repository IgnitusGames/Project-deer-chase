using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    // Variables
    public GameObject Player;
    public float y_min;
    public float y_max;
    public float camera_offset;

    private Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        //Offset = transform.position - Player.transform.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        float y = Mathf.Clamp(Player.transform.position.y, y_min, y_max);
        gameObject.transform.position = new Vector3(Player.transform.position.x + camera_offset, y, gameObject.transform.position.z);
    }
}