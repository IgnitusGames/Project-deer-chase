using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeerHead : MonoBehaviour
{

    public RectTransform canvasRectT;
    public RectTransform blokje;
    public float distance;
    public Transform Hert;
    public Transform Andor;

    public float greenDistance = 45;
    public float orangeDistance = 70;
    public Image hertFollowImage;
    private float redDistance = 85;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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



        if (distance > greenDistance)
        {

            hertFollowImage.GetComponent<Image>().color = new Color32(255, 255, 255, 200);
        }
        else
        {
            hertFollowImage.GetComponent<Image>().color = new Color32(0, 0, 0, 00);
        }
    }
}
