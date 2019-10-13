using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class OpeningCutsceneLogic : MonoBehaviour
{
    private VideoPlayer cutscene;
    private bool cutscene_has_finished = false;

    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        cutscene = this.gameObject.GetComponent<VideoPlayer>();
    }
    // Update is called once per frame
    void Update()
    {
        //start checking if video is still playing
        StartCoroutine(CheckVideo());
        //hide video player once cutscene has finished playing or if player wants to skip the cutscene
        if(cutscene_has_finished || Input.touchCount > 0 || Input.GetButtonDown("Fire1"))
        {
            CloseCutscene();
        }
    }
    //check if video is still playing every 10 seconds
    private IEnumerator CheckVideo()
    {
        yield return new WaitForSeconds(10.0f);
        if(!cutscene.isPlaying)
        {
            cutscene_has_finished = true;
        }
    }
    //hides the cutscene and shows the menu
    private void CloseCutscene()
    {
        this.gameObject.SetActive(false);
        menu.SetActive(true);
    }
}