using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    //public Dialogue current_dialogue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //if(collision.GetComponent<Player_Health_Collectible>().crystal_score == 3)
            //{
            //    SceneManager.LoadScene("EndScreen");
            //}s
           
            {
                InitiateDialogue();
            }
        }
    }
    IEnumerator GoBackToMenuTime()
    {
        yield return new WaitForSeconds(10.0f);
    }
    public void InitiateDialogue()
    {
        //FindObjectOfType<DialogueManager>().StartDialogue(current_dialogue);
    }
}
