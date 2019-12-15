using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeScript : MonoBehaviour
{
    public Image background;
    public Text title;
    public Text retry;
    public Text main_menu;

    private float timeToFade = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        print("fading");
        background.DOFade(1, 1);
        title.DOFade(1, 1);
        retry.DOFade(1, 1);
        main_menu.DOFade(1, 1);
    }
}
