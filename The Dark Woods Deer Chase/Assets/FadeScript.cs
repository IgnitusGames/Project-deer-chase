using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeScript : MonoBehaviour
{
    public Image fadeImage;
    private bool canFade;
   
    private Color currColor;
    private bool done = false;
    private float timeToFade = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //canFade = true;
        StartCoroutine(Fading());

        //alphaColor.a = 0;
        //currColor = new Color32(0, 0, 0, 255);
    }

    // Update is called once per frame
    void Update()
    {
     
        print(fadeImage.color);
        //fadeImage.color = Color.Lerp(fadeImage.color, alphaColor, timeToFade * Time.deltaTime);
        print("hoi");

       // obj.GetComponent<MeshRenderer>().material.color = Color.Lerp(obj.GetComponent<MeshRenderer>().material.color, alphaColor, timeToFade * Time.deltaTime);
        
    }
    private IEnumerator Fading()
    {
        fadeImage.DOFade(1, 1);
        yield return new WaitForSeconds(3.0f);
        fadeImage.DOFade(0, 1);
    }
}
