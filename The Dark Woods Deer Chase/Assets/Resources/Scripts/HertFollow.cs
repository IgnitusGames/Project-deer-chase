using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HertFollow : MonoBehaviour
{
    //public GameObject Hertje;
    public RectTransform canvasRectT;
    public RectTransform blokje;
    public float distance;
    public Transform Hert;
    public Transform Andor;

    public float greenDistance = 45;
    public float orangeDistance = 70;
    public Image hertFollowImage;
    private float redDistance = 85;

    void Update()
    {
        //transform.localPosition = new Vector3(transform.localPosition.x, GetHertjesYAxis(), transform.localPosition.z);

        hertFollowImage = gameObject.GetComponent<Image>();

        Hert = GameObject.FindGameObjectWithTag("deer").transform;
        Andor = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, Hert.position);
        Vector2 completePosition = screenPoint - canvasRectT.sizeDelta / 2f;

        if (completePosition.y < -480)
        {
            completePosition.y = -480;
        }
        if (completePosition.y > 480)
        {
            completePosition.y = 480;
        }
        blokje.anchoredPosition = new Vector2(blokje.anchoredPosition.x, completePosition.y);

        distance = Vector3.Distance(Andor.transform.position, Hert.transform.position);



        if (distance > greenDistance && distance < orangeDistance)
        {

            hertFollowImage.GetComponent<Image>().color = new Color32(0, 255, 0, 80);
        }
        else if (distance > orangeDistance && distance < redDistance)
        {

            hertFollowImage.GetComponent<Image>().color = new Color32(255, 255, 0, 80);
        }
        else if (distance > redDistance)
        {

            hertFollowImage.GetComponent<Image>().color = new Color32(255, 0, 0, 80);
        }
        //else if (distance > orangeDistance)
        //{
        //    hertFollowImage.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        //}
        else
        {
            hertFollowImage.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        }
        //if (distance > greenDistance)
        //{
        //   hertFollowImage.GetComponent<Image>().color = new Color32(30, 240, 50, 255);
        //}


        //if (orangeDistance < distance && distance > greenDistance)
        //{

        //    hertFollowImage.GetComponent<Image>().color = new Color32(30, 240, 50, 0);
        //}
        //else if (distance < greenDistance)
        //{

        //    hertFollowImage.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        //}
        //else if (distance < greenDistance)
        //{

        //    hertFollowImage.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        //}
    }

    //public float GetHertjesYAxis()
    //{
    //    return Hertje.transform.position.y;
    //}
}
