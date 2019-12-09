using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HertFollow : MonoBehaviour
{
    //public GameObject Hertje;
    public RectTransform canvasRectT;
    public RectTransform blokje;
    public Transform objectToFollow;

    void Update()
    {
        //transform.localPosition = new Vector3(transform.localPosition.x, GetHertjesYAxis(), transform.localPosition.z);
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, objectToFollow.position);
       Vector2 completePosition = screenPoint - canvasRectT.sizeDelta / 2f;
        blokje.anchoredPosition = new Vector2(blokje.anchoredPosition.x, completePosition.y);
    }

    //public float GetHertjesYAxis()
    //{
    //    return Hertje.transform.position.y;
    //}
}
