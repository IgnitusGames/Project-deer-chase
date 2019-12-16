using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class CollectableScales : MonoBehaviour
{
    private GameObject scaleScore;

    private void Start()
    {
        scaleScore = GameObject.FindGameObjectWithTag("ScaleScore");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.game_manager.AddCollectable(SceneManager.GetActiveScene().name);
            scaleScore.GetComponent<HUDScaleScore>().updateHUDScore();
            Destroy(this.gameObject);
        }
    }
}
