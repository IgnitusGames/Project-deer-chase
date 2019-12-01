using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
    //Variables
    public GameObject tutorial_box;
    public Sprite image;

    private GameObject current_image;
    //Unity functions
    private void Start()
    {
        tutorial_box.transform.GetChild(0).GetComponent<Image>().sprite = this.image;
    }
}