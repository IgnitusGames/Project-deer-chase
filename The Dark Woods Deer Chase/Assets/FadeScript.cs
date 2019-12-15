using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeScript : MonoBehaviour
{
    public Image background;
    public Text title;
    public Image retry;
    public Image main_menu;
    public Image[] additionalImages;

    private float timeToFade = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        print("fading");
        background.DOFade(1, 1);
        title.DOFade(1, 1);
        retry.DOFade(1, 1);
        main_menu.DOFade(1, 1);
        foreach(Image i in this.additionalImages)
        {
            i.DOFade(1, 1);
        }
    }
}
